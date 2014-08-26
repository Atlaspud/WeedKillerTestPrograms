namespace Advanced_Image_Processor
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
            this.components = new System.ComponentModel.Container();
            this.folderButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.frameRateBar = new System.Windows.Forms.TrackBar();
            this.frameRateLabel = new System.Windows.Forms.Label();
            this.frameRateValue = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.binaryThresholdBar = new System.Windows.Forms.TrackBar();
            this.binaryThresholdLabel = new System.Windows.Forms.Label();
            this.binaryThresholdValue = new System.Windows.Forms.Label();
            this.openingSizeBar = new System.Windows.Forms.TrackBar();
            this.openingSizeLabel = new System.Windows.Forms.Label();
            this.openingSizeValue = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.cannyThresholdValue = new System.Windows.Forms.Label();
            this.cannyThresholdLabel = new System.Windows.Forms.Label();
            this.cannyThresholdBar = new System.Windows.Forms.TrackBar();
            this.closingSizeValue = new System.Windows.Forms.Label();
            this.closingSizeLabel = new System.Windows.Forms.Label();
            this.closingSizeBar = new System.Windows.Forms.TrackBar();
            this.BLOBSizeBar = new System.Windows.Forms.TrackBar();
            this.blobSizeValue = new System.Windows.Forms.Label();
            this.blobSizeLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cameraButton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.featureExtractionCheckBox = new System.Windows.Forms.CheckBox();
            this.blobDetectionCheckBox = new System.Windows.Forms.CheckBox();
            this.saveCheckBox = new System.Windows.Forms.CheckBox();
            this.displayCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryThresholdBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThresholdBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closingSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLOBSizeBar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // folderButton
            // 
            this.folderButton.Location = new System.Drawing.Point(745, 117);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(75, 23);
            this.folderButton.TabIndex = 1;
            this.folderButton.Text = "Folder";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 270);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(745, 146);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(907, 117);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(742, 456);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTextBox.Size = new System.Drawing.Size(238, 100);
            this.statusTextBox.TabIndex = 6;
            // 
            // frameRateBar
            // 
            this.frameRateBar.LargeChange = 10;
            this.frameRateBar.Location = new System.Drawing.Point(759, 257);
            this.frameRateBar.Maximum = 5;
            this.frameRateBar.Minimum = 1;
            this.frameRateBar.Name = "frameRateBar";
            this.frameRateBar.Size = new System.Drawing.Size(104, 45);
            this.frameRateBar.TabIndex = 7;
            this.frameRateBar.Value = 5;
            this.frameRateBar.ValueChanged += new System.EventHandler(this.frameRateBar_ValueChanged);
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.AutoSize = true;
            this.frameRateLabel.Location = new System.Drawing.Point(783, 235);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.Size = new System.Drawing.Size(62, 13);
            this.frameRateLabel.TabIndex = 8;
            this.frameRateLabel.Text = "Frame Rate";
            this.frameRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameRateValue
            // 
            this.frameRateValue.AutoSize = true;
            this.frameRateValue.Location = new System.Drawing.Point(797, 289);
            this.frameRateValue.Name = "frameRateValue";
            this.frameRateValue.Size = new System.Drawing.Size(30, 13);
            this.frameRateValue.TabIndex = 9;
            this.frameRateValue.Text = "5 fps";
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(826, 146);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 13;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // binaryThresholdBar
            // 
            this.binaryThresholdBar.Location = new System.Drawing.Point(759, 334);
            this.binaryThresholdBar.Maximum = 1024;
            this.binaryThresholdBar.Name = "binaryThresholdBar";
            this.binaryThresholdBar.Size = new System.Drawing.Size(104, 45);
            this.binaryThresholdBar.TabIndex = 14;
            this.binaryThresholdBar.TickFrequency = 5;
            this.binaryThresholdBar.Value = 25;
            this.binaryThresholdBar.ValueChanged += new System.EventHandler(this.binaryThresholdBar_ValueChanged);
            // 
            // binaryThresholdLabel
            // 
            this.binaryThresholdLabel.AutoSize = true;
            this.binaryThresholdLabel.Location = new System.Drawing.Point(771, 312);
            this.binaryThresholdLabel.Name = "binaryThresholdLabel";
            this.binaryThresholdLabel.Size = new System.Drawing.Size(86, 13);
            this.binaryThresholdLabel.TabIndex = 15;
            this.binaryThresholdLabel.Text = "Binary Threshold";
            // 
            // binaryThresholdValue
            // 
            this.binaryThresholdValue.AutoSize = true;
            this.binaryThresholdValue.Location = new System.Drawing.Point(798, 366);
            this.binaryThresholdValue.Name = "binaryThresholdValue";
            this.binaryThresholdValue.Size = new System.Drawing.Size(19, 13);
            this.binaryThresholdValue.TabIndex = 16;
            this.binaryThresholdValue.Text = "25";
            // 
            // openingSizeBar
            // 
            this.openingSizeBar.Location = new System.Drawing.Point(759, 407);
            this.openingSizeBar.Maximum = 50;
            this.openingSizeBar.Minimum = 1;
            this.openingSizeBar.Name = "openingSizeBar";
            this.openingSizeBar.Size = new System.Drawing.Size(104, 45);
            this.openingSizeBar.TabIndex = 17;
            this.openingSizeBar.Value = 20;
            this.openingSizeBar.ValueChanged += new System.EventHandler(this.openingSizeBar_ValueChanged);
            // 
            // openingSizeLabel
            // 
            this.openingSizeLabel.AutoSize = true;
            this.openingSizeLabel.Location = new System.Drawing.Point(777, 385);
            this.openingSizeLabel.Name = "openingSizeLabel";
            this.openingSizeLabel.Size = new System.Drawing.Size(70, 13);
            this.openingSizeLabel.TabIndex = 18;
            this.openingSizeLabel.Text = "Opening Size";
            // 
            // openingSizeValue
            // 
            this.openingSizeValue.AutoSize = true;
            this.openingSizeValue.Location = new System.Drawing.Point(799, 439);
            this.openingSizeValue.Name = "openingSizeValue";
            this.openingSizeValue.Size = new System.Drawing.Size(33, 13);
            this.openingSizeValue.TabIndex = 19;
            this.openingSizeValue.Text = "20 px";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(907, 146);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 20;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // cannyThresholdValue
            // 
            this.cannyThresholdValue.AutoSize = true;
            this.cannyThresholdValue.Location = new System.Drawing.Point(908, 366);
            this.cannyThresholdValue.Name = "cannyThresholdValue";
            this.cannyThresholdValue.Size = new System.Drawing.Size(19, 13);
            this.cannyThresholdValue.TabIndex = 23;
            this.cannyThresholdValue.Text = "25";
            // 
            // cannyThresholdLabel
            // 
            this.cannyThresholdLabel.AutoSize = true;
            this.cannyThresholdLabel.Location = new System.Drawing.Point(877, 312);
            this.cannyThresholdLabel.Name = "cannyThresholdLabel";
            this.cannyThresholdLabel.Size = new System.Drawing.Size(87, 13);
            this.cannyThresholdLabel.TabIndex = 22;
            this.cannyThresholdLabel.Text = "Canny Threshold";
            // 
            // cannyThresholdBar
            // 
            this.cannyThresholdBar.Location = new System.Drawing.Point(869, 334);
            this.cannyThresholdBar.Maximum = 1024;
            this.cannyThresholdBar.Name = "cannyThresholdBar";
            this.cannyThresholdBar.Size = new System.Drawing.Size(104, 45);
            this.cannyThresholdBar.TabIndex = 21;
            this.cannyThresholdBar.TickFrequency = 5;
            this.cannyThresholdBar.Value = 25;
            this.cannyThresholdBar.ValueChanged += new System.EventHandler(this.cannyThresholdBar_ValueChanged);
            // 
            // closingSizeValue
            // 
            this.closingSizeValue.AutoSize = true;
            this.closingSizeValue.Location = new System.Drawing.Point(909, 439);
            this.closingSizeValue.Name = "closingSizeValue";
            this.closingSizeValue.Size = new System.Drawing.Size(27, 13);
            this.closingSizeValue.TabIndex = 26;
            this.closingSizeValue.Text = "0 px";
            // 
            // closingSizeLabel
            // 
            this.closingSizeLabel.AutoSize = true;
            this.closingSizeLabel.Location = new System.Drawing.Point(890, 385);
            this.closingSizeLabel.Name = "closingSizeLabel";
            this.closingSizeLabel.Size = new System.Drawing.Size(64, 13);
            this.closingSizeLabel.TabIndex = 25;
            this.closingSizeLabel.Text = "Closing Size";
            // 
            // closingSizeBar
            // 
            this.closingSizeBar.Location = new System.Drawing.Point(869, 407);
            this.closingSizeBar.Maximum = 50;
            this.closingSizeBar.Name = "closingSizeBar";
            this.closingSizeBar.Size = new System.Drawing.Size(104, 45);
            this.closingSizeBar.TabIndex = 24;
            this.closingSizeBar.ValueChanged += new System.EventHandler(this.closingSizeBar_ValueChanged);
            // 
            // BLOBSizeBar
            // 
            this.BLOBSizeBar.Location = new System.Drawing.Point(869, 257);
            this.BLOBSizeBar.Maximum = 300;
            this.BLOBSizeBar.Minimum = 1;
            this.BLOBSizeBar.Name = "BLOBSizeBar";
            this.BLOBSizeBar.Size = new System.Drawing.Size(104, 45);
            this.BLOBSizeBar.TabIndex = 27;
            this.BLOBSizeBar.Value = 115;
            this.BLOBSizeBar.ValueChanged += new System.EventHandler(this.blobSizeBar_ValueChanged);
            // 
            // blobSizeValue
            // 
            this.blobSizeValue.AutoSize = true;
            this.blobSizeValue.Location = new System.Drawing.Point(901, 292);
            this.blobSizeValue.Name = "blobSizeValue";
            this.blobSizeValue.Size = new System.Drawing.Size(39, 13);
            this.blobSizeValue.TabIndex = 29;
            this.blobSizeValue.Text = "115 px";
            // 
            // blobSizeLabel
            // 
            this.blobSizeLabel.AutoSize = true;
            this.blobSizeLabel.Location = new System.Drawing.Point(891, 235);
            this.blobSizeLabel.Name = "blobSizeLabel";
            this.blobSizeLabel.Size = new System.Drawing.Size(51, 13);
            this.blobSizeLabel.TabIndex = 28;
            this.blobSizeLabel.Text = "Blob Size";
            this.blobSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(10, 286);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 270);
            this.panel3.TabIndex = 11;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(360, 270);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Location = new System.Drawing.Point(376, 286);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(360, 270);
            this.panel4.TabIndex = 12;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(360, 270);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(376, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 270);
            this.panel2.TabIndex = 10;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(360, 270);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // cameraButton
            // 
            this.cameraButton.Location = new System.Drawing.Point(826, 117);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.Size = new System.Drawing.Size(75, 23);
            this.cameraButton.TabIndex = 30;
            this.cameraButton.Text = "Camera";
            this.cameraButton.UseVisualStyleBackColor = true;
            this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.logoPictureBox);
            this.panel5.Location = new System.Drawing.Point(780, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(175, 75);
            this.panel5.TabIndex = 31;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(175, 75);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // featureExtractionCheckBox
            // 
            this.featureExtractionCheckBox.AutoSize = true;
            this.featureExtractionCheckBox.Checked = true;
            this.featureExtractionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.featureExtractionCheckBox.Location = new System.Drawing.Point(763, 181);
            this.featureExtractionCheckBox.Name = "featureExtractionCheckBox";
            this.featureExtractionCheckBox.Size = new System.Drawing.Size(112, 17);
            this.featureExtractionCheckBox.TabIndex = 32;
            this.featureExtractionCheckBox.Text = "Feature Extraction";
            this.featureExtractionCheckBox.UseVisualStyleBackColor = true;
            // 
            // blobDetectionCheckBox
            // 
            this.blobDetectionCheckBox.AutoSize = true;
            this.blobDetectionCheckBox.Checked = true;
            this.blobDetectionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blobDetectionCheckBox.Location = new System.Drawing.Point(877, 181);
            this.blobDetectionCheckBox.Name = "blobDetectionCheckBox";
            this.blobDetectionCheckBox.Size = new System.Drawing.Size(96, 17);
            this.blobDetectionCheckBox.TabIndex = 33;
            this.blobDetectionCheckBox.Text = "Blob Detection";
            this.blobDetectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveCheckBox
            // 
            this.saveCheckBox.AutoSize = true;
            this.saveCheckBox.Location = new System.Drawing.Point(763, 205);
            this.saveCheckBox.Name = "saveCheckBox";
            this.saveCheckBox.Size = new System.Drawing.Size(88, 17);
            this.saveCheckBox.TabIndex = 34;
            this.saveCheckBox.Text = "Save Images";
            this.saveCheckBox.UseVisualStyleBackColor = true;
            // 
            // displayCheckBox
            // 
            this.displayCheckBox.AutoSize = true;
            this.displayCheckBox.Checked = true;
            this.displayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayCheckBox.Location = new System.Drawing.Point(877, 205);
            this.displayCheckBox.Name = "displayCheckBox";
            this.displayCheckBox.Size = new System.Drawing.Size(97, 17);
            this.displayCheckBox.TabIndex = 35;
            this.displayCheckBox.Text = "Display Images";
            this.displayCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(990, 566);
            this.Controls.Add(this.displayCheckBox);
            this.Controls.Add(this.saveCheckBox);
            this.Controls.Add(this.blobDetectionCheckBox);
            this.Controls.Add(this.featureExtractionCheckBox);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.cameraButton);
            this.Controls.Add(this.blobSizeValue);
            this.Controls.Add(this.blobSizeLabel);
            this.Controls.Add(this.BLOBSizeBar);
            this.Controls.Add(this.closingSizeValue);
            this.Controls.Add(this.closingSizeLabel);
            this.Controls.Add(this.closingSizeBar);
            this.Controls.Add(this.cannyThresholdValue);
            this.Controls.Add(this.cannyThresholdLabel);
            this.Controls.Add(this.cannyThresholdBar);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.openingSizeValue);
            this.Controls.Add(this.openingSizeLabel);
            this.Controls.Add(this.openingSizeBar);
            this.Controls.Add(this.binaryThresholdValue);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.binaryThresholdLabel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.binaryThresholdBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.frameRateValue);
            this.Controls.Add(this.frameRateLabel);
            this.Controls.Add(this.frameRateBar);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Advanced Image Processor";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryThresholdBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThresholdBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closingSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLOBSizeBar)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.TrackBar frameRateBar;
        private System.Windows.Forms.Label frameRateLabel;
        private System.Windows.Forms.Label frameRateValue;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.TrackBar binaryThresholdBar;
        private System.Windows.Forms.Label binaryThresholdLabel;
        private System.Windows.Forms.Label binaryThresholdValue;
        private System.Windows.Forms.TrackBar openingSizeBar;
        private System.Windows.Forms.Label openingSizeLabel;
        private System.Windows.Forms.Label openingSizeValue;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label cannyThresholdValue;
        private System.Windows.Forms.Label cannyThresholdLabel;
        private System.Windows.Forms.TrackBar cannyThresholdBar;
        private System.Windows.Forms.Label closingSizeValue;
        private System.Windows.Forms.Label closingSizeLabel;
        private System.Windows.Forms.TrackBar closingSizeBar;
        private System.Windows.Forms.TrackBar BLOBSizeBar;
        private System.Windows.Forms.Label blobSizeValue;
        private System.Windows.Forms.Label blobSizeLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button cameraButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.CheckBox featureExtractionCheckBox;
        private System.Windows.Forms.CheckBox blobDetectionCheckBox;
        private System.Windows.Forms.CheckBox saveCheckBox;
        private System.Windows.Forms.CheckBox displayCheckBox;
    }
}

