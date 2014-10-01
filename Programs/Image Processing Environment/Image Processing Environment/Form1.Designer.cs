namespace Image_Processing_Environment
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
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.histogramEqualizationOn = new System.Windows.Forms.RadioButton();
            this.histogramEqualizationGroup = new System.Windows.Forms.GroupBox();
            this.histogramEqualizationOff = new System.Windows.Forms.RadioButton();
            this.referenceButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cameraSelection = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.exposureLabel = new System.Windows.Forms.Label();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.frameRateLabel = new System.Windows.Forms.Label();
            this.whiteBalanceLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.illuminanceLabel = new System.Windows.Forms.Label();
            this.gainLabel = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.shutterSpeedLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.displayProcessed = new System.Windows.Forms.RadioButton();
            this.displayOff = new System.Windows.Forms.RadioButton();
            this.displayOriginal = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.segmentationOn = new System.Windows.Forms.RadioButton();
            this.segmentationOff = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BLOBOn = new System.Windows.Forms.RadioButton();
            this.BLOBOff = new System.Windows.Forms.RadioButton();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.saveImagesOn = new System.Windows.Forms.RadioButton();
            this.saveImagesOff = new System.Windows.Forms.RadioButton();
            this.horizontalSeparator = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.backgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.globalFrameRateLabel = new System.Windows.Forms.Label();
            this.frameRateTitle = new System.Windows.Forms.Label();
            this.frameRateTrackBar = new System.Windows.Forms.TrackBar();
            this.blobSizeValue = new System.Windows.Forms.Label();
            this.blobSizeTitle = new System.Windows.Forms.Label();
            this.blobSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textureOn = new System.Windows.Forms.RadioButton();
            this.textureOff = new System.Windows.Forms.RadioButton();
            this.binaryThresholdValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.binaryThresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.openingSizeValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openingSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.histogramEqualizationGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blobSizeTrackBar)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binaryThresholdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(95, 32);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(113, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(95, 32);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 505);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(196, 251);
            this.textBox1.TabIndex = 15;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // histogramEqualizationOn
            // 
            this.histogramEqualizationOn.AutoSize = true;
            this.histogramEqualizationOn.Location = new System.Drawing.Point(47, 28);
            this.histogramEqualizationOn.Name = "histogramEqualizationOn";
            this.histogramEqualizationOn.Size = new System.Drawing.Size(48, 21);
            this.histogramEqualizationOn.TabIndex = 27;
            this.histogramEqualizationOn.Text = "On";
            this.histogramEqualizationOn.UseVisualStyleBackColor = true;
            // 
            // histogramEqualizationGroup
            // 
            this.histogramEqualizationGroup.Controls.Add(this.histogramEqualizationOff);
            this.histogramEqualizationGroup.Controls.Add(this.histogramEqualizationOn);
            this.histogramEqualizationGroup.Location = new System.Drawing.Point(214, 245);
            this.histogramEqualizationGroup.Name = "histogramEqualizationGroup";
            this.histogramEqualizationGroup.Size = new System.Drawing.Size(196, 59);
            this.histogramEqualizationGroup.TabIndex = 28;
            this.histogramEqualizationGroup.TabStop = false;
            this.histogramEqualizationGroup.Text = "Histogram Equalization";
            // 
            // histogramEqualizationOff
            // 
            this.histogramEqualizationOff.AutoSize = true;
            this.histogramEqualizationOff.Checked = true;
            this.histogramEqualizationOff.Location = new System.Drawing.Point(101, 28);
            this.histogramEqualizationOff.Name = "histogramEqualizationOff";
            this.histogramEqualizationOff.Size = new System.Drawing.Size(48, 21);
            this.histogramEqualizationOff.TabIndex = 28;
            this.histogramEqualizationOff.TabStop = true;
            this.histogramEqualizationOff.Text = "Off";
            this.histogramEqualizationOff.UseVisualStyleBackColor = true;
            // 
            // referenceButton
            // 
            this.referenceButton.Enabled = false;
            this.referenceButton.Location = new System.Drawing.Point(214, 12);
            this.referenceButton.Name = "referenceButton";
            this.referenceButton.Size = new System.Drawing.Size(95, 32);
            this.referenceButton.TabIndex = 29;
            this.referenceButton.Text = "Reference";
            this.referenceButton.UseVisualStyleBackColor = true;
            this.referenceButton.Click += new System.EventHandler(this.referenceButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cameraSelection);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.exposureLabel);
            this.groupBox2.Controls.Add(this.brightnessLabel);
            this.groupBox2.Controls.Add(this.frameRateLabel);
            this.groupBox2.Controls.Add(this.whiteBalanceLabel);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.illuminanceLabel);
            this.groupBox2.Controls.Add(this.gainLabel);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.shutterSpeedLabel);
            this.groupBox2.Location = new System.Drawing.Point(214, 505);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 251);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera Selection";
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
            this.cameraSelection.Location = new System.Drawing.Point(9, 30);
            this.cameraSelection.Name = "cameraSelection";
            this.cameraSelection.Size = new System.Drawing.Size(131, 24);
            this.cameraSelection.TabIndex = 52;
            this.cameraSelection.SelectedIndexChanged += new System.EventHandler(this.cameraSelection_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Frame rate:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Brightness:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "Exposure:";
            // 
            // exposureLabel
            // 
            this.exposureLabel.AutoSize = true;
            this.exposureLabel.Location = new System.Drawing.Point(113, 115);
            this.exposureLabel.Name = "exposureLabel";
            this.exposureLabel.Size = new System.Drawing.Size(0, 17);
            this.exposureLabel.TabIndex = 6;
            this.exposureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(113, 140);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(0, 17);
            this.brightnessLabel.TabIndex = 7;
            this.brightnessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.AutoSize = true;
            this.frameRateLabel.Location = new System.Drawing.Point(113, 65);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.Size = new System.Drawing.Size(0, 17);
            this.frameRateLabel.TabIndex = 8;
            this.frameRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // whiteBalanceLabel
            // 
            this.whiteBalanceLabel.AutoSize = true;
            this.whiteBalanceLabel.Location = new System.Drawing.Point(113, 190);
            this.whiteBalanceLabel.Name = "whiteBalanceLabel";
            this.whiteBalanceLabel.Size = new System.Drawing.Size(0, 17);
            this.whiteBalanceLabel.TabIndex = 22;
            this.whiteBalanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 190);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 17);
            this.label21.TabIndex = 21;
            this.label21.Text = "White balance:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 165);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 17);
            this.label22.TabIndex = 13;
            this.label22.Text = "Gain:";
            // 
            // illuminanceLabel
            // 
            this.illuminanceLabel.AutoSize = true;
            this.illuminanceLabel.Location = new System.Drawing.Point(113, 215);
            this.illuminanceLabel.Name = "illuminanceLabel";
            this.illuminanceLabel.Size = new System.Drawing.Size(0, 17);
            this.illuminanceLabel.TabIndex = 20;
            this.illuminanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gainLabel
            // 
            this.gainLabel.AutoSize = true;
            this.gainLabel.Location = new System.Drawing.Point(113, 165);
            this.gainLabel.Name = "gainLabel";
            this.gainLabel.Size = new System.Drawing.Size(0, 17);
            this.gainLabel.TabIndex = 14;
            this.gainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 215);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 17);
            this.label25.TabIndex = 19;
            this.label25.Text = "Illuminance:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(10, 90);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(101, 17);
            this.label26.TabIndex = 17;
            this.label26.Text = "Shutter speed:";
            // 
            // shutterSpeedLabel
            // 
            this.shutterSpeedLabel.AutoSize = true;
            this.shutterSpeedLabel.Location = new System.Drawing.Point(113, 90);
            this.shutterSpeedLabel.Name = "shutterSpeedLabel";
            this.shutterSpeedLabel.Size = new System.Drawing.Size(0, 17);
            this.shutterSpeedLabel.TabIndex = 18;
            this.shutterSpeedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.displayProcessed);
            this.groupBox1.Controls.Add(this.displayOff);
            this.groupBox1.Controls.Add(this.displayOriginal);
            this.groupBox1.Location = new System.Drawing.Point(214, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 124);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Display";
            // 
            // displayProcessed
            // 
            this.displayProcessed.AutoSize = true;
            this.displayProcessed.Location = new System.Drawing.Point(47, 57);
            this.displayProcessed.Name = "displayProcessed";
            this.displayProcessed.Size = new System.Drawing.Size(96, 21);
            this.displayProcessed.TabIndex = 31;
            this.displayProcessed.Text = "Processed";
            this.displayProcessed.UseVisualStyleBackColor = true;
            // 
            // displayOff
            // 
            this.displayOff.AutoSize = true;
            this.displayOff.Location = new System.Drawing.Point(47, 86);
            this.displayOff.Name = "displayOff";
            this.displayOff.Size = new System.Drawing.Size(48, 21);
            this.displayOff.TabIndex = 30;
            this.displayOff.Text = "Off";
            this.displayOff.UseVisualStyleBackColor = true;
            // 
            // displayOriginal
            // 
            this.displayOriginal.AutoSize = true;
            this.displayOriginal.Checked = true;
            this.displayOriginal.Location = new System.Drawing.Point(47, 28);
            this.displayOriginal.Name = "displayOriginal";
            this.displayOriginal.Size = new System.Drawing.Size(78, 21);
            this.displayOriginal.TabIndex = 29;
            this.displayOriginal.TabStop = true;
            this.displayOriginal.Text = "Original";
            this.displayOriginal.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.segmentationOn);
            this.groupBox3.Controls.Add(this.segmentationOff);
            this.groupBox3.Location = new System.Drawing.Point(214, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 59);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Segmentation";
            // 
            // segmentationOn
            // 
            this.segmentationOn.AutoSize = true;
            this.segmentationOn.Checked = true;
            this.segmentationOn.Location = new System.Drawing.Point(47, 28);
            this.segmentationOn.Name = "segmentationOn";
            this.segmentationOn.Size = new System.Drawing.Size(48, 21);
            this.segmentationOn.TabIndex = 29;
            this.segmentationOn.TabStop = true;
            this.segmentationOn.Text = "On";
            this.segmentationOn.UseVisualStyleBackColor = true;
            // 
            // segmentationOff
            // 
            this.segmentationOff.AutoSize = true;
            this.segmentationOff.Location = new System.Drawing.Point(101, 28);
            this.segmentationOff.Name = "segmentationOff";
            this.segmentationOff.Size = new System.Drawing.Size(48, 21);
            this.segmentationOff.TabIndex = 28;
            this.segmentationOff.Text = "Off";
            this.segmentationOff.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BLOBOn);
            this.groupBox4.Controls.Add(this.BLOBOff);
            this.groupBox4.Location = new System.Drawing.Point(214, 375);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(196, 59);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "BLOB Detection";
            // 
            // BLOBOn
            // 
            this.BLOBOn.AutoSize = true;
            this.BLOBOn.Checked = true;
            this.BLOBOn.Location = new System.Drawing.Point(47, 28);
            this.BLOBOn.Name = "BLOBOn";
            this.BLOBOn.Size = new System.Drawing.Size(48, 21);
            this.BLOBOn.TabIndex = 29;
            this.BLOBOn.TabStop = true;
            this.BLOBOn.Text = "On";
            this.BLOBOn.UseVisualStyleBackColor = true;
            // 
            // BLOBOff
            // 
            this.BLOBOff.AutoSize = true;
            this.BLOBOff.Location = new System.Drawing.Point(101, 28);
            this.BLOBOff.Name = "BLOBOff";
            this.BLOBOff.Size = new System.Drawing.Size(48, 21);
            this.BLOBOff.TabIndex = 28;
            this.BLOBOff.Text = "Off";
            this.BLOBOff.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(315, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 32);
            this.saveButton.TabIndex = 53;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.saveImagesOn);
            this.groupBox5.Controls.Add(this.saveImagesOff);
            this.groupBox5.Location = new System.Drawing.Point(214, 180);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(196, 59);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save Raw Images";
            // 
            // saveImagesOn
            // 
            this.saveImagesOn.AutoSize = true;
            this.saveImagesOn.Location = new System.Drawing.Point(47, 24);
            this.saveImagesOn.Name = "saveImagesOn";
            this.saveImagesOn.Size = new System.Drawing.Size(48, 21);
            this.saveImagesOn.TabIndex = 32;
            this.saveImagesOn.Text = "On";
            this.saveImagesOn.UseVisualStyleBackColor = true;
            // 
            // saveImagesOff
            // 
            this.saveImagesOff.AutoSize = true;
            this.saveImagesOff.Checked = true;
            this.saveImagesOff.Location = new System.Drawing.Point(101, 24);
            this.saveImagesOff.Name = "saveImagesOff";
            this.saveImagesOff.Size = new System.Drawing.Size(48, 21);
            this.saveImagesOff.TabIndex = 31;
            this.saveImagesOff.TabStop = true;
            this.saveImagesOff.Text = "Off";
            this.saveImagesOff.UseVisualStyleBackColor = true;
            // 
            // horizontalSeparator
            // 
            this.horizontalSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalSeparator.Location = new System.Drawing.Point(-3, 763);
            this.horizontalSeparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.horizontalSeparator.Name = "horizontalSeparator";
            this.horizontalSeparator.Size = new System.Drawing.Size(940, 2);
            this.horizontalSeparator.TabIndex = 58;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.White;
            this.logoPictureBox.Location = new System.Drawing.Point(398, 765);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(133, 62);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 59;
            this.logoPictureBox.TabStop = false;
            // 
            // backgroundPictureBox
            // 
            this.backgroundPictureBox.BackColor = System.Drawing.Color.White;
            this.backgroundPictureBox.Location = new System.Drawing.Point(-3, 763);
            this.backgroundPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(940, 80);
            this.backgroundPictureBox.TabIndex = 60;
            this.backgroundPictureBox.TabStop = false;
            // 
            // globalFrameRateLabel
            // 
            this.globalFrameRateLabel.AutoSize = true;
            this.globalFrameRateLabel.Location = new System.Drawing.Point(84, 124);
            this.globalFrameRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.globalFrameRateLabel.Name = "globalFrameRateLabel";
            this.globalFrameRateLabel.Size = new System.Drawing.Size(39, 17);
            this.globalFrameRateLabel.TabIndex = 75;
            this.globalFrameRateLabel.Text = "3 fps";
            this.globalFrameRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameRateTitle
            // 
            this.frameRateTitle.AutoSize = true;
            this.frameRateTitle.Location = new System.Drawing.Point(66, 67);
            this.frameRateTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frameRateTitle.Name = "frameRateTitle";
            this.frameRateTitle.Size = new System.Drawing.Size(82, 17);
            this.frameRateTitle.TabIndex = 74;
            this.frameRateTitle.Text = "Frame Rate";
            this.frameRateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameRateTrackBar
            // 
            this.frameRateTrackBar.LargeChange = 2;
            this.frameRateTrackBar.Location = new System.Drawing.Point(35, 87);
            this.frameRateTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.frameRateTrackBar.Minimum = 1;
            this.frameRateTrackBar.Name = "frameRateTrackBar";
            this.frameRateTrackBar.Size = new System.Drawing.Size(139, 56);
            this.frameRateTrackBar.TabIndex = 73;
            this.frameRateTrackBar.Value = 6;
            this.frameRateTrackBar.ValueChanged += new System.EventHandler(this.frameRateTrackBar_ValueChanged);
            // 
            // blobSizeValue
            // 
            this.blobSizeValue.AutoSize = true;
            this.blobSizeValue.Location = new System.Drawing.Point(85, 238);
            this.blobSizeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blobSizeValue.Name = "blobSizeValue";
            this.blobSizeValue.Size = new System.Drawing.Size(50, 17);
            this.blobSizeValue.TabIndex = 79;
            this.blobSizeValue.Text = "120 px";
            this.blobSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blobSizeTitle
            // 
            this.blobSizeTitle.AutoSize = true;
            this.blobSizeTitle.Location = new System.Drawing.Point(72, 180);
            this.blobSizeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blobSizeTitle.Name = "blobSizeTitle";
            this.blobSizeTitle.Size = new System.Drawing.Size(76, 17);
            this.blobSizeTitle.TabIndex = 78;
            this.blobSizeTitle.Text = "BLOB Size";
            this.blobSizeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blobSizeTrackBar
            // 
            this.blobSizeTrackBar.LargeChange = 2;
            this.blobSizeTrackBar.Location = new System.Drawing.Point(36, 201);
            this.blobSizeTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.blobSizeTrackBar.Maximum = 500;
            this.blobSizeTrackBar.Minimum = 1;
            this.blobSizeTrackBar.Name = "blobSizeTrackBar";
            this.blobSizeTrackBar.Size = new System.Drawing.Size(139, 56);
            this.blobSizeTrackBar.TabIndex = 77;
            this.blobSizeTrackBar.Value = 120;
            this.blobSizeTrackBar.ValueChanged += new System.EventHandler(this.blobSizeTrackBar_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textureOn);
            this.groupBox6.Controls.Add(this.textureOff);
            this.groupBox6.Location = new System.Drawing.Point(214, 440);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(196, 59);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Texture Recognition";
            // 
            // textureOn
            // 
            this.textureOn.AutoSize = true;
            this.textureOn.Enabled = false;
            this.textureOn.Location = new System.Drawing.Point(47, 23);
            this.textureOn.Name = "textureOn";
            this.textureOn.Size = new System.Drawing.Size(48, 21);
            this.textureOn.TabIndex = 32;
            this.textureOn.Text = "On";
            this.textureOn.UseVisualStyleBackColor = true;
            // 
            // textureOff
            // 
            this.textureOff.AutoSize = true;
            this.textureOff.Checked = true;
            this.textureOff.Enabled = false;
            this.textureOff.Location = new System.Drawing.Point(101, 23);
            this.textureOff.Name = "textureOff";
            this.textureOff.Size = new System.Drawing.Size(48, 21);
            this.textureOff.TabIndex = 31;
            this.textureOff.TabStop = true;
            this.textureOff.Text = "Off";
            this.textureOff.UseVisualStyleBackColor = true;
            // 
            // binaryThresholdValue
            // 
            this.binaryThresholdValue.AutoSize = true;
            this.binaryThresholdValue.Location = new System.Drawing.Point(85, 344);
            this.binaryThresholdValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.binaryThresholdValue.Name = "binaryThresholdValue";
            this.binaryThresholdValue.Size = new System.Drawing.Size(16, 17);
            this.binaryThresholdValue.TabIndex = 82;
            this.binaryThresholdValue.Text = "1";
            this.binaryThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 287);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 81;
            this.label2.Text = "Binary Threshold";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // binaryThresholdTrackBar
            // 
            this.binaryThresholdTrackBar.LargeChange = 2;
            this.binaryThresholdTrackBar.Location = new System.Drawing.Point(30, 307);
            this.binaryThresholdTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.binaryThresholdTrackBar.Maximum = 255;
            this.binaryThresholdTrackBar.Name = "binaryThresholdTrackBar";
            this.binaryThresholdTrackBar.Size = new System.Drawing.Size(139, 56);
            this.binaryThresholdTrackBar.TabIndex = 80;
            this.binaryThresholdTrackBar.Value = 1;
            this.binaryThresholdTrackBar.ValueChanged += new System.EventHandler(this.binaryThresholdTrackBar_ValueChanged);
            // 
            // openingSizeValue
            // 
            this.openingSizeValue.AutoSize = true;
            this.openingSizeValue.Location = new System.Drawing.Point(88, 445);
            this.openingSizeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.openingSizeValue.Name = "openingSizeValue";
            this.openingSizeValue.Size = new System.Drawing.Size(42, 17);
            this.openingSizeValue.TabIndex = 85;
            this.openingSizeValue.Text = "40 px";
            this.openingSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 389);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 84;
            this.label4.Text = "Opening Size";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openingSizeTrackBar
            // 
            this.openingSizeTrackBar.LargeChange = 2;
            this.openingSizeTrackBar.Location = new System.Drawing.Point(39, 409);
            this.openingSizeTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.openingSizeTrackBar.Maximum = 50;
            this.openingSizeTrackBar.Minimum = 1;
            this.openingSizeTrackBar.Name = "openingSizeTrackBar";
            this.openingSizeTrackBar.Size = new System.Drawing.Size(139, 56);
            this.openingSizeTrackBar.TabIndex = 83;
            this.openingSizeTrackBar.Value = 40;
            this.openingSizeTrackBar.ValueChanged += new System.EventHandler(this.openingSizeTrackBar_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 839);
            this.Controls.Add(this.openingSizeValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.openingSizeTrackBar);
            this.Controls.Add(this.binaryThresholdValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.binaryThresholdTrackBar);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.blobSizeValue);
            this.Controls.Add(this.blobSizeTitle);
            this.Controls.Add(this.blobSizeTrackBar);
            this.Controls.Add(this.globalFrameRateLabel);
            this.Controls.Add(this.frameRateTitle);
            this.Controls.Add(this.frameRateTrackBar);
            this.Controls.Add(this.horizontalSeparator);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.backgroundPictureBox);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.referenceButton);
            this.Controls.Add(this.histogramEqualizationGroup);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Image Processing Environment";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.histogramEqualizationGroup.ResumeLayout(false);
            this.histogramEqualizationGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blobSizeTrackBar)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binaryThresholdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openingSizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RadioButton histogramEqualizationOn;
        private System.Windows.Forms.GroupBox histogramEqualizationGroup;
        private System.Windows.Forms.RadioButton histogramEqualizationOff;
        private System.Windows.Forms.Button referenceButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label exposureLabel;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Label frameRateLabel;
        private System.Windows.Forms.Label whiteBalanceLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label illuminanceLabel;
        private System.Windows.Forms.Label gainLabel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label shutterSpeedLabel;
        private System.Windows.Forms.ComboBox cameraSelection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton displayOff;
        private System.Windows.Forms.RadioButton displayOriginal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton segmentationOff;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton BLOBOff;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label horizontalSeparator;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.PictureBox backgroundPictureBox;
        private System.Windows.Forms.Label globalFrameRateLabel;
        private System.Windows.Forms.Label frameRateTitle;
        private System.Windows.Forms.TrackBar frameRateTrackBar;
        private System.Windows.Forms.RadioButton segmentationOn;
        private System.Windows.Forms.RadioButton saveImagesOff;
        private System.Windows.Forms.Label blobSizeValue;
        private System.Windows.Forms.Label blobSizeTitle;
        private System.Windows.Forms.TrackBar blobSizeTrackBar;
        private System.Windows.Forms.RadioButton BLOBOn;
        private System.Windows.Forms.RadioButton saveImagesOn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton textureOn;
        private System.Windows.Forms.RadioButton textureOff;
        private System.Windows.Forms.Label binaryThresholdValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar binaryThresholdTrackBar;
        private System.Windows.Forms.Label openingSizeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar openingSizeTrackBar;
        private System.Windows.Forms.RadioButton displayProcessed;
    }
}

