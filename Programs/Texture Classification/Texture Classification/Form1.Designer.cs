namespace Texture_Classification
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
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.displayOn = new System.Windows.Forms.RadioButton();
            this.displayOff = new System.Windows.Forms.RadioButton();
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
            this.frameRateLabel = new System.Windows.Forms.Label();
            this.frameRateTitle = new System.Windows.Forms.Label();
            this.frameRateTrackBar = new System.Windows.Forms.TrackBar();
            this.blobSizeLabel = new System.Windows.Forms.Label();
            this.blobSizeTitle = new System.Windows.Forms.Label();
            this.blobSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textureOn = new System.Windows.Forms.RadioButton();
            this.textureOff = new System.Windows.Forms.RadioButton();
            this.binaryThresholdLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.binaryThresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.morphologySizeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.morphologySizeTrackBar = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.classificationOn = new System.Windows.Forms.RadioButton();
            this.classificationOff = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.sampleSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sampleSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.windowSizeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.windowSizeTrackBar = new System.Windows.Forms.TrackBar();
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
            ((System.ComponentModel.ISupportInitialize)(this.morphologySizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
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
            this.textBox1.Location = new System.Drawing.Point(12, 434);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(398, 170);
            this.textBox1.TabIndex = 15;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM7";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(214, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(95, 32);
            this.browseButton.TabIndex = 29;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.displayOn);
            this.groupBox1.Controls.Add(this.displayOff);
            this.groupBox1.Location = new System.Drawing.Point(214, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 53);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Display";
            // 
            // displayOn
            // 
            this.displayOn.AutoSize = true;
            this.displayOn.Checked = true;
            this.displayOn.Location = new System.Drawing.Point(47, 22);
            this.displayOn.Name = "displayOn";
            this.displayOn.Size = new System.Drawing.Size(48, 21);
            this.displayOn.TabIndex = 31;
            this.displayOn.TabStop = true;
            this.displayOn.Text = "On";
            this.displayOn.UseVisualStyleBackColor = true;
            // 
            // displayOff
            // 
            this.displayOff.AutoSize = true;
            this.displayOff.Location = new System.Drawing.Point(101, 22);
            this.displayOff.Name = "displayOff";
            this.displayOff.Size = new System.Drawing.Size(48, 21);
            this.displayOff.TabIndex = 30;
            this.displayOff.Text = "Off";
            this.displayOff.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.segmentationOn);
            this.groupBox3.Controls.Add(this.segmentationOff);
            this.groupBox3.Location = new System.Drawing.Point(214, 174);
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
            this.groupBox4.Location = new System.Drawing.Point(214, 239);
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
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(315, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 32);
            this.saveButton.TabIndex = 53;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.saveImagesOn);
            this.groupBox5.Controls.Add(this.saveImagesOff);
            this.groupBox5.Location = new System.Drawing.Point(214, 109);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(196, 59);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save Images";
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
            this.horizontalSeparator.Location = new System.Drawing.Point(-3, 640);
            this.horizontalSeparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.horizontalSeparator.Name = "horizontalSeparator";
            this.horizontalSeparator.Size = new System.Drawing.Size(816, 2);
            this.horizontalSeparator.TabIndex = 58;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackColor = System.Drawing.Color.White;
            this.logoPictureBox.Location = new System.Drawing.Point(340, 642);
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
            this.backgroundPictureBox.Location = new System.Drawing.Point(-3, 640);
            this.backgroundPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(816, 80);
            this.backgroundPictureBox.TabIndex = 60;
            this.backgroundPictureBox.TabStop = false;
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.AutoSize = true;
            this.frameRateLabel.Location = new System.Drawing.Point(34, 115);
            this.frameRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.Size = new System.Drawing.Size(51, 17);
            this.frameRateLabel.TabIndex = 75;
            this.frameRateLabel.Text = "2.5 fps";
            this.frameRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameRateTitle
            // 
            this.frameRateTitle.AutoSize = true;
            this.frameRateTitle.Location = new System.Drawing.Point(17, 52);
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
            this.frameRateTrackBar.Location = new System.Drawing.Point(8, 73);
            this.frameRateTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.frameRateTrackBar.Minimum = 1;
            this.frameRateTrackBar.Name = "frameRateTrackBar";
            this.frameRateTrackBar.Size = new System.Drawing.Size(100, 56);
            this.frameRateTrackBar.TabIndex = 73;
            this.frameRateTrackBar.Value = 5;
            this.frameRateTrackBar.ValueChanged += new System.EventHandler(this.frameRateTrackBar_ValueChanged);
            // 
            // blobSizeLabel
            // 
            this.blobSizeLabel.AutoSize = true;
            this.blobSizeLabel.Location = new System.Drawing.Point(134, 115);
            this.blobSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blobSizeLabel.Name = "blobSizeLabel";
            this.blobSizeLabel.Size = new System.Drawing.Size(50, 17);
            this.blobSizeLabel.TabIndex = 79;
            this.blobSizeLabel.Text = "120 px";
            this.blobSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blobSizeTitle
            // 
            this.blobSizeTitle.AutoSize = true;
            this.blobSizeTitle.Location = new System.Drawing.Point(120, 52);
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
            this.blobSizeTrackBar.Location = new System.Drawing.Point(108, 73);
            this.blobSizeTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.blobSizeTrackBar.Maximum = 500;
            this.blobSizeTrackBar.Minimum = 1;
            this.blobSizeTrackBar.Name = "blobSizeTrackBar";
            this.blobSizeTrackBar.Size = new System.Drawing.Size(100, 56);
            this.blobSizeTrackBar.TabIndex = 77;
            this.blobSizeTrackBar.Value = 120;
            this.blobSizeTrackBar.ValueChanged += new System.EventHandler(this.blobSizeTrackBar_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textureOn);
            this.groupBox6.Controls.Add(this.textureOff);
            this.groupBox6.Location = new System.Drawing.Point(214, 304);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(196, 59);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Texture Extraction";
            // 
            // textureOn
            // 
            this.textureOn.AutoSize = true;
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
            this.textureOff.Location = new System.Drawing.Point(101, 23);
            this.textureOff.Name = "textureOff";
            this.textureOff.Size = new System.Drawing.Size(48, 21);
            this.textureOff.TabIndex = 31;
            this.textureOff.TabStop = true;
            this.textureOff.Text = "Off";
            this.textureOff.UseVisualStyleBackColor = true;
            // 
            // binaryThresholdLabel
            // 
            this.binaryThresholdLabel.AutoSize = true;
            this.binaryThresholdLabel.Location = new System.Drawing.Point(47, 208);
            this.binaryThresholdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.binaryThresholdLabel.Name = "binaryThresholdLabel";
            this.binaryThresholdLabel.Size = new System.Drawing.Size(24, 17);
            this.binaryThresholdLabel.TabIndex = 82;
            this.binaryThresholdLabel.Text = "20";
            this.binaryThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 81;
            this.label2.Text = "Threshold";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // binaryThresholdTrackBar
            // 
            this.binaryThresholdTrackBar.LargeChange = 2;
            this.binaryThresholdTrackBar.Location = new System.Drawing.Point(8, 169);
            this.binaryThresholdTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.binaryThresholdTrackBar.Maximum = 255;
            this.binaryThresholdTrackBar.Name = "binaryThresholdTrackBar";
            this.binaryThresholdTrackBar.Size = new System.Drawing.Size(100, 56);
            this.binaryThresholdTrackBar.TabIndex = 80;
            this.binaryThresholdTrackBar.Value = 20;
            this.binaryThresholdTrackBar.ValueChanged += new System.EventHandler(this.binaryThresholdTrackBar_ValueChanged);
            // 
            // morphologySizeLabel
            // 
            this.morphologySizeLabel.AutoSize = true;
            this.morphologySizeLabel.Location = new System.Drawing.Point(139, 208);
            this.morphologySizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.morphologySizeLabel.Name = "morphologySizeLabel";
            this.morphologySizeLabel.Size = new System.Drawing.Size(42, 17);
            this.morphologySizeLabel.TabIndex = 85;
            this.morphologySizeLabel.Text = "40 px";
            this.morphologySizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 84;
            this.label4.Text = "Morphology";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // morphologySizeTrackBar
            // 
            this.morphologySizeTrackBar.LargeChange = 2;
            this.morphologySizeTrackBar.Location = new System.Drawing.Point(108, 169);
            this.morphologySizeTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.morphologySizeTrackBar.Maximum = 50;
            this.morphologySizeTrackBar.Minimum = 1;
            this.morphologySizeTrackBar.Name = "morphologySizeTrackBar";
            this.morphologySizeTrackBar.Size = new System.Drawing.Size(100, 56);
            this.morphologySizeTrackBar.TabIndex = 83;
            this.morphologySizeTrackBar.Value = 40;
            this.morphologySizeTrackBar.ValueChanged += new System.EventHandler(this.openingSizeTrackBar_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(416, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 308);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(416, 326);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(385, 308);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 87;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.classificationOn);
            this.groupBox2.Controls.Add(this.classificationOff);
            this.groupBox2.Location = new System.Drawing.Point(214, 369);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 59);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Classification";
            // 
            // classificationOn
            // 
            this.classificationOn.AutoSize = true;
            this.classificationOn.Enabled = false;
            this.classificationOn.Location = new System.Drawing.Point(47, 23);
            this.classificationOn.Name = "classificationOn";
            this.classificationOn.Size = new System.Drawing.Size(48, 21);
            this.classificationOn.TabIndex = 32;
            this.classificationOn.Text = "On";
            this.classificationOn.UseVisualStyleBackColor = true;
            // 
            // classificationOff
            // 
            this.classificationOff.AutoSize = true;
            this.classificationOff.Checked = true;
            this.classificationOff.Enabled = false;
            this.classificationOff.Location = new System.Drawing.Point(101, 23);
            this.classificationOff.Name = "classificationOff";
            this.classificationOff.Size = new System.Drawing.Size(48, 21);
            this.classificationOff.TabIndex = 31;
            this.classificationOff.TabStop = true;
            this.classificationOff.Text = "Off";
            this.classificationOff.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 333;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 610);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(398, 23);
            this.progressBar1.TabIndex = 88;
            // 
            // sampleSizeLabel
            // 
            this.sampleSizeLabel.AutoSize = true;
            this.sampleSizeLabel.Location = new System.Drawing.Point(148, 300);
            this.sampleSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sampleSizeLabel.Name = "sampleSizeLabel";
            this.sampleSizeLabel.Size = new System.Drawing.Size(16, 17);
            this.sampleSizeLabel.TabIndex = 94;
            this.sampleSizeLabel.Text = "5";
            this.sampleSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 240);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 93;
            this.label3.Text = "Sample Size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sampleSizeTrackBar
            // 
            this.sampleSizeTrackBar.LargeChange = 2;
            this.sampleSizeTrackBar.Location = new System.Drawing.Point(108, 261);
            this.sampleSizeTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.sampleSizeTrackBar.Maximum = 20;
            this.sampleSizeTrackBar.Minimum = 1;
            this.sampleSizeTrackBar.Name = "sampleSizeTrackBar";
            this.sampleSizeTrackBar.Size = new System.Drawing.Size(100, 56);
            this.sampleSizeTrackBar.TabIndex = 92;
            this.sampleSizeTrackBar.Value = 5;
            this.sampleSizeTrackBar.ValueChanged += new System.EventHandler(this.sampleSizeTrackBar_ValueChanged);
            // 
            // windowSizeLabel
            // 
            this.windowSizeLabel.AutoSize = true;
            this.windowSizeLabel.Location = new System.Drawing.Point(39, 300);
            this.windowSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.windowSizeLabel.Name = "windowSizeLabel";
            this.windowSizeLabel.Size = new System.Drawing.Size(50, 17);
            this.windowSizeLabel.TabIndex = 91;
            this.windowSizeLabel.Text = "100 px";
            this.windowSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 240);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 90;
            this.label6.Text = "Window Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windowSizeTrackBar
            // 
            this.windowSizeTrackBar.LargeChange = 2;
            this.windowSizeTrackBar.Location = new System.Drawing.Point(8, 261);
            this.windowSizeTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.windowSizeTrackBar.Maximum = 250;
            this.windowSizeTrackBar.Minimum = 1;
            this.windowSizeTrackBar.Name = "windowSizeTrackBar";
            this.windowSizeTrackBar.Size = new System.Drawing.Size(100, 56);
            this.windowSizeTrackBar.TabIndex = 89;
            this.windowSizeTrackBar.Value = 100;
            this.windowSizeTrackBar.ValueChanged += new System.EventHandler(this.windowSizeTrackBar_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 711);
            this.Controls.Add(this.sampleSizeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sampleSizeTrackBar);
            this.Controls.Add(this.windowSizeLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.windowSizeTrackBar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.morphologySizeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.morphologySizeTrackBar);
            this.Controls.Add(this.binaryThresholdLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.binaryThresholdTrackBar);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.blobSizeLabel);
            this.Controls.Add(this.blobSizeTitle);
            this.Controls.Add(this.blobSizeTrackBar);
            this.Controls.Add(this.frameRateLabel);
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
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Texture Classification Test";
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
            ((System.ComponentModel.ISupportInitialize)(this.morphologySizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton displayOff;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton segmentationOff;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton BLOBOff;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label horizontalSeparator;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.PictureBox backgroundPictureBox;
        private System.Windows.Forms.Label frameRateLabel;
        private System.Windows.Forms.Label frameRateTitle;
        private System.Windows.Forms.TrackBar frameRateTrackBar;
        private System.Windows.Forms.RadioButton segmentationOn;
        private System.Windows.Forms.RadioButton saveImagesOff;
        private System.Windows.Forms.Label blobSizeLabel;
        private System.Windows.Forms.Label blobSizeTitle;
        private System.Windows.Forms.TrackBar blobSizeTrackBar;
        private System.Windows.Forms.RadioButton BLOBOn;
        private System.Windows.Forms.RadioButton saveImagesOn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton textureOn;
        private System.Windows.Forms.RadioButton textureOff;
        private System.Windows.Forms.Label binaryThresholdLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar binaryThresholdTrackBar;
        private System.Windows.Forms.Label morphologySizeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar morphologySizeTrackBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton displayOn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton classificationOn;
        private System.Windows.Forms.RadioButton classificationOff;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label sampleSizeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar sampleSizeTrackBar;
        private System.Windows.Forms.Label windowSizeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar windowSizeTrackBar;
    }
}

