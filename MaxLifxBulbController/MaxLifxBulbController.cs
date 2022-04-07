﻿using MaxLifx.Util;
using MaxLifx.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MaxLifx.Packets;

namespace MaxLifx.Controllers
{
    public class LabelAndColourPayload
    {
        public string Label;
        public SetColourPayload Payload;
    }
    public class MaxLifxBulbController
    {
        // Network details
        UdpClient _receivingUdpClient;
        string _localIp = Utils.LocalIPAddress();
        IPAddress _sendToAddress;
        IPEndPoint _sendingEndPoint;

        // List of all bulbs discovered
        public List<Bulb> Bulbs = new List<Bulb>();

        public event EventHandler ColourSet;

        public void SetColour(string label, SetColourPayload payload, bool updateBox)
        {
            var bulb = Bulbs.Single(x => x.Label == label);
            SendPayloadToMacAddress(payload, bulb.MacAddress, bulb.IpAddress);
            // this updates the bulb monitor, skip for multizone lights
            if (updateBox){
                ColourSet?.Invoke(new LabelAndColourPayload() { Label = label, Payload = payload }, null);
            }
        }

        public void SendPayloadToMacAddress(IPayload Payload, string macAddress, string ipAddress)
        {
            var targetMacAddress = Utils.StringToByteArray(macAddress + "0000");
            //Socket sendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress sendToAddress = IPAddress.Parse(ipAddress);
            IPEndPoint sendingEndPoint = new IPEndPoint(sendToAddress, 56700);

            byte[] sendData = Utils.StringToByteArray(PacketFactory.GetPacket(targetMacAddress, Payload));
            //sendingSocket.SendTo(sendData, sendingEndPoint);
            //sendingSocket.Dispose();

            var a = new UdpClient();
            a.Connect(sendingEndPoint);
            a.Send(sendData, sendData.Length);
            a.Close();
        }

        // The following is based on https://github.com/PhilWheat/LIFX-Control
        public void DiscoverBulbs(string ip = "")
        {
            // Send discovery packet
            GetServicePayload payload = new GetServicePayload();
            byte[] sendData = Utils.StringToByteArray(PacketFactory.GetPacket(new byte[8], payload));
            if (ip != "") _localIp = ip;

            var a = new UdpClient();
            a.Connect(_sendingEndPoint);
            a.Send(sendData, sendData.Length);
            a.Close();

            //_sendingSocket.SendTo(sendData, _sendingEndPoint);

            // Listen for replies
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            _receivingUdpClient = new UdpClient(56700);
            
            byte[] receivebytes;

            // Pause for a second to allow for slow bulb responses - not uncommmon :/
            Thread.Sleep(1000);
            Bulbs = new List<Bulb>();
            // Now loop through received packets
            while (_receivingUdpClient.Available > 0)
            {
                // Get the outstanding bytes
                receivebytes = _receivingUdpClient.Receive(ref remoteIpEndPoint);

                // Get the MAC address of the bulb replying
                var macAddress = Utils.ByteArrayToString(receivebytes).Substring(16, 12);
                if (macAddress != "000000000000")
                {
                    var newBulb = new Bulb() {MacAddress = macAddress, IpAddress = remoteIpEndPoint.Address.ToString()};

                    // Create a new Bulb object
                    if (Bulbs.Count(x => x.MacAddress == macAddress) == 0)
                        Bulbs.Add(newBulb);
                }
            }

            // Now, find the labels of all the bubs we detected
            GetLabelPayload labelPayload = new GetLabelPayload();
            // and also the version of each bulb
            GetVersionPayload versionPayload = new GetVersionPayload();
            // and zones if any
            GetColourZonesPayload ColourZonesPayload = new GetColourZonesPayload();
            foreach (var bulb in Bulbs)
            {
                a = new UdpClient();
                a.Connect(_sendingEndPoint);
                // Send label request to a specific bulb
                sendData = Utils.StringToByteArray(PacketFactory.GetPacket(Utils.StringToByteArray(bulb.MacAddress + "0000"), labelPayload));
                a.Send(sendData, sendData.Length);
                // Send version request to a specific bulb
                Thread.Sleep(50); // Limit requests per second to 20 or bulb can break
                sendData = Utils.StringToByteArray(PacketFactory.GetPacket(Utils.StringToByteArray(bulb.MacAddress + "0000"), versionPayload));
                a.Send(sendData, sendData.Length);
                a.Close();

                //_sendingSocket.SendTo(sendData, _sendingEndPoint);

                Thread.Sleep(1000);

                while (_receivingUdpClient.Available > 0)
                {
                    receivebytes = _receivingUdpClient.Receive(ref remoteIpEndPoint);
                    if (receivebytes[0] == 0x44)
                    {
                        // Parse the received label and mark it against the bulb
                        var label1 = Utils.HexToAscii(Utils.ByteArrayToString(receivebytes).Substring(36 * 2));
                        bulb.Label = label1.Substring(0,label1.IndexOf('\0'));
                    }
                    if (receivebytes[0] == 48)
                    {
                        // set the proper version of bulb
                        bulb.Product = receivebytes[40];
                    }
                }
            }
            // seperating the 2 seems more reliable
            foreach (var bulb in Bulbs)
            {
                    a = new UdpClient();
                    a.Connect(_sendingEndPoint);
                    // Send zone request
                    sendData = Utils.StringToByteArray(PacketFactory.GetPacket(Utils.StringToByteArray(bulb.MacAddress + "0000"), ColourZonesPayload));
                    a.Send(sendData, sendData.Length);
                    a.Close();

                    //_sendingSocket.SendTo(sendData, _sendingEndPoint);

                    Thread.Sleep(1000);

                    while (_receivingUdpClient.Available > 0)
                    {
                        receivebytes = _receivingUdpClient.Receive(ref remoteIpEndPoint);
                        if (receivebytes[0] == 46)
                        {
                            // set the zones count of bulb
                            bulb.Zones = receivebytes[36];
                        }
                    }
            }

            _receivingUdpClient.Close();
        }

        // The following is taken verbatim from https://github.com/PhilWheat/LIFX-Control
        public void SetupNetwork()
        {
            var pos = _localIp.LastIndexOf('.');
            if (pos >= 0)
                _localIp = _localIp.Substring(0, pos);
            _localIp = _localIp + ".255";
            // Set up UDP connection
            //_sendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            SetupNetwork(_localIp);

        }

        private void SetupNetwork(string ip)
        {
            _localIp = ip;
            _sendToAddress = IPAddress.Parse(ip);
            _sendingEndPoint = new IPEndPoint(_sendToAddress, 56700);
        }
    }
}
