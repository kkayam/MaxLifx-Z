﻿namespace MaxLifx.UIs
{
    partial class ScreenColourUI
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
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tlx = new System.Windows.Forms.TextBox();
            this.tly = new System.Windows.Forms.TextBox();
            this.brx = new System.Windows.Forms.TextBox();
            this.bry = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbKelvin = new System.Windows.Forms.TrackBar();
            this.saturation = new System.Windows.Forms.TrackBar();
            this.brightness = new System.Windows.Forms.TrackBar();
            this.kelvin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.delay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.fade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lbLabels = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMonitor1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbKelvin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 77);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(386, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "Set Screen Area";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Top-Left";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Bottom-Right";
            // 
            // tlx
            // 
            this.tlx.Location = new System.Drawing.Point(145, 111);
            this.tlx.Name = "tlx";
            this.tlx.Size = new System.Drawing.Size(46, 20);
            this.tlx.TabIndex = 17;
            this.tlx.Text = "0";
            this.tlx.TextChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // tly
            // 
            this.tly.Location = new System.Drawing.Point(216, 111);
            this.tly.Name = "tly";
            this.tly.Size = new System.Drawing.Size(46, 20);
            this.tly.TabIndex = 18;
            this.tly.Text = "0";
            this.tly.TextChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // brx
            // 
            this.brx.Location = new System.Drawing.Point(145, 132);
            this.brx.Name = "brx";
            this.brx.Size = new System.Drawing.Size(46, 20);
            this.brx.TabIndex = 19;
            this.brx.Text = "0";
            this.brx.TextChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // bry
            // 
            this.bry.Location = new System.Drawing.Point(216, 132);
            this.bry.Name = "bry";
            this.bry.Size = new System.Drawing.Size(46, 20);
            this.bry.TabIndex = 20;
            this.bry.Text = "0";
            this.bry.TextChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbKelvin);
            this.groupBox4.Controls.Add(this.saturation);
            this.groupBox4.Controls.Add(this.brightness);
            this.groupBox4.Controls.Add(this.kelvin);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.delay);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.fade);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(17, 415);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(399, 129);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameters";
            // 
            // tbKelvin
            // 
            this.tbKelvin.AutoSize = false;
            this.tbKelvin.Location = new System.Drawing.Point(79, 103);
            this.tbKelvin.Maximum = 9000;
            this.tbKelvin.Minimum = 1500;
            this.tbKelvin.Name = "tbKelvin";
            this.tbKelvin.Size = new System.Drawing.Size(248, 20);
            this.tbKelvin.TabIndex = 107;
            this.tbKelvin.Value = 3500;
            this.tbKelvin.ValueChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // saturation
            // 
            this.saturation.AutoSize = false;
            this.saturation.Location = new System.Drawing.Point(79, 83);
            this.saturation.Maximum = 65535;
            this.saturation.Name = "saturation";
            this.saturation.Size = new System.Drawing.Size(248, 20);
            this.saturation.TabIndex = 106;
            this.saturation.Value = 65535;
            this.saturation.ValueChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // brightness
            // 
            this.brightness.AutoSize = false;
            this.brightness.Location = new System.Drawing.Point(79, 61);
            this.brightness.Maximum = 65535;
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(248, 20);
            this.brightness.TabIndex = 38;
            this.brightness.Value = 65535;
            this.brightness.ValueChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // kelvin
            // 
            this.kelvin.AutoSize = true;
            this.kelvin.Location = new System.Drawing.Point(4, 106);
            this.kelvin.Name = "kelvin";
            this.kelvin.Size = new System.Drawing.Size(36, 13);
            this.kelvin.TabIndex = 104;
            this.kelvin.Text = "Kelvin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "ms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Delay";
            // 
            // delay
            // 
            this.delay.Location = new System.Drawing.Point(79, 38);
            this.delay.Name = "delay";
            this.delay.Size = new System.Drawing.Size(37, 20);
            this.delay.TabIndex = 20;
            this.delay.Text = "10";
            this.delay.TextChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(116, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "ms";
            // 
            // fade
            // 
            this.fade.Location = new System.Drawing.Point(79, 16);
            this.fade.Name = "fade";
            this.fade.Size = new System.Drawing.Size(37, 20);
            this.fade.TabIndex = 17;
            this.fade.Text = "20";
            this.fade.TextChanged += new System.EventHandler(this.pos_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fade";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Brightness";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Saturation";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(387, 33);
            this.button2.TabIndex = 35;
            this.button2.Text = "Assign Parts of Capture Area To Bulbs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbLabels
            // 
            this.lbLabels.FormattingEnabled = true;
            this.lbLabels.Location = new System.Drawing.Point(7, 19);
            this.lbLabels.Name = "lbLabels";
            this.lbLabels.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbLabels.Size = new System.Drawing.Size(386, 160);
            this.lbLabels.TabIndex = 87;
            this.lbLabels.SelectedIndexChanged += new System.EventHandler(this.lbLabels_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnMonitor1);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.bry);
            this.groupBox1.Controls.Add(this.brx);
            this.groupBox1.Controls.Add(this.tly);
            this.groupBox1.Controls.Add(this.tlx);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 203);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screen Area To Capture";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(386, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Secondary Monitor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMonitor1
            // 
            this.btnMonitor1.Location = new System.Drawing.Point(6, 19);
            this.btnMonitor1.Name = "btnMonitor1";
            this.btnMonitor1.Size = new System.Drawing.Size(387, 23);
            this.btnMonitor1.TabIndex = 36;
            this.btnMonitor1.Text = "Primary Monitor";
            this.btnMonitor1.UseVisualStyleBackColor = true;
            this.btnMonitor1.Click += new System.EventHandler(this.btnMonitor1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbLabels);
            this.groupBox2.Location = new System.Drawing.Point(17, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 187);
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Bulbs to Use:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "65535";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 109;
            this.label7.Text = "65535";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(333, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 110;
            this.label8.Text = "9000";
            // 
            // ScreenColourUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 563);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "ScreenColourUI";
            this.Text = "ScreenColourUI";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbKelvin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tlx;
        private System.Windows.Forms.TextBox tly;
        private System.Windows.Forms.TextBox brx;
        private System.Windows.Forms.TextBox bry;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox delay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox fade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbLabels;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMonitor1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label kelvin;
        private System.Windows.Forms.TrackBar tbKelvin;
        private System.Windows.Forms.TrackBar saturation;
        private System.Windows.Forms.TrackBar brightness;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}