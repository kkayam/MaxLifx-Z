namespace MaxLifx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lvThreads = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulbsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.turnOnAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOffAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.knobControl2 = new MaxLifx.Controls.Knob.KnobControl();
            this.knobControl1 = new MaxLifx.Controls.Knob.KnobControl();
            this.button7 = new MaxLifx.Controls.RoundedButton.RoundedButton();
            this.button1 = new MaxLifx.Controls.RoundedButton.RoundedButton();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvThreads
            // 
            this.lvThreads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvThreads.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvThreads.HideSelection = false;
            this.lvThreads.Location = new System.Drawing.Point(6, 19);
            this.lvThreads.MultiSelect = false;
            this.lvThreads.Name = "lvThreads";
            this.lvThreads.Size = new System.Drawing.Size(401, 174);
            this.lvThreads.TabIndex = 36;
            this.lvThreads.UseCompatibleStateImageBehavior = false;
            this.lvThreads.View = System.Windows.Forms.View.Details;
            this.lvThreads.DoubleClick += new System.EventHandler(this.button8_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 397;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bulbsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 58;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.button3_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // bulbsToolStripMenuItem
            // 
            this.bulbsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.turnOnAllToolStripMenuItem,
            this.turnOffAllToolStripMenuItem,
            this.panicToolStripMenuItem});
            this.bulbsToolStripMenuItem.Name = "bulbsToolStripMenuItem";
            this.bulbsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.bulbsToolStripMenuItem.Text = "Bulbs";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.toolStripMenuItem1.Text = "Discover";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // turnOnAllToolStripMenuItem
            // 
            this.turnOnAllToolStripMenuItem.Name = "turnOnAllToolStripMenuItem";
            this.turnOnAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.turnOnAllToolStripMenuItem.Text = "Turn On All";
            this.turnOnAllToolStripMenuItem.Click += new System.EventHandler(this.turnOnAllToolStripMenuItem_Click);
            // 
            // turnOffAllToolStripMenuItem
            // 
            this.turnOffAllToolStripMenuItem.Name = "turnOffAllToolStripMenuItem";
            this.turnOffAllToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.turnOffAllToolStripMenuItem.Text = "Turn Off All";
            this.turnOffAllToolStripMenuItem.Click += new System.EventHandler(this.turnOffAllToolStripMenuItem_Click);
            // 
            // panicToolStripMenuItem
            // 
            this.panicToolStripMenuItem.Name = "panicToolStripMenuItem";
            this.panicToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.panicToolStripMenuItem.Text = "Panic";
            this.panicToolStripMenuItem.Click += new System.EventHandler(this.panicToolStripMenuItem_Click);
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
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lvThreads);
            this.groupBox1.Location = new System.Drawing.Point(9, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 200);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Running Lights";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Master Brightness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Master Update Freq";
            // 
            // knobControl2
            // 
            this.knobControl2.DrawDivInside = true;
            this.knobControl2.EndAngle = 405F;
            this.knobControl2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobControl2.KnobBackColor = System.Drawing.Color.White;
            this.knobControl2.KnobPointerStyle = MaxLifx.Controls.Knob.KnobControl.KnobPointerStyles.circle;
            this.knobControl2.LargeChange = 5;
            this.knobControl2.Location = new System.Drawing.Point(277, 268);
            this.knobControl2.Maximum = 20;
            this.knobControl2.Minimum = 0;
            this.knobControl2.Name = "knobControl2";
            this.knobControl2.PointerColor = System.Drawing.Color.DarkGray;
            this.knobControl2.ScaleColor = System.Drawing.Color.Black;
            this.knobControl2.ScaleDivisions = 11;
            this.knobControl2.ScaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.knobControl2.ScaleSubDivisions = 4;
            this.knobControl2.ShowLargeScale = false;
            this.knobControl2.ShowSmallScale = false;
            this.knobControl2.Size = new System.Drawing.Size(139, 139);
            this.knobControl2.SmallChange = 1;
            this.knobControl2.StartAngle = 135F;
            this.knobControl2.TabIndex = 62;
            this.knobControl2.Value = 20;
            this.knobControl2.ValueChanged += new MaxLifx.Controls.Knob.ValueChangedEventHandler(this.knobControl2_ValueChanged);
            // 
            // knobControl1
            // 
            this.knobControl1.DrawDivInside = true;
            this.knobControl1.EndAngle = 405F;
            this.knobControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.knobControl1.KnobBackColor = System.Drawing.Color.White;
            this.knobControl1.KnobPointerStyle = MaxLifx.Controls.Knob.KnobControl.KnobPointerStyles.circle;
            this.knobControl1.LargeChange = 5;
            this.knobControl1.Location = new System.Drawing.Point(15, 268);
            this.knobControl1.Maximum = 100;
            this.knobControl1.Minimum = 0;
            this.knobControl1.Name = "knobControl1";
            this.knobControl1.PointerColor = System.Drawing.Color.DarkGray;
            this.knobControl1.ScaleColor = System.Drawing.Color.Black;
            this.knobControl1.ScaleDivisions = 11;
            this.knobControl1.ScaleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.knobControl1.ScaleSubDivisions = 4;
            this.knobControl1.ShowLargeScale = false;
            this.knobControl1.ShowSmallScale = false;
            this.knobControl1.Size = new System.Drawing.Size(139, 139);
            this.knobControl1.SmallChange = 1;
            this.knobControl1.StartAngle = 135F;
            this.knobControl1.TabIndex = 60;
            this.knobControl1.Value = 100;
            this.knobControl1.ValueChanged += new MaxLifx.Controls.Knob.ValueChangedEventHandler(this.knobControl1_ValueChanged);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Salmon;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(281, 132);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 50);
            this.button7.TabIndex = 41;
            this.button7.Text = "➖";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(337, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 40;
            this.button1.Text = "➕";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 419);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.knobControl2);
            this.Controls.Add(this.knobControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(450, 505);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MaxLifx-Z";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvThreads;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bulbsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnOnAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnOffAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.RoundedButton.RoundedButton button1;
        private Controls.RoundedButton.RoundedButton button7;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private Controls.Knob.KnobControl knobControl1;
        private System.Windows.Forms.Label label1;
        private Controls.Knob.KnobControl knobControl2;
        private System.Windows.Forms.Label label2;
    }
}

