using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using MaxLifx.Controllers;
using MaxLifx.Controls;
using MaxLifx.Payload;
using MaxLifx.Threads;
using MaxLifx.UIs;
using Newtonsoft.Json;

namespace MaxLifx
{

    public partial class MainForm : Form
    {
        private readonly MaxLifxBulbController _bulbController = new MaxLifxBulbController();
        Dictionary<string, LightControlThread> _threads = new Dictionary<string, LightControlThread>();
        private readonly Random _r = new Random();
        public MainForm()
        {

            InitializeComponent();
            _bulbController.SetupNetwork();
            
            // try and load settings
            if (File.Exists("settings.json"))
            {
                LoadSettings();
            }

            if (_bulbController.Bulbs.Count == 0)
            {
                var dialogResult =
                    MessageBox.Show(
                        "No bulbs discovered. Run bulb discovery now? The app willl hang for about ten seconds."
                        , "Discover bulbs?",
                        MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    _bulbController.DiscoverBulbs();

                    if (_bulbController.Bulbs.Count == 0)
                    {
                        MessageBox.Show("No bulbs found. If you have just received a Windows Firewall popup, try Bulbs -> Discover Bulbs now.");
                    }

                    SaveSettings();

                }
            }

            if (File.Exists("default.json"))
            {
                StopAllThreads();
                LoadThreads("default.json");
            }
            Text = "MaxLifx-Z (" + _bulbController.Bulbs.Count.ToString() + ")";
        }



        private void StartNewThread(Thread thread, string threadName, ScreenColourProcessor processor)
        {
            var NewLightControlThread = new LightControlThread(thread, threadName, processor);
            _threads.Add(NewLightControlThread.Uuid, NewLightControlThread);

            var lvi = new ListViewItem(NewLightControlThread.Name);
            lvi.SubItems.Add(NewLightControlThread.Uuid);
            lvThreads.Items.Add(lvi);
            NewLightControlThread.Start();
        }

        private void LoadSettings(string filename = "settings.json")
        {
            var Bulbs = JsonConvert.DeserializeObject<List<Bulb>>(File.ReadAllText(filename));
            _bulbController.Bulbs = Bulbs;
            Text = "MaxLifx-Z (" + _bulbController.Bulbs.Count.ToString() + ")";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var processor = new ScreenColourProcessor();
            processor.ShowUI = true;
            var thread = new Thread(() => processor.ScreenColour(_bulbController, new Random(_r.Next())));
            StartNewThread(thread, "Ambient Lights", processor);
        }

        private void SaveThreads(string filename = "threads.json")
        {
            var threads_json = JsonConvert.SerializeObject(_threads);
            File.WriteAllText(filename, threads_json);
        }

        private void LoadThreads(string filename = "threads.json")
        {
            var loaded_threads = JsonConvert.DeserializeObject<Dictionary<string, LightControlThread>>(File.ReadAllText(filename));
            Thread t = null;
            foreach (LightControlThread thread in loaded_threads.Values.ToList())
            {
                t = new Thread(() => ((ScreenColourProcessor)(thread.Processor)).ScreenColour(_bulbController, new Random(_r.Next())));
                StartNewThread(t, thread.Name, thread.Processor);
            }
        }

        private void SaveSettings(string filename = "settings.json")
        {
            var settings_json = JsonConvert.SerializeObject(_bulbController.Bulbs);
            File.WriteAllText(filename, settings_json);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (LightControlThread thread in _threads.Values)
                thread.Abort();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (lvThreads.SelectedItems.Count == 0) return;
            var selectedThreadUuid = lvThreads.SelectedItems[0].SubItems[1].Text;
            if (lvThreads == null) return;
            var thread = _threads[selectedThreadUuid];
            thread.Abort();
            _threads.Remove(selectedThreadUuid);
            lvThreads.Items.Remove(lvThreads.SelectedItems[0]);
        }

        private void lvThreads_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string selectedThreadUuid;
            if (lvThreads.SelectedItems.Count == 0)
            {
                if (lvThreads.Items.Count == 1)
                {
                    selectedThreadUuid = lvThreads.Items[0].SubItems[1].Text;
                }
                else return;
            }
            else selectedThreadUuid = lvThreads.SelectedItems[0].SubItems[1].Text;
            if (lvThreads == null) return;
            var thread = _threads[selectedThreadUuid];
            thread.Processor.ShowUI = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var s = new SaveFileDialog {DefaultExt = ".json"};
            s.Filter = "Json (*.json)|*.json";
            s.InitialDirectory = Directory.GetCurrentDirectory();
            s.AddExtension = true;

            if (s.ShowDialog() == DialogResult.OK)
                SaveThreads(s.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var s = new OpenFileDialog { DefaultExt = ".json" };
            s.Filter = "Json (*.json)|*.json";
            s.InitialDirectory = Directory.GetCurrentDirectory();
            s.AddExtension = true;

            if (s.ShowDialog() == DialogResult.OK) {
                StopAllThreads();
                LoadThreads(s.FileName);
            }
        }

        private void StopAllThreads()
        {
            foreach (LightControlThread thread in _threads.Values)
                thread.Abort();
            _threads.Clear();
            lvThreads.Items.Clear();
        }


        private void TurnAllBulbsOn()
        {
            var p = new SetPowerPayload(true);

            foreach (var b in _bulbController.Bulbs)
            {
                _bulbController.SendPayloadToMacAddress(p, b.MacAddress, b.IpAddress);
                Thread.Sleep(1);
                _bulbController.SendPayloadToMacAddress(p, b.MacAddress, b.IpAddress);
            }
        }


        private void TurnAllBulbsOff()
        {
            var p = new SetPowerPayload(false);

            foreach (var b in _bulbController.Bulbs)
            {
                _bulbController.SendPayloadToMacAddress(p, b.MacAddress, b.IpAddress);
                Thread.Sleep(1);
                _bulbController.SendPayloadToMacAddress(p, b.MacAddress, b.IpAddress);
            }
        }


        private void Panic()
        {
            StopAllThreads();
            TurnAllBulbsOn();

            var c = new SetColourPayload
            {
                Hue = 0,
                Saturation = 0,
                Brightness = 65535,
                Kelvin = 3000,
                TransitionDuration = 1
            };

            foreach (var b in _bulbController.Bulbs)
            {
                _bulbController.SendPayloadToMacAddress(c, b.MacAddress, b.IpAddress);
                Thread.Sleep(1);
                _bulbController.SendPayloadToMacAddress(c, b.MacAddress, b.IpAddress);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                TurnAllBulbsOn();
            }
            catch { }
        }

        private void turnOnAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TurnAllBulbsOn();
        }

        private void turnOffAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TurnAllBulbsOff();
        }

        private void panicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panic();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _bulbController.DiscoverBulbs();

            if (_bulbController.Bulbs.Count == 0)
            {
                MessageBox.Show("No bulbs found. If you have just received a Windows Firewall popup, try Bulbs -> Discover Bulbs now.");
            }

            Text = "MaxLifx-Z (" + _bulbController.Bulbs.Count.ToString() + ")";

            SaveSettings();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseClick(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(sender, e);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(sender, e);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(sender, e);
        }

        private void knobControl1_ValueChanged(object Sender)
        {
            foreach (LightControlThread thread in _threads.Values)
            {
                float val = knobControl1.Value;
                thread.Processor.SettingsCast.GlobalBrightness = (val / 100);
            }
        }

        private void knobControl2_ValueChanged(object Sender)
        {
            foreach (LightControlThread thread in _threads.Values)
            {
                float val = knobControl2.Value;
                thread.Processor.SettingsCast.GlobalUpdateRate = (val / 20);
            }
        }
    }
}