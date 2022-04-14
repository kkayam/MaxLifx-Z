﻿using MaxLifx.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MaxLifx
{
    public partial class AssignAreaToBulbForm : Form
    {
        public List<LabelAndLocationType> LabelsAndLocations;
        public LabelAndLocationType SelectedLabelAndLocation;
        private bool _suspendUi;

        public AssignAreaToBulbForm(List<LabelAndLocationType> labelsAndLocations)
        {
            LabelsAndLocations = labelsAndLocations;
            InitializeComponent();
            foreach (var l in LabelsAndLocations.OrderBy(x => x.Label))
                lbBulbs.Items.Add(l.Label);

            foreach (var v in Enum.GetNames(typeof(ScreenLocation)).OrderBy(x => x))
                cbArea.Items.Add(v);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbBulbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suspendUi) return;
            _suspendUi = true;
            if (lbBulbs.SelectedItem == null)
            {
                cbArea.Enabled = false;
                return;
            }

            SelectedLabelAndLocation =
                LabelsAndLocations.Single(x => x.Label == (((ListBox)sender).SelectedItem.ToString()));

            foreach (var v in cbArea.Items)
                if (v.ToString() == Enum.GetName(typeof(ScreenLocation), SelectedLabelAndLocation.ScreenLocation))
                    cbArea.SelectedItem = v;

            cbArea.Enabled = true;

            _suspendUi = false;
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suspendUi) return;
            _suspendUi = true;

            LabelsAndLocations.Remove(LabelsAndLocations.Single(x => x.Label == SelectedLabelAndLocation.Label));
            var l = new LabelAndLocationType();
            l.Label = SelectedLabelAndLocation.Label;
            l.Zones = SelectedLabelAndLocation.Zones;
            l.ScreenLocation =
                (ScreenLocation)(Enum.Parse(typeof(ScreenLocation), ((ComboBox)sender).SelectedItem.ToString()));
            LabelsAndLocations.Add(l);
            _suspendUi = false;
        }
    }
}