namespace Image_Processor_2._0
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.BLOBSizeBar = new System.Windows.Forms.TrackBar();
            this.blobSizeValue = new System.Windows.Forms.Label();
            this.blobSizeLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.featureExtractionCheckBox = new System.Windows.Forms.CheckBox();
            this.crossClassificationCheckBox = new System.Windows.Forms.CheckBox();
            this.saveCheckBox = new System.Windows.Forms.CheckBox();
            this.displayCheckBox = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.barChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.classificationCheckBox = new System.Windows.Forms.CheckBox();
            this.frameByFrameCheckBox = new System.Windows.Forms.CheckBox();
            this.nextFrameButton = new System.Windows.Forms.Button();
            this.patchSizeValue = new System.Windows.Forms.Label();
            this.patchSizeTitle = new System.Windows.Forms.Label();
            this.patchSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryThresholdBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLOBSizeBar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // folderButton
            // 
            this.folderButton.Location = new System.Drawing.Point(745, 90);
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
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(745, 122);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(826, 90);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
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
            this.frameRateBar.Location = new System.Drawing.Point(759, 247);
            this.frameRateBar.Maximum = 5;
            this.frameRateBar.Minimum = 1;
            this.frameRateBar.Name = "frameRateBar";
            this.frameRateBar.Size = new System.Drawing.Size(104, 45);
            this.frameRateBar.TabIndex = 7;
            this.frameRateBar.Value = 1;
            this.frameRateBar.ValueChanged += new System.EventHandler(this.frameRateBar_ValueChanged);
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.AutoSize = true;
            this.frameRateLabel.Location = new System.Drawing.Point(783, 225);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.Size = new System.Drawing.Size(62, 13);
            this.frameRateLabel.TabIndex = 8;
            this.frameRateLabel.Text = "Frame Rate";
            this.frameRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameRateValue
            // 
            this.frameRateValue.AutoSize = true;
            this.frameRateValue.Location = new System.Drawing.Point(797, 279);
            this.frameRateValue.Name = "frameRateValue";
            this.frameRateValue.Size = new System.Drawing.Size(30, 13);
            this.frameRateValue.TabIndex = 9;
            this.frameRateValue.Text = "1 fps";
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(826, 122);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 13;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // binaryThresholdBar
            // 
            this.binaryThresholdBar.Location = new System.Drawing.Point(759, 323);
            this.binaryThresholdBar.Maximum = 1024;
            this.binaryThresholdBar.Name = "binaryThresholdBar";
            this.binaryThresholdBar.Size = new System.Drawing.Size(104, 45);
            this.binaryThresholdBar.TabIndex = 14;
            this.binaryThresholdBar.TickFrequency = 5;
            this.binaryThresholdBar.Value = 17;
            this.binaryThresholdBar.ValueChanged += new System.EventHandler(this.binaryThresholdBar_ValueChanged);
            // 
            // binaryThresholdLabel
            // 
            this.binaryThresholdLabel.AutoSize = true;
            this.binaryThresholdLabel.Location = new System.Drawing.Point(771, 301);
            this.binaryThresholdLabel.Name = "binaryThresholdLabel";
            this.binaryThresholdLabel.Size = new System.Drawing.Size(86, 13);
            this.binaryThresholdLabel.TabIndex = 15;
            this.binaryThresholdLabel.Text = "Binary Threshold";
            // 
            // binaryThresholdValue
            // 
            this.binaryThresholdValue.AutoSize = true;
            this.binaryThresholdValue.Location = new System.Drawing.Point(804, 355);
            this.binaryThresholdValue.Name = "binaryThresholdValue";
            this.binaryThresholdValue.Size = new System.Drawing.Size(19, 13);
            this.binaryThresholdValue.TabIndex = 16;
            this.binaryThresholdValue.Text = "17";
            // 
            // openingSizeBar
            // 
            this.openingSizeBar.Location = new System.Drawing.Point(869, 323);
            this.openingSizeBar.Maximum = 50;
            this.openingSizeBar.Minimum = 1;
            this.openingSizeBar.Name = "openingSizeBar";
            this.openingSizeBar.Size = new System.Drawing.Size(104, 45);
            this.openingSizeBar.TabIndex = 17;
            this.openingSizeBar.Value = 22;
            this.openingSizeBar.ValueChanged += new System.EventHandler(this.openingSizeBar_ValueChanged);
            // 
            // openingSizeLabel
            // 
            this.openingSizeLabel.AutoSize = true;
            this.openingSizeLabel.Location = new System.Drawing.Point(885, 301);
            this.openingSizeLabel.Name = "openingSizeLabel";
            this.openingSizeLabel.Size = new System.Drawing.Size(70, 13);
            this.openingSizeLabel.TabIndex = 18;
            this.openingSizeLabel.Text = "Opening Size";
            // 
            // openingSizeValue
            // 
            this.openingSizeValue.AutoSize = true;
            this.openingSizeValue.Location = new System.Drawing.Point(907, 355);
            this.openingSizeValue.Name = "openingSizeValue";
            this.openingSizeValue.Size = new System.Drawing.Size(33, 13);
            this.openingSizeValue.TabIndex = 19;
            this.openingSizeValue.Text = "22 px";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(907, 122);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 20;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // BLOBSizeBar
            // 
            this.BLOBSizeBar.Location = new System.Drawing.Point(869, 247);
            this.BLOBSizeBar.Maximum = 300;
            this.BLOBSizeBar.Minimum = 1;
            this.BLOBSizeBar.Name = "BLOBSizeBar";
            this.BLOBSizeBar.Size = new System.Drawing.Size(104, 45);
            this.BLOBSizeBar.TabIndex = 27;
            this.BLOBSizeBar.Value = 122;
            this.BLOBSizeBar.ValueChanged += new System.EventHandler(this.blobSizeBar_ValueChanged);
            // 
            // blobSizeValue
            // 
            this.blobSizeValue.AutoSize = true;
            this.blobSizeValue.Location = new System.Drawing.Point(901, 282);
            this.blobSizeValue.Name = "blobSizeValue";
            this.blobSizeValue.Size = new System.Drawing.Size(39, 13);
            this.blobSizeValue.TabIndex = 29;
            this.blobSizeValue.Text = "122 px";
            // 
            // blobSizeLabel
            // 
            this.blobSizeLabel.AutoSize = true;
            this.blobSizeLabel.Location = new System.Drawing.Point(890, 225);
            this.blobSizeLabel.Name = "blobSizeLabel";
            this.blobSizeLabel.Size = new System.Drawing.Size(58, 13);
            this.blobSizeLabel.TabIndex = 28;
            this.blobSizeLabel.Text = "BLOB Size";
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
            // panel5
            // 
            this.panel5.Controls.Add(this.logoPictureBox);
            this.panel5.Location = new System.Drawing.Point(780, 6);
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
            this.featureExtractionCheckBox.Location = new System.Drawing.Point(760, 153);
            this.featureExtractionCheckBox.Name = "featureExtractionCheckBox";
            this.featureExtractionCheckBox.Size = new System.Drawing.Size(112, 17);
            this.featureExtractionCheckBox.TabIndex = 32;
            this.featureExtractionCheckBox.Text = "Feature Extraction";
            this.featureExtractionCheckBox.UseVisualStyleBackColor = true;
            // 
            // crossClassificationCheckBox
            // 
            this.crossClassificationCheckBox.AutoSize = true;
            this.crossClassificationCheckBox.Location = new System.Drawing.Point(760, 199);
            this.crossClassificationCheckBox.Name = "crossClassificationCheckBox";
            this.crossClassificationCheckBox.Size = new System.Drawing.Size(116, 17);
            this.crossClassificationCheckBox.TabIndex = 33;
            this.crossClassificationCheckBox.Text = "Cross-Classification";
            this.crossClassificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveCheckBox
            // 
            this.saveCheckBox.AutoSize = true;
            this.saveCheckBox.Checked = true;
            this.saveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveCheckBox.Location = new System.Drawing.Point(880, 154);
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
            this.displayCheckBox.Location = new System.Drawing.Point(880, 176);
            this.displayCheckBox.Name = "displayCheckBox";
            this.displayCheckBox.Size = new System.Drawing.Size(97, 17);
            this.displayCheckBox.TabIndex = 35;
            this.displayCheckBox.Text = "Display Images";
            this.displayCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.barChart);
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
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // barChart
            // 
            this.barChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.barChart.BackImageTransparentColor = System.Drawing.Color.White;
            this.barChart.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.barChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.barChart.Legends.Add(legend1);
            this.barChart.Location = new System.Drawing.Point(0, 0);
            this.barChart.Name = "barChart";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.barChart.Series.Add(series1);
            this.barChart.Size = new System.Drawing.Size(1000, 500);
            this.barChart.TabIndex = 0;
            this.barChart.Text = "chart1";
            this.barChart.Visible = false;
            // 
            // classificationCheckBox
            // 
            this.classificationCheckBox.AutoSize = true;
            this.classificationCheckBox.Checked = true;
            this.classificationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.classificationCheckBox.Location = new System.Drawing.Point(760, 176);
            this.classificationCheckBox.Name = "classificationCheckBox";
            this.classificationCheckBox.Size = new System.Drawing.Size(87, 17);
            this.classificationCheckBox.TabIndex = 36;
            this.classificationCheckBox.Text = "Classification";
            this.classificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // frameByFrameCheckBox
            // 
            this.frameByFrameCheckBox.AutoSize = true;
            this.frameByFrameCheckBox.Location = new System.Drawing.Point(880, 200);
            this.frameByFrameCheckBox.Name = "frameByFrameCheckBox";
            this.frameByFrameCheckBox.Size = new System.Drawing.Size(101, 17);
            this.frameByFrameCheckBox.TabIndex = 37;
            this.frameByFrameCheckBox.Text = "Frame by Frame";
            this.frameByFrameCheckBox.UseVisualStyleBackColor = true;
            // 
            // nextFrameButton
            // 
            this.nextFrameButton.Enabled = false;
            this.nextFrameButton.Location = new System.Drawing.Point(907, 90);
            this.nextFrameButton.Name = "nextFrameButton";
            this.nextFrameButton.Size = new System.Drawing.Size(75, 23);
            this.nextFrameButton.TabIndex = 38;
            this.nextFrameButton.Text = "Next Frame";
            this.nextFrameButton.UseVisualStyleBackColor = true;
            this.nextFrameButton.Click += new System.EventHandler(this.nextFrameButton_Click);
            // 
            // patchSizeValue
            // 
            this.patchSizeValue.AutoSize = true;
            this.patchSizeValue.Location = new System.Drawing.Point(798, 434);
            this.patchSizeValue.Name = "patchSizeValue";
            this.patchSizeValue.Size = new System.Drawing.Size(39, 13);
            this.patchSizeValue.TabIndex = 41;
            this.patchSizeValue.Text = "200 px";
            // 
            // patchSizeTitle
            // 
            this.patchSizeTitle.AutoSize = true;
            this.patchSizeTitle.Location = new System.Drawing.Point(783, 380);
            this.patchSizeTitle.Name = "patchSizeTitle";
            this.patchSizeTitle.Size = new System.Drawing.Size(58, 13);
            this.patchSizeTitle.TabIndex = 40;
            this.patchSizeTitle.Text = "Patch Size";
            // 
            // patchSizeTrackBar
            // 
            this.patchSizeTrackBar.Location = new System.Drawing.Point(759, 402);
            this.patchSizeTrackBar.Maximum = 500;
            this.patchSizeTrackBar.Minimum = 1;
            this.patchSizeTrackBar.Name = "patchSizeTrackBar";
            this.patchSizeTrackBar.Size = new System.Drawing.Size(104, 45);
            this.patchSizeTrackBar.TabIndex = 39;
            this.patchSizeTrackBar.TickFrequency = 5;
            this.patchSizeTrackBar.Value = 200;
            this.patchSizeTrackBar.ValueChanged += new System.EventHandler(this.patchSizeTrackBar_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(990, 566);
            this.Controls.Add(this.patchSizeValue);
            this.Controls.Add(this.patchSizeTitle);
            this.Controls.Add(this.patchSizeTrackBar);
            this.Controls.Add(this.nextFrameButton);
            this.Controls.Add(this.frameByFrameCheckBox);
            this.Controls.Add(this.classificationCheckBox);
            this.Controls.Add(this.displayCheckBox);
            this.Controls.Add(this.saveCheckBox);
            this.Controls.Add(this.crossClassificationCheckBox);
            this.Controls.Add(this.featureExtractionCheckBox);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.blobSizeValue);
            this.Controls.Add(this.blobSizeLabel);
            this.Controls.Add(this.BLOBSizeBar);
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
            this.Text = "Image Processor 2.0";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryThresholdBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLOBSizeBar)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchSizeTrackBar)).EndInit();
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
        private System.Windows.Forms.TrackBar BLOBSizeBar;
        private System.Windows.Forms.Label blobSizeValue;
        private System.Windows.Forms.Label blobSizeLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.CheckBox featureExtractionCheckBox;
        private System.Windows.Forms.CheckBox crossClassificationCheckBox;
        private System.Windows.Forms.CheckBox saveCheckBox;
        private System.Windows.Forms.CheckBox displayCheckBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart barChart;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox classificationCheckBox;
        private System.Windows.Forms.CheckBox frameByFrameCheckBox;
        private System.Windows.Forms.Button nextFrameButton;
        private System.Windows.Forms.Label patchSizeValue;
        private System.Windows.Forms.Label patchSizeTitle;
        private System.Windows.Forms.TrackBar patchSizeTrackBar;
    }
}

