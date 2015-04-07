namespace CameraTest
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
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.breakButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shutterSpeedLabel = new System.Windows.Forms.Label();
            this.frameRateLabel = new System.Windows.Forms.Label();
            this.cameraSelection = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exposureLabel = new System.Windows.Forms.Label();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.gainLabel = new System.Windows.Forms.Label();
            this.whiteBalanceLabel = new System.Windows.Forms.Label();
            this.illuminanceLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(368, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(72, 32);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(524, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(72, 32);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 280);
            this.textBox1.TabIndex = 3;
            // 
            // breakButton
            // 
            this.breakButton.Location = new System.Drawing.Point(446, 12);
            this.breakButton.Name = "breakButton";
            this.breakButton.Size = new System.Drawing.Size(72, 32);
            this.breakButton.TabIndex = 4;
            this.breakButton.Text = "Break";
            this.breakButton.UseVisualStyleBackColor = true;
            this.breakButton.Click += new System.EventHandler(this.breakButton_Click);
            //
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.illuminanceLabel);
            this.groupBox2.Controls.Add(this.whiteBalanceLabel);
            this.groupBox2.Controls.Add(this.gainLabel);
            this.groupBox2.Controls.Add(this.brightnessLabel);
            this.groupBox2.Controls.Add(this.exposureLabel);
            this.groupBox2.Controls.Add(this.shutterSpeedLabel);
            this.groupBox2.Controls.Add(this.frameRateLabel);
            this.groupBox2.Controls.Add(this.cameraSelection);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Location = new System.Drawing.Point(368, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 242);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera Selection";
            // 
            // shutterSpeedLabel
            // 
            this.shutterSpeedLabel.AutoSize = true;
            this.shutterSpeedLabel.Location = new System.Drawing.Point(120, 83);
            this.shutterSpeedLabel.Name = "shutterSpeedLabel";
            this.shutterSpeedLabel.Size = new System.Drawing.Size(0, 17);
            this.shutterSpeedLabel.TabIndex = 54;
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.AutoSize = true;
            this.frameRateLabel.Location = new System.Drawing.Point(120, 59);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.Size = new System.Drawing.Size(0, 17);
            this.frameRateLabel.TabIndex = 53;
            // 
            // cameraSelection
            // 
            this.cameraSelection.FormattingEnabled = true;
            this.cameraSelection.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cameraSelection.Location = new System.Drawing.Point(9, 25);
            this.cameraSelection.Name = "cameraSelection";
            this.cameraSelection.Size = new System.Drawing.Size(131, 24);
            this.cameraSelection.TabIndex = 52;
            this.cameraSelection.SelectedIndexChanged += new System.EventHandler(this.cameraSelection_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Frame rate:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Brightness:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "Exposure:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 179);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 17);
            this.label21.TabIndex = 21;
            this.label21.Text = "White balance:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 155);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 17);
            this.label22.TabIndex = 13;
            this.label22.Text = "Gain:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 203);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 17);
            this.label25.TabIndex = 19;
            this.label25.Text = "Illuminance:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 83);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(101, 17);
            this.label26.TabIndex = 17;
            this.label26.Text = "Shutter speed:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(602, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // exposureLabel
            // 
            this.exposureLabel.AutoSize = true;
            this.exposureLabel.Location = new System.Drawing.Point(120, 107);
            this.exposureLabel.Name = "exposureLabel";
            this.exposureLabel.Size = new System.Drawing.Size(0, 17);
            this.exposureLabel.TabIndex = 55;
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(120, 131);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(0, 17);
            this.brightnessLabel.TabIndex = 56;
            // 
            // gainLabel
            // 
            this.gainLabel.AutoSize = true;
            this.gainLabel.Location = new System.Drawing.Point(120, 155);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(0, 17);
            this.gainLabel.TabIndex = 57;
            // 
            // whiteBalanceLabel
            // 
            this.whiteBalanceLabel.AutoSize = true;
            this.whiteBalanceLabel.Location = new System.Drawing.Point(120, 179);
            this.whiteBalanceLabel.Name = "whiteBalanceLabel";
            this.whiteBalanceLabel.Size = new System.Drawing.Size(0, 17);
            this.whiteBalanceLabel.TabIndex = 58;
            // 
            // illuminanceLabel
            // 
            this.illuminanceLabel.AutoSize = true;
            this.illuminanceLabel.Location = new System.Drawing.Point(120, 203);
            this.illuminanceLabel.Name = "illuminanceLabel";
            this.illuminanceLabel.Size = new System.Drawing.Size(0, 17);
            this.illuminanceLabel.TabIndex = 59;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 304);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.breakButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Camera Test";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button breakButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cameraSelection;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label shutterSpeedLabel;
        private System.Windows.Forms.Label frameRateLabel;
        private System.Windows.Forms.Label illuminanceLabel;
        private System.Windows.Forms.Label whiteBalanceLabel;
        private System.Windows.Forms.Label gainLabel;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Label exposureLabel;
    }
}

