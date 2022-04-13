﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;
using System.Windows.Forms;
using MaxLifx.Controllers;
using MaxLifx.Payload;
using MaxLifx.Processors.ProcessorSettings;
using MaxLifx.Threads;
using MaxLifx.UIs;

namespace MaxLifx
{
    public class ScreenColourProcessor : ProcessorBase
    {
        public Dictionary<string, List<Rectangle>> ZoneAreas = new Dictionary<string, List<Rectangle>>();
        private Point TopLeft { get; set; }
        private Point BottomRight { get; set; }

        [XmlIgnore]
        public ScreenColourSettings SettingsCast => ((ScreenColourSettings) Settings);

        public override ISettings Settings { get; set; }

        public override string SettingsAsXml
        {
            get { return ((ScreenColourSettings) (Settings)).ToXmlString(); }
            set
            {
                ScreenColourSettings s;

                using (var st = new StringReader(value))
                {
                    s = (ScreenColourSettings) (new XmlSerializer(typeof (ScreenColourSettings)).Deserialize(st));
                }

                Settings = s;
            }
        }


        public void ScreenColour(MaxLifxBulbController bulbController, Random random)
        {
            var frames = 0;
            var start = DateTime.Now;

            if (Settings == null)
            {
                Settings = new ScreenColourSettings();
            }

            foreach (var bulb in bulbController.Bulbs.Select(x => x))
            {
                if (!SettingsCast.LabelsAndLocations.Select(x => x.Label).Contains(bulb.Label))
                {
                    // populating SettingsCast fields
                    var l = new LabelAndLocationType();
                    l.Label = bulb.Label;
                    l.ScreenLocation = ScreenLocation.All;
                    l.Zones = bulb.Zones;
                    // default to None if more than 1 zone, so that can proper setup
                    if (bulb.Zones > 1)
                    {
                        l.ScreenLocation = ScreenLocation.None;
                        // if multizone enabled keep track of number of zones
                        SettingsCast.MultiColourZones.Add(bulb.Zones);
                    }
                    SettingsCast.LabelsAndLocations.Add(l);
                }
            }

            while (!TerminateThread)
            {
                // check if area has changed
                if (TopLeft == SettingsCast.TopLeft && BottomRight == SettingsCast.BottomRight)
                {
                    DoMainLoop(bulbController, ref frames, start);
                }
                else
                {
                    // if it has changed then recalculate zones and set
                    zoneCalculation();
                    TopLeft = SettingsCast.TopLeft;
                    BottomRight = SettingsCast.BottomRight;
                }
            }
        }
        private void zoneCalculation()
        {
            // getting a rectangle based on the Settings area
            var size = new Size(SettingsCast.BottomRight.X - SettingsCast.TopLeft.X, SettingsCast.BottomRight.Y - SettingsCast.TopLeft.Y);
            var rect = new Rectangle(SettingsCast.TopLeft, size);

            // can also just get screen from point, but should be less ambiguity with a rectangle
            var bounds = Screen.FromRectangle(rect).Bounds;

            // the optimal measurement for the starting zone would be the start of the strip to the 0.3cm past the last led
            // since there is about 1.3cm space from the start of the strip to first led
            // and about 1.6cm space between last led in zone and first led in new zone (of same strip)
            // the distance between last led in strip and first led in next strip is about 1.9cm
            // but YMMV

            // want the original edge to determine when to swap width and height
            int originalEdge = closestEdge(ref rect, bounds);

            // split up the monitor into zones; repeat for each multizone light that has different number of zones
            foreach (int zoneNumber in SettingsCast.MultiColourZones.ToList())
            {
                // TODO:
                // condense and simplify the steps below to avoid repeating all this duplicate stuff for each edge and direction
                // but today is not the day for me to figure that out; I'm just happy to get this working for now

                
                var rectList = new List<Rectangle>();
                var tempRect = rect;
                int currentEdge = originalEdge;
                // add starting zone
                rectList.Add(rect);
                // for clockwise
                for (int i = 1; i < zoneNumber; i++)
                {
                    int height = rect.Height;
                    int width = rect.Width;
                    // if started out on adjacent edge, swap width and height
                    if (originalEdge % 2 != currentEdge % 2)
                    {
                        width = rect.Height;
                        height = rect.Width;
                    }
                    switch (currentEdge)
                    {
                        case 0:
                            // check if enough space to fit the full area
                            if (tempRect.Top - height > bounds.Top)
                            {
                                tempRect = new Rectangle(bounds.X, tempRect.Top - height, width, height);
                                rectList.Add(tempRect);
                            }
                            else
                            {
                                // need to split zone with the next edge
                                int currentBound = tempRect.Top;
                                int nextBound = height - currentBound;
                                // make sure to use proper area for next calculation, but don't add to list
                                tempRect = new Rectangle(bounds.X, bounds.Y, nextBound, currentBound);
                                Rectangle tempRect2 = tempRect;
                                // next edge
                                currentEdge = (currentEdge + 1) % 4;
                                // add a "full size" area, depending on which edge has more of the zones left
                                if (currentBound > nextBound && nextBound < width)
                                {
                                    tempRect2 = new Rectangle(bounds.X, bounds.Y, width, currentBound);
                                }
                                else if (nextBound >= currentBound && currentBound < width)
                                {
                                    tempRect2 = new Rectangle(bounds.X, bounds.Y, nextBound, width);
                                }
                                rectList.Add(tempRect2);
                            }
                            break;
                        case 1:
                            if (tempRect.Right + width < bounds.Right)
                            {
                                tempRect = new Rectangle(tempRect.Right, bounds.Y, width, height);
                                rectList.Add(tempRect);
                            }
                            else
                            {
                                int currentBound = bounds.Right - tempRect.Right;
                                int nextBound = width - currentBound;
                                tempRect = new Rectangle(tempRect.Right, tempRect.Top, currentBound, nextBound);
                                Rectangle tempRect2 = tempRect;
                                currentEdge = (currentEdge + 1) % 4;
                                if (currentBound > nextBound && nextBound < height)
                                {
                                    tempRect2 = new Rectangle(tempRect.Right, tempRect.Top, currentBound, height);
                                }
                                else if (nextBound >= currentBound && currentBound < height)
                                {
                                    tempRect2 = new Rectangle(bounds.Right - height, tempRect.Top, height, nextBound);
                                }
                                rectList.Add(tempRect2);
                            }
                            break;
                        case 2:
                            if (tempRect.Bottom + height < bounds.Bottom)
                            {
                                tempRect = new Rectangle(bounds.Right - width, tempRect.Bottom, width, height);
                                rectList.Add(tempRect);
                            }
                            else
                            {
                                int currentBound = bounds.Bottom - tempRect.Bottom;
                                int nextBound = height - currentBound;
                                tempRect = new Rectangle(bounds.Right - nextBound, tempRect.Bottom, nextBound, currentBound);
                                Rectangle tempRect2 = tempRect;
                                currentEdge = (currentEdge + 1) % 4;
                                if (currentBound > nextBound && nextBound < width)
                                {
                                    tempRect2 = new Rectangle(bounds.Right - width, tempRect.Bottom, width, currentBound);
                                }
                                else if (nextBound >= currentBound && currentBound < width)
                                {
                                    tempRect2 = new Rectangle(bounds.Right - nextBound, bounds.Bottom - width, nextBound, width);
                                }
                                rectList.Add(tempRect2);
                            }
                            break;
                        case 3:
                            if (tempRect.Left - width > bounds.Left)
                            {
                                tempRect = new Rectangle(tempRect.Left - width, bounds.Bottom - height, width, height);
                                rectList.Add(tempRect);
                            }
                            else
                            {
                                int currentBound = tempRect.Left;
                                int nextBound = width - currentBound;
                                tempRect = new Rectangle(bounds.X, bounds.Bottom - nextBound, currentBound, nextBound);
                                Rectangle tempRect2 = tempRect;
                                currentEdge = (currentEdge + 1) % 4;
                                if (currentBound > nextBound && nextBound < height)
                                {
                                    tempRect2 = new Rectangle(bounds.X, bounds.Bottom - height, currentBound, height);
                                }
                                else if (nextBound >= currentBound && currentBound < height)
                                {
                                    tempRect2 = new Rectangle(bounds.X, bounds.Bottom - nextBound, height, nextBound);
                                }
                                rectList.Add(tempRect2);
                            }
                            break;
                    }

                }
                // clockwise dictionary
                ZoneAreas[zoneNumber.ToString() + "cw"] = rectList;

                // one more time for counterclockwise
                rectList = new List<Rectangle>();
                tempRect = rect;
                currentEdge = originalEdge;
                rectList.Add(rect);
                for (int i = 1; i < zoneNumber; i++)
                {
                    int height = rect.Height;
                    int width = rect.Width;
                    // if started out on adjacent edge, swap width and height
                    if (originalEdge % 2 != currentEdge % 2)
                    {
                        width = rect.Height;
                        height = rect.Width;
                    }
                    switch (currentEdge)
                    {
                        case 0:
                            // check if enough space to fit the full area
                            if (tempRect.Bottom + height < bounds.Bottom)
                            {
                                tempRect = new Rectangle(bounds.X, tempRect.Bottom, width, height);
                                rectList.Add(tempRect);
                            }
                            else
                            {
                                // need to split zone with the next edge
                                int currentBound = bounds.Bottom - tempRect.Bottom;
                                int nextBound = height - currentBound;
                                // make sure to use proper area for next calculation, but don't add to list
                                tempRect = new Rectangle(bounds.X, bounds.Bottom - currentBound, nextBound, currentBound);
                                Rectangle tempRect2 = tempRect;
                                // next edge
                                currentEdge = 3;
                                if (currentBound > nextBound && nextBound < width)
                                {
                                    // add a "full size" area, dependin on which edge has more of the zones left
                                    tempRect2 = new Rectangle(bounds.X, bounds.Bottom - currentBound, width, currentBound);
                                }
                                else if (nextBound >= currentBound && currentBound < width)
                                {
                                    tempRect2 = new Rectangle(bounds.X, bounds.Bottom - width, nextBound, width);
                                }
                                rectList.Add(tempRect2);
                            }
                            break;
                        case 1:
                            if (tempRect.Left - width > bounds.Left)
                            {
                                tempRect = new Rectangle(tempRect.Left - width, bounds.Y, width, height);
                                rectList.Add(tempRect);
                            }
                            else
                            {
                                int currentBound = tempRect.Left;
                                int nextBound = width - currentBound;
                                tempRect = new Rectangle(bounds.Left, bounds.Top, currentBound, nextBound);
                                Rectangle tempRect2 = tempRect;
                                currentEdge = 0;
                                if (currentBound > nextBound && nextBound < height)
                                {
                                    tempRect2 = new Rectangle(bounds.Left, bounds.Top, currentBound, height);
                                }
                                else if (nextBound >= currentBound && currentBound < height)
                                {
                                    tempRect2 = new Rectangle(bounds.Left, bounds.Top, height, nextBound);
                                }
                                rectList.Add(tempRect2);
                            }
                            break;
                        case 2:
                            if (tempRect.Top - height > bounds.Top)
                            {
                                tempRect = new Rectangle(bounds.Right - width, tempRect.Top - height, width, height);
                                rectList.Add(tempRect);
                            }
                            else
                            {
                                int currentBound = tempRect.Top;
                                int nextBound = height - currentBound;
                                tempRect = new Rectangle(bounds.Right - nextBound, tempRect.Top, nextBound, currentBound);
                                Rectangle tempRect2 = tempRect;
                                currentEdge = 1;
                                if (currentBound > nextBound && nextBound < width)
                                {
                                    tempRect2 = new Rectangle(bounds.Right - width, bounds.Top, width, currentBound);
                                }
                                else if (nextBound >= currentBound && currentBound < width)
                                {
                                    tempRect2 = new Rectangle(bounds.Right - nextBound, bounds.Top, nextBound, width);
                                }
                                rectList.Add(tempRect2);
                            }
                            break;
                        case 3:
                            if (tempRect.Right + width < bounds.Right)
                            {
                                tempRect = new Rectangle(tempRect.Right, bounds.Bottom - height, width, height);
                                rectList.Add(tempRect);
                            }
                            else
                            {
                                int currentBound = bounds.Right - tempRect.Right;
                                int nextBound = width - currentBound;
                                tempRect = new Rectangle(bounds.Right - currentBound, bounds.Bottom - nextBound, currentBound, nextBound);
                                Rectangle tempRect2 = tempRect;
                                currentEdge = 2;
                                if (currentBound > nextBound && nextBound < height)
                                {
                                    tempRect2 = new Rectangle(bounds.Right - currentBound, bounds.Bottom - height, currentBound, height);
                                }
                                else if (nextBound >= currentBound && currentBound < height)
                                {
                                    tempRect2 = new Rectangle(bounds.Right - height, bounds.Bottom - nextBound, height, nextBound);
                                }
                                rectList.Add(tempRect2);
                            }
                            break;
                    }
                }
                // counterclockwise dictionary
                ZoneAreas[zoneNumber.ToString() + "ccw"] = rectList;
            }
        }
        private int closestEdge(ref Rectangle rect, Rectangle bounds)
        {
            int[] boundsDistance = new int[4];
            boundsDistance[0] = Math.Abs(rect.Left - bounds.Left);
            boundsDistance[1] = Math.Abs(rect.Top - bounds.Top);
            boundsDistance[2] = Math.Abs(rect.Right - bounds.Right);
            boundsDistance[3] = Math.Abs(rect.Bottom - bounds.Bottom);

            for (int i = 0; i < boundsDistance.Length; i++)
            {
                // allow some error when selecting the area; it's hard to get it exact
                if (boundsDistance[i] <= 20)
                {
                    boundsDistance[i] = 0;
                }
            }
            // see if there are multiple closest edges
            int[] minDistance = boundsDistance.Select((v, j) => new {
                value = v,
                index = j
            }).Where(pair => pair.value == boundsDistance.Min())
              .Select(pair => pair.index)
              .ToArray();
            int edge = minDistance.Max();
            // if the box is in a corner then need to decide which is starting edge
            // best guess is that the longer side will be the starting edge
            // if width is longer, then we're starting either top or bottom
            if (rect.Width >= rect.Height)
            {
                if (minDistance.Contains(3))
                {
                    edge = 3;
                    // make sure starts at border
                    rect.Y = bounds.Bottom - rect.Height;
                }
                else if (minDistance.Contains(1))
                {
                    edge = 1;
                    rect.Y = bounds.Top;
                }
            }
            else
            {
                // if height is longer, than we're starting either left or right
                if (minDistance.Contains(0))
                {
                    edge = 0;
                    // make sure starts at border
                    rect.X = bounds.Left;
                }
                else if (minDistance.Contains(2))
                {
                    edge = 2;
                    rect.X = bounds.Right - rect.Height;
                }
            }
            return edge;
        }

        // this is where the actual colours are determined and set for the bulbs
        private void DoMainLoop(MaxLifxBulbController bulbController, ref int frames, DateTime start)
        {
            if (ShowUI)
            {
                var t = new Thread(() =>
                {
                    var form2 = new ScreenColourUI(SettingsCast, bulbController); /* (SettingsCast, bulbController.Bulbs);*/
                    form2.ShowDialog();
                });
                t.Start();
                ShowUI = false;
            }

            frames++;
            // determine colours on screen
            // var screenColourSet = GetScreenColours(SettingsCast.TopLeft, SettingsCast.BottomRight, screenPixel, gdest, gsrc);
            Color? avgColour = null;
            ScreenColorSet screenColourSet = null;
            Color areaColour;

            foreach (var label in SettingsCast.SelectedLabels)
                {
                    var multiFlag = false;
                    var labelsAndLocations = SettingsCast.LabelsAndLocations.Single(x => x.Label == label);
                    var location = labelsAndLocations.ScreenLocation;
                    var zones = labelsAndLocations.Zones;
                    // skip if set to None
                    if (location == ScreenLocation.None)
                    {
                        continue;
                    }
                if (zones > 1)
                {
                    List<Rectangle> rectList = null;
                    bool found = false;
                    // try and grab the zones
                    switch (location)
                    {
                        case ScreenLocation.SurroundCounterClockwise:
                            found = ZoneAreas.TryGetValue(zones.ToString() + "ccw", out rectList);
                            break;
                        case ScreenLocation.SurroundClockwise:
                            found = ZoneAreas.TryGetValue(zones.ToString() + "cw", out rectList);
                            break;
                         // for all other ScreenLocations we skip
                    }
                    if (found)
                    {

                        // our average colour pixel
                        var screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
                        var gfx = Graphics.FromImage(screenshot);
                        gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.Location, new Point(0, 0), Screen.PrimaryScreen.Bounds.Size);


                        UInt16[] Hue_list = new UInt16[82];
                        UInt16[] Saturation_list = new UInt16[82];
                        UInt16[] Brightness_list = new UInt16[82];
                        UInt16[] Kelvin_list = new UInt16[82];

                        // Which bulb type we're dealing with, if we should use extended messages
                        var ProductType = bulbController.Bulbs.Single(x => x.Label == label).Product;

                        for (int i = 0; i < zones; i++)
                        {
                            Bitmap CroppedImage = new Bitmap(rectList[i].Width, rectList[i].Height);
                            using (Graphics g = Graphics.FromImage(CroppedImage))
                            {
                                g.DrawImage(screenshot, -rectList[i].X, -rectList[i].Y);
                            }
                            areaColour = GetAverageColor(CroppedImage,5);

                            if (areaColour != null)
                            {
                                if (ProductType == 32 || ProductType == 38)
                                {
                                    Color avgZoneColour = (Color)areaColour;
                                    // Color isn't HSV, so need to convert
                                    double hue = 0;
                                    double saturation = 0;
                                    double brightness = 0;
                                    Utils.ColorToHSV((Color)avgZoneColour, out hue, out saturation, out brightness);
                                    brightness = (brightness * (SettingsCast.Brightness - SettingsCast.MinBrightness)) * SettingsCast.GlobalBrightness;
                                    saturation = (saturation * (SettingsCast.Saturation - SettingsCast.MinSaturation));
                                    Hue_list[i] = (UInt16)hue;
                                    Saturation_list[i] = (UInt16)saturation;
                                    Brightness_list[i] = (UInt16)brightness;
                                    Kelvin_list[i] = (UInt16)SettingsCast.Kelvin;
                                } else
                                {
                                    Color avgZoneColour = (Color)areaColour;
                                    // Color isn't HSV, so need to convert
                                    double hue = 0;
                                    double saturation = 0;
                                    double brightness = 0;
                                    Utils.ColorToHSV((Color)avgZoneColour, out hue, out saturation, out brightness);
                                    brightness = (brightness * (SettingsCast.Brightness - SettingsCast.MinBrightness) + SettingsCast.MinBrightness) * SettingsCast.GlobalBrightness;
                                    saturation = (saturation * (SettingsCast.Saturation - SettingsCast.MinSaturation) + SettingsCast.MinSaturation);
                                    var zonePayload = new SetColourZonesPayload
                                    {
                                        start_index = new byte[1] { (byte)(i) },
                                        end_index = new byte[1] { (byte)(i) },
                                        Kelvin = (ushort)SettingsCast.Kelvin,
                                        TransitionDuration = (uint)(SettingsCast.Fade),
                                        Hue = (int)hue,
                                        Saturation = (ushort)saturation,
                                        Brightness = (ushort)brightness,
                                        // 0 for delayed apply; 1 for immediate (don't wait for other zones);
                                        apply = new byte[1] { 1 }
                                    };
                                    // send
                                    bulbController.SetColour(label, zonePayload, false);
                                }
                            }
                        }
                        if (ProductType == 32 || ProductType == 38)
                        {
                            var zonePayload = new SetExtendedColourZonesPayload
                            {
                                start_index_16 = (UInt16)0,
                                TransitionDuration = (uint)(SettingsCast.Fade),
                                color_count = (byte)zones,
                                Hue_list = Hue_list,
                                Saturation_list = Saturation_list,
                                Brightness_list = Brightness_list,
                                Kelvin_list = Kelvin_list,
                                apply = new byte[1] { 1 }
                            };
                            bulbController.SetColour(label, zonePayload, false);

                        }

                        multiFlag = true;
                    }
                }
                // only do this calc if necessary
                if (!multiFlag)
                {
                    // set once

                    var screenPixel = new Bitmap(2, 2, PixelFormat.Format32bppArgb);
                    var gdest = Graphics.FromImage(screenPixel);
                    var gsrc = Graphics.FromHwnd(IntPtr.Zero);
                    screenColourSet = GetScreenColours(SettingsCast.TopLeft, SettingsCast.BottomRight, screenPixel, gdest, gsrc);
                    // default is all
                    avgColour = screenColourSet.all;
                    switch (location)
                    {
                        case ScreenLocation.Top:
                            avgColour = screenColourSet.top;
                            break;
                        case ScreenLocation.Bottom:
                            avgColour = screenColourSet.bottom;
                            break;
                        case ScreenLocation.Left:
                            avgColour = screenColourSet.left;
                            break;
                        case ScreenLocation.Right:
                            avgColour = screenColourSet.right;
                            break;
                        case ScreenLocation.TopLeft:
                            avgColour = screenColourSet.topleft;
                            break;
                        case ScreenLocation.TopRight:
                            avgColour = screenColourSet.topright;
                            break;
                        case ScreenLocation.BottomLeft:
                            avgColour = screenColourSet.bottomleft;
                            break;
                        case ScreenLocation.BottomRight:
                            avgColour = screenColourSet.bottomright;
                            break;
                    }
                    // Color isn't HSV, so need to convert
                    double hue = 0;
                    double saturation = 0;
                    double brightness = 0;
                    Utils.ColorToHSV((Color)avgColour, out hue, out saturation, out brightness);
                    brightness = (brightness * (SettingsCast.Brightness - SettingsCast.MinBrightness) + SettingsCast.MinBrightness) * SettingsCast.GlobalBrightness;
                    saturation = (saturation * (SettingsCast.Saturation - SettingsCast.MinSaturation) + SettingsCast.MinSaturation);
                    var payload = new SetColourPayload
                    {
                        Kelvin = (ushort)SettingsCast.Kelvin,
                        TransitionDuration = (uint)(SettingsCast.Fade),
                        Hue = (int)hue,
                        Saturation = (ushort)saturation,
                        Brightness = (ushort)brightness
                    };
                    bulbController.SetColour(label, payload, true);
                }
            }

            float delay = 1000 / Math.Min(SettingsCast.Delay * SettingsCast.GlobalUpdateRate+1, 20);
            Thread.Sleep((int)Math.Round(delay));
        }

        #region

        //[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        //private static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc,
        //    int ySrc, int dwRop);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int StretchBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int nWidthSrc, int nHeightSrc, int dwRop);

        /// <summary>
        /// SetStretchBltMode
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool SetStretchBltMode(IntPtr hObject, int nStretchMode);
        private class ScreenColorSet
        {
            public Color topleft, topright, bottomleft, bottomright, left, right, top, bottom, all;
        }
        public unsafe Color GetAverageColor(Bitmap image, int sampleStep = 1)
        {
            var data = image.LockBits(
                new Rectangle(Point.Empty, image.Size),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            var row = (int*)data.Scan0.ToPointer();
            var (sumR, sumG, sumB) = (0L, 0L, 0L);
            var stride = data.Stride / sizeof(int) * sampleStep;

            for (var y = 0; y < data.Height; y += sampleStep)
            {
                for (var x = 0; x < data.Width; x += sampleStep)
                {
                    var argb = row[x];
                    sumR += (argb & 0x00FF0000) >> 16;
                    sumG += (argb & 0x0000FF00) >> 8;
                    sumB += argb & 0x000000FF;
                }
                row += stride;
            }

            image.UnlockBits(data);

            var numSamples = data.Width / sampleStep * data.Height / sampleStep;
            var avgR = Math.Min(sumR / numSamples,255);
            var avgG = Math.Min(sumG / numSamples,255);
            var avgB = Math.Min(sumB / numSamples,255);
            return Color.FromArgb((int)avgR, (int)avgG, (int)avgB);
        }

        private unsafe ScreenColorSet GetScreenColours(Point tl, Point br, Bitmap screenPixel, Graphics gdest, Graphics gsrc)
        {
            IntPtr hSrcDC;
            IntPtr hDC;

            var width = br.X - tl.X;
            if (width < 0)
                width = 0 - width;

            var height = br.Y - tl.Y;
            if (height < 0)
                height = 0 - height;

            if (height == 0 || width == 0) return null;

            //var realtlx = 50;//tl.X < br.X ? tl.X : br.X;
            //var realtly = 50;//tl.Y < br.Y ? tl.Y : br.Y;
            Color topleft, bottomleft, topright, bottomright, top, bottom, left, right, all;
            ScreenColorSet returnValue;
            var thumbSize = new Size(2,2);

                        hSrcDC = gsrc.GetHdc();
                        hDC = gdest.GetHdc();
                        //var retval = BitBlt(hDC, 0, 0, width, height, hSrcDC, 0, 0,
                        //    (int) CopyPixelOperation.SourceCopy);
                        SetStretchBltMode(hDC, 0x04);
                        StretchBlt(hDC, 0, 0, thumbSize.Width, thumbSize.Height, hSrcDC, tl.X, tl.Y, width, height, 
                            (int)CopyPixelOperation.SourceCopy);
                        
                        gdest.ReleaseHdc();
                        gsrc.ReleaseHdc();
                //screenPixel.Save("Pics\\" + DateTime.Now.ToString("hhmmss").Replace("/", "").Replace(":", "") + ".bmp");
                var srcData = screenPixel.LockBits(
                    new Rectangle(0, 0, screenPixel.Width, screenPixel.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format32bppArgb);

                var stride = srcData.Stride;

                var scan0 = srcData.Scan0;

                var p = (byte*) (void*) scan0;

                topleft = Color.FromArgb(255,     p[2], p[1], p[0]);
                bottomleft = Color.FromArgb(255,  p[stride + 2], p[stride + 1], p[stride+0]);
                topright = Color.FromArgb(255,    p[4 + 2], p[4 + 1], p[4 + 0]);
                bottomright = Color.FromArgb(255, p[stride+4+2], p[stride + 4 + 1], p[stride + 4 + 0]);

                top = Color.FromArgb(255, (topleft.R + topright.R)/2, (topleft.G + topright.G)/2,
                    (topleft.B + topright.B)/2);
                bottom = Color.FromArgb(255, (bottomleft.R + bottomright.R)/2, (bottomleft.G + bottomright.G)/2,
                    (bottomleft.B + bottomright.B)/2);
                left = Color.FromArgb(255, (topleft.R + bottomleft.R)/2, (topleft.G + bottomleft.G)/2,
                    (topleft.B + bottomleft.B)/2);
                right = Color.FromArgb(255, (bottomright.R + topright.R)/2, (bottomright.G + topright.G)/2,
                    (bottomright.B + topright.B)/2);

                all = Color.FromArgb(255, (top.R + bottom.R)/2, (top.G + bottom.G)/2, (top.B + bottom.B)/2);
                screenPixel.UnlockBits(srcData);
                returnValue = new ScreenColorSet
                {
                    topleft = topleft,
                    topright = topright,
                    top = top,
                    bottomleft = bottomleft,
                    bottomright = bottomright,
                    bottom = bottom,
                    left = left,
                    right = right,
                    all = all
                };

            return returnValue;
        }

        private unsafe Color GetScreenColourZones(Rectangle area, BitmapData srcData, Graphics gdest, Graphics gsrc)
        {
            IntPtr hSrcDC;
            IntPtr hDC;

            var width = area.Width;

            var height = area.Height;
            

            var thumbSize = new Size(1, 1);

            hSrcDC = gsrc.GetHdc();
            hDC = gdest.GetHdc();

            // we are scaling the original image down to a pixel, i.e. average colour
            SetStretchBltMode(hDC, 0x04);
            StretchBlt(hDC, 0, 0, thumbSize.Width, thumbSize.Height, hSrcDC, area.X, area.Y, width, height,
                (int)CopyPixelOperation.SourceCopy);

            gdest.ReleaseHdc();
            gsrc.ReleaseHdc();

            // get the first (and only) pixel
            var scan0 = srcData.Scan0;

            var p = (byte*)(void*)scan0;
            // grab the colours from the pixel
            Color all = Color.FromArgb(255, p[2], p[1], p[0]);
            return all;
        }

        // this is used for dominant colour; it works but it doesn't look very good
        public static Color dominantColour(Bitmap bmp)
        {

            Color MostUsedColor;
            //int MostUsedColorIncidence;

        int pixelColor;

        Dictionary<int, int> dctColorIncidence;

        MostUsedColor = Color.Empty;
            //MostUsedColorIncidence = 0;

            dctColorIncidence = new Dictionary<int, int>();

            // this is what you want to speed up with unmanaged code
            for (int row = 0; row < bmp.Size.Width; row++)
            {
                for (int col = 0; col < bmp.Size.Height; col++)
                {
                    pixelColor = bmp.GetPixel(row, col).ToArgb();

                    if (dctColorIncidence.Keys.Contains(pixelColor))
                    {
                        dctColorIncidence[pixelColor]++;
                    }
                    else
                    {
                        dctColorIncidence.Add(pixelColor, 1);
                    }
                }
            }

            var dctSortedByValueHighToLow = dctColorIncidence.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            MostUsedColor = Color.FromArgb(dctSortedByValueHighToLow.First().Key);
            // MostUsedColorIncidence = dctSortedByValueHighToLow.First().Value;
            return MostUsedColor;
        }
        #endregion
    }


    public class LabelAndLocationType
    {
        public string Label { get; set; }
        public int Zones { get; set; }
        public ScreenLocation ScreenLocation { get; set; }
    }
}