namespace MotionTracker2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.horizontalSeparator = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.backgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.verticalSeparator1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.directionLabel = new System.Windows.Forms.Label();
            this.speedometerLabel = new System.Windows.Forms.Label();
            this.finishFlagButton = new System.Windows.Forms.Button();
            this.startFlagButton = new System.Windows.Forms.Button();
            this.YawPlotPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.speedometer = new AutoCapture.Speedometer();
            this.PitchPlotPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.RollPlotPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // horizontalSeparator
            // 
            this.horizontalSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalSeparator.Location = new System.Drawing.Point(-5, 379);
            this.horizontalSeparator.Name = "horizontalSeparator";
            this.horizontalSeparator.Size = new System.Drawing.Size(1070, 2);
            this.horizontalSeparator.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(348, 11);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(441, 11);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.White;
            this.logoPictureBox.Location = new System.Drawing.Point(376, 267);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(100, 50);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 6;
            this.logoPictureBox.TabStop = false;
            // 
            // backgroundPictureBox
            // 
            this.backgroundPictureBox.BackColor = System.Drawing.Color.White;
            this.backgroundPictureBox.Location = new System.Drawing.Point(-5, 262);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(936, 65);
            this.backgroundPictureBox.TabIndex = 7;
            this.backgroundPictureBox.TabStop = false;
            // 
            // verticalSeparator1
            // 
            this.verticalSeparator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.verticalSeparator1.Location = new System.Drawing.Point(338, -3);
            this.verticalSeparator1.Name = "verticalSeparator1";
            this.verticalSeparator1.Size = new System.Drawing.Size(2, 266);
            this.verticalSeparator1.TabIndex = 27;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(348, 73);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(168, 182);
            this.textBox1.TabIndex = 35;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(588, 11);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(38, 13);
            this.speedLabel.TabIndex = 38;
            this.speedLabel.Text = "Speed";
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.Location = new System.Drawing.Point(747, 11);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(49, 13);
            this.directionLabel.TabIndex = 39;
            this.directionLabel.Text = "Direction";
            // 
            // speedometerLabel
            // 
            this.speedometerLabel.AutoSize = true;
            this.speedometerLabel.Location = new System.Drawing.Point(585, 109);
            this.speedometerLabel.Name = "speedometerLabel";
            this.speedometerLabel.Size = new System.Drawing.Size(43, 13);
            this.speedometerLabel.TabIndex = 40;
            this.speedometerLabel.Text = "0.0 m/s";
            // 
            // finishFlagButton
            // 
            this.finishFlagButton.Enabled = false;
            this.finishFlagButton.Location = new System.Drawing.Point(441, 40);
            this.finishFlagButton.Name = "finishFlagButton";
            this.finishFlagButton.Size = new System.Drawing.Size(75, 23);
            this.finishFlagButton.TabIndex = 41;
            this.finishFlagButton.Text = "Finish Flag";
            this.finishFlagButton.UseVisualStyleBackColor = true;
            this.finishFlagButton.Click += new System.EventHandler(this.finishFlagButton_Click);
            // 
            // startFlagButton
            // 
            this.startFlagButton.Enabled = false;
            this.startFlagButton.Location = new System.Drawing.Point(348, 40);
            this.startFlagButton.Name = "startFlagButton";
            this.startFlagButton.Size = new System.Drawing.Size(75, 23);
            this.startFlagButton.TabIndex = 42;
            this.startFlagButton.Text = "Start Flag";
            this.startFlagButton.UseVisualStyleBackColor = true;
            this.startFlagButton.Click += new System.EventHandler(this.startFlagButton_Click);
            // 
            // YawPlotPanel
            // 
            this.YawPlotPanel.BackColor = System.Drawing.Color.White;
            this.YawPlotPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YawPlotPanel.Location = new System.Drawing.Point(723, 31);
            this.YawPlotPanel.Name = "YawPlotPanel";
            this.YawPlotPanel.Size = new System.Drawing.Size(100, 100);
            this.YawPlotPanel.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-4, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(935, 2);
            this.label1.TabIndex = 45;
            // 
            // speedometer
            // 
            this.speedometer.Location = new System.Drawing.Point(555, 29);
            this.speedometer.Name = "speedometer";
            this.speedometer.Size = new System.Drawing.Size(100, 100);
            this.speedometer.TabIndex = 37;
            this.speedometer.Text = "speedometer";
            // 
            // PitchPlotPanel
            // 
            this.PitchPlotPanel.BackColor = System.Drawing.Color.White;
            this.PitchPlotPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PitchPlotPanel.Location = new System.Drawing.Point(723, 153);
            this.PitchPlotPanel.Name = "PitchPlotPanel";
            this.PitchPlotPanel.Size = new System.Drawing.Size(100, 100);
            this.PitchPlotPanel.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Pitch";
            // 
            // RollPlotPanel
            // 
            this.RollPlotPanel.BackColor = System.Drawing.Color.White;
            this.RollPlotPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RollPlotPanel.Location = new System.Drawing.Point(555, 153);
            this.RollPlotPanel.Name = "RollPlotPanel";
            this.RollPlotPanel.Size = new System.Drawing.Size(100, 100);
            this.RollPlotPanel.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(592, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Roll";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(527, -4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 266);
            this.label4.TabIndex = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 324);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RollPlotPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PitchPlotPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedometerLabel);
            this.Controls.Add(this.speedometer);
            this.Controls.Add(this.YawPlotPanel);
            this.Controls.Add(this.startFlagButton);
            this.Controls.Add(this.finishFlagButton);
            this.Controls.Add(this.directionLabel);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.verticalSeparator1);
            this.Controls.Add(this.horizontalSeparator);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backgroundPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Motion Tracker 2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label horizontalSeparator;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.PictureBox backgroundPictureBox;
        private System.Windows.Forms.Label verticalSeparator1;
        private System.Windows.Forms.TextBox textBox1;
        private AutoCapture.Speedometer speedometer;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label directionLabel;
        private System.Windows.Forms.Label speedometerLabel;
        private System.Windows.Forms.Button finishFlagButton;
        private System.Windows.Forms.Button startFlagButton;
        public System.Windows.Forms.Panel YawPlotPanel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel PitchPlotPanel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel RollPlotPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

