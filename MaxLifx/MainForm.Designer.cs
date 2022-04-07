﻿namespace MaxLifx
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbBulbs = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbManualBulbMac = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.lvThreads = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelBulbColours = new System.Windows.Forms.Panel();
            this.gbMonitors = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bulbsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.turnOnAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOffAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.advancedDiscoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.gbMonitors.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbBulbs
            // 
            this.lbBulbs.FormattingEnabled = true;
            this.lbBulbs.Location = new System.Drawing.Point(15, 19);
            this.lbBulbs.Name = "lbBulbs";
            this.lbBulbs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbBulbs.Size = new System.Drawing.Size(188, 147);
            this.lbBulbs.TabIndex = 2;
            this.lbBulbs.SelectedIndexChanged += new System.EventHandler(this.lbBulbs_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbManualBulbMac);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.lbBulbs);
            this.groupBox3.Location = new System.Drawing.Point(757, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 227);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bulbs";
            this.groupBox3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Add Manual / Virtual Bulb";
            // 
            // tbManualBulbMac
            // 
            this.tbManualBulbMac.Location = new System.Drawing.Point(15, 192);
            this.tbManualBulbMac.Name = "tbManualBulbMac";
            this.tbManualBulbMac.Size = new System.Drawing.Size(125, 20);
            this.tbManualBulbMac.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(146, 191);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Add";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Salmon;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(271, 125);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(136, 40);
            this.button7.TabIndex = 35;
            this.button7.Text = "Remove lights";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lvThreads
            // 
            this.lvThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvThreads.HideSelection = false;
            this.lvThreads.Location = new System.Drawing.Point(6, 19);
            this.lvThreads.MultiSelect = false;
            this.lvThreads.Name = "lvThreads";
            this.lvThreads.Size = new System.Drawing.Size(257, 174);
            this.lvThreads.TabIndex = 36;
            this.lvThreads.UseCompatibleStateImageBehavior = false;
            this.lvThreads.View = System.Windows.Forms.View.Details;
            this.lvThreads.SelectedIndexChanged += new System.EventHandler(this.lvThreads_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "UUID";
            this.columnHeader2.Width = 184;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(271, 72);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(136, 47);
            this.button8.TabIndex = 37;
            this.button8.Text = "Edit lights";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(271, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Ambient Lights";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 38;
            this.button2.Text = "Save Threadset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(271, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 23);
            this.button3.TabIndex = 39;
            this.button3.Text = "Load Threadset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelBulbColours
            // 
            this.panelBulbColours.AutoScroll = true;
            this.panelBulbColours.Location = new System.Drawing.Point(7, 19);
            this.panelBulbColours.Name = "panelBulbColours";
            this.panelBulbColours.Size = new System.Drawing.Size(395, 133);
            this.panelBulbColours.TabIndex = 46;
            // 
            // gbMonitors
            // 
            this.gbMonitors.Controls.Add(this.panelBulbColours);
            this.gbMonitors.Location = new System.Drawing.Point(9, 237);
            this.gbMonitors.Name = "gbMonitors";
            this.gbMonitors.Size = new System.Drawing.Size(413, 164);
            this.gbMonitors.TabIndex = 53;
            this.gbMonitors.TabStop = false;
            this.gbMonitors.Text = "Bulb Monitors";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bulbsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 58;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bulbsToolStripMenuItem
            // 
            this.bulbsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.turnOnAllToolStripMenuItem,
            this.turnOffAllToolStripMenuItem,
            this.panicToolStripMenuItem,
            this.toolStripSeparator2,
            this.advancedDiscoverToolStripMenuItem});
            this.bulbsToolStripMenuItem.Name = "bulbsToolStripMenuItem";
            this.bulbsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.bulbsToolStripMenuItem.Text = "Bulbs";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.toolStripMenuItem1.Text = "Discover";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // turnOnAllToolStripMenuItem
            // 
            this.turnOnAllToolStripMenuItem.Name = "turnOnAllToolStripMenuItem";
            this.turnOnAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.turnOnAllToolStripMenuItem.Text = "Turn On All";
            this.turnOnAllToolStripMenuItem.Click += new System.EventHandler(this.turnOnAllToolStripMenuItem_Click);
            // 
            // turnOffAllToolStripMenuItem
            // 
            this.turnOffAllToolStripMenuItem.Name = "turnOffAllToolStripMenuItem";
            this.turnOffAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.turnOffAllToolStripMenuItem.Text = "Turn Off All";
            this.turnOffAllToolStripMenuItem.Click += new System.EventHandler(this.turnOffAllToolStripMenuItem_Click);
            // 
            // panicToolStripMenuItem
            // 
            this.panicToolStripMenuItem.Name = "panicToolStripMenuItem";
            this.panicToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.panicToolStripMenuItem.Text = "Panic";
            this.panicToolStripMenuItem.Click += new System.EventHandler(this.panicToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(172, 6);
            // 
            // advancedDiscoverToolStripMenuItem
            // 
            this.advancedDiscoverToolStripMenuItem.Name = "advancedDiscoverToolStripMenuItem";
            this.advancedDiscoverToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.advancedDiscoverToolStripMenuItem.Text = "Advanced Discover";
            this.advancedDiscoverToolStripMenuItem.Click += new System.EventHandler(this.advancedDiscoverToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "MaxLifx-Z minimised to System Tray";
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lvThreads);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Location = new System.Drawing.Point(9, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 200);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Running Lights";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbMonitors);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(450, 505);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MaxLifx-Z";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbMonitors.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbBulbs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListView lvThreads;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelBulbColours;
        private System.Windows.Forms.GroupBox gbMonitors;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bulbsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnOnAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnOffAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbManualBulbMac;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem advancedDiscoverToolStripMenuItem;
    }
}

