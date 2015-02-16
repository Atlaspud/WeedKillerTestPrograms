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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.displayOn = new System.Windows.Forms.RadioButton();
            this.displayOff = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.saveImagesOn = new System.Windows.Forms.RadioButton();
            this.saveImagesOff = new System.Windows.Forms.RadioButton();
            this.frameRateLabel = new System.Windows.Forms.Label();
            this.frameRateTitle = new System.Windows.Forms.Label();
            this.frameRateTrackBar = new System.Windows.Forms.TrackBar();
            this.blobSizeLabel = new System.Windows.Forms.Label();
            this.blobSizeTitle = new System.Windows.Forms.Label();
            this.blobSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.binaryThresholdLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.binaryThresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.morphologySizeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.morphologySizeTrackBar = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sampleSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.binSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.windowSizeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.windowSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BLOBRadioButton = new System.Windows.Forms.RadioButton();
            this.windowRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.barChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blobSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryThresholdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.morphologySizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(2, 3);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(107, 34);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(224, 3);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(108, 34);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(2, 303);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(334, 252);
            this.textBox1.TabIndex = 15;
            // 
            // browseButton
            // 
            this.browseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseButton.Location = new System.Drawing.Point(113, 3);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(107, 34);
            this.browseButton.TabIndex = 29;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.displayOn);
            this.groupBox1.Controls.Add(this.displayOff);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(126, 56);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Display";
            // 
            // displayOn
            // 
            this.displayOn.AutoSize = true;
            this.displayOn.Checked = true;
            this.displayOn.Dock = System.Windows.Forms.DockStyle.Left;
            this.displayOn.Location = new System.Drawing.Point(2, 16);
            this.displayOn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.displayOn.Name = "displayOn";
            this.displayOn.Size = new System.Drawing.Size(39, 37);
            this.displayOn.TabIndex = 31;
            this.displayOn.TabStop = true;
            this.displayOn.Text = "On";
            this.displayOn.UseVisualStyleBackColor = true;
            // 
            // displayOff
            // 
            this.displayOff.AutoSize = true;
            this.displayOff.Dock = System.Windows.Forms.DockStyle.Right;
            this.displayOff.Location = new System.Drawing.Point(85, 16);
            this.displayOff.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.displayOff.Name = "displayOff";
            this.displayOff.Size = new System.Drawing.Size(39, 37);
            this.displayOff.TabIndex = 30;
            this.displayOff.Text = "Off";
            this.displayOff.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.saveImagesOn);
            this.groupBox5.Controls.Add(this.saveImagesOff);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(2, 65);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox5.Size = new System.Drawing.Size(126, 56);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Save Images";
            // 
            // saveImagesOn
            // 
            this.saveImagesOn.AutoSize = true;
            this.saveImagesOn.Checked = true;
            this.saveImagesOn.Dock = System.Windows.Forms.DockStyle.Left;
            this.saveImagesOn.Location = new System.Drawing.Point(2, 16);
            this.saveImagesOn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveImagesOn.Name = "saveImagesOn";
            this.saveImagesOn.Size = new System.Drawing.Size(39, 37);
            this.saveImagesOn.TabIndex = 32;
            this.saveImagesOn.TabStop = true;
            this.saveImagesOn.Text = "On";
            this.saveImagesOn.UseVisualStyleBackColor = true;
            // 
            // saveImagesOff
            // 
            this.saveImagesOff.AutoSize = true;
            this.saveImagesOff.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveImagesOff.Location = new System.Drawing.Point(85, 16);
            this.saveImagesOff.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveImagesOff.Name = "saveImagesOff";
            this.saveImagesOff.Size = new System.Drawing.Size(39, 37);
            this.saveImagesOff.TabIndex = 31;
            this.saveImagesOff.Text = "Off";
            this.saveImagesOff.UseVisualStyleBackColor = true;
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.AutoSize = true;
            this.frameRateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frameRateLabel.Location = new System.Drawing.Point(3, 58);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.Size = new System.Drawing.Size(88, 20);
            this.frameRateLabel.TabIndex = 75;
            this.frameRateLabel.Text = "2.5 fps";
            this.frameRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameRateTitle
            // 
            this.frameRateTitle.AutoSize = true;
            this.frameRateTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frameRateTitle.Location = new System.Drawing.Point(3, 0);
            this.frameRateTitle.Name = "frameRateTitle";
            this.frameRateTitle.Size = new System.Drawing.Size(88, 19);
            this.frameRateTitle.TabIndex = 74;
            this.frameRateTitle.Text = "Frame Rate";
            this.frameRateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameRateTrackBar
            // 
            this.frameRateTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frameRateTrackBar.LargeChange = 2;
            this.frameRateTrackBar.Location = new System.Drawing.Point(3, 22);
            this.frameRateTrackBar.Minimum = 1;
            this.frameRateTrackBar.Name = "frameRateTrackBar";
            this.frameRateTrackBar.Size = new System.Drawing.Size(88, 33);
            this.frameRateTrackBar.TabIndex = 73;
            this.frameRateTrackBar.Value = 5;
            this.frameRateTrackBar.ValueChanged += new System.EventHandler(this.frameRateTrackBar_ValueChanged);
            // 
            // blobSizeLabel
            // 
            this.blobSizeLabel.AutoSize = true;
            this.blobSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blobSizeLabel.Location = new System.Drawing.Point(3, 58);
            this.blobSizeLabel.Name = "blobSizeLabel";
            this.blobSizeLabel.Size = new System.Drawing.Size(88, 20);
            this.blobSizeLabel.TabIndex = 79;
            this.blobSizeLabel.Text = "120 px";
            this.blobSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blobSizeTitle
            // 
            this.blobSizeTitle.AutoSize = true;
            this.blobSizeTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blobSizeTitle.Location = new System.Drawing.Point(3, 0);
            this.blobSizeTitle.Name = "blobSizeTitle";
            this.blobSizeTitle.Size = new System.Drawing.Size(88, 19);
            this.blobSizeTitle.TabIndex = 78;
            this.blobSizeTitle.Text = "BLOB Size";
            this.blobSizeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blobSizeTrackBar
            // 
            this.blobSizeTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blobSizeTrackBar.LargeChange = 2;
            this.blobSizeTrackBar.Location = new System.Drawing.Point(3, 22);
            this.blobSizeTrackBar.Maximum = 500;
            this.blobSizeTrackBar.Minimum = 1;
            this.blobSizeTrackBar.Name = "blobSizeTrackBar";
            this.blobSizeTrackBar.Size = new System.Drawing.Size(88, 33);
            this.blobSizeTrackBar.TabIndex = 77;
            this.blobSizeTrackBar.Value = 120;
            this.blobSizeTrackBar.ValueChanged += new System.EventHandler(this.blobSizeTrackBar_ValueChanged);
            // 
            // binaryThresholdLabel
            // 
            this.binaryThresholdLabel.AutoSize = true;
            this.binaryThresholdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binaryThresholdLabel.Location = new System.Drawing.Point(3, 58);
            this.binaryThresholdLabel.Name = "binaryThresholdLabel";
            this.binaryThresholdLabel.Size = new System.Drawing.Size(88, 20);
            this.binaryThresholdLabel.TabIndex = 82;
            this.binaryThresholdLabel.Text = "20";
            this.binaryThresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 81;
            this.label2.Text = "Threshold";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // binaryThresholdTrackBar
            // 
            this.binaryThresholdTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binaryThresholdTrackBar.LargeChange = 2;
            this.binaryThresholdTrackBar.Location = new System.Drawing.Point(3, 22);
            this.binaryThresholdTrackBar.Maximum = 255;
            this.binaryThresholdTrackBar.Name = "binaryThresholdTrackBar";
            this.binaryThresholdTrackBar.Size = new System.Drawing.Size(88, 33);
            this.binaryThresholdTrackBar.TabIndex = 80;
            this.binaryThresholdTrackBar.Value = 20;
            this.binaryThresholdTrackBar.ValueChanged += new System.EventHandler(this.binaryThresholdTrackBar_ValueChanged);
            // 
            // morphologySizeLabel
            // 
            this.morphologySizeLabel.AutoSize = true;
            this.morphologySizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.morphologySizeLabel.Location = new System.Drawing.Point(3, 58);
            this.morphologySizeLabel.Name = "morphologySizeLabel";
            this.morphologySizeLabel.Size = new System.Drawing.Size(88, 20);
            this.morphologySizeLabel.TabIndex = 85;
            this.morphologySizeLabel.Text = "40 px";
            this.morphologySizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 84;
            this.label4.Text = "Morphology";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // morphologySizeTrackBar
            // 
            this.morphologySizeTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.morphologySizeTrackBar.LargeChange = 2;
            this.morphologySizeTrackBar.Location = new System.Drawing.Point(3, 22);
            this.morphologySizeTrackBar.Maximum = 50;
            this.morphologySizeTrackBar.Minimum = 1;
            this.morphologySizeTrackBar.Name = "morphologySizeTrackBar";
            this.morphologySizeTrackBar.Size = new System.Drawing.Size(88, 33);
            this.morphologySizeTrackBar.TabIndex = 83;
            this.morphologySizeTrackBar.Value = 40;
            this.morphologySizeTrackBar.ValueChanged += new System.EventHandler(this.openingSizeTrackBar_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 273);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(2, 282);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(334, 273);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 87;
            this.pictureBox2.TabStop = false;
            // 
            // sampleSizeLabel
            // 
            this.sampleSizeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sampleSizeLabel.AutoSize = true;
            this.sampleSizeLabel.Location = new System.Drawing.Point(40, 63);
            this.sampleSizeLabel.Name = "sampleSizeLabel";
            this.sampleSizeLabel.Size = new System.Drawing.Size(13, 13);
            this.sampleSizeLabel.TabIndex = 94;
            this.sampleSizeLabel.Text = "1";
            this.sampleSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 93;
            this.label3.Text = "Bin Size";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // binSizeTrackBar
            // 
            this.binSizeTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binSizeTrackBar.LargeChange = 15;
            this.binSizeTrackBar.Location = new System.Drawing.Point(3, 23);
            this.binSizeTrackBar.Maximum = 360;
            this.binSizeTrackBar.Minimum = 1;
            this.binSizeTrackBar.Name = "binSizeTrackBar";
            this.binSizeTrackBar.Size = new System.Drawing.Size(88, 34);
            this.binSizeTrackBar.TabIndex = 92;
            this.binSizeTrackBar.Value = 1;
            this.binSizeTrackBar.ValueChanged += new System.EventHandler(this.binSizeTrackBar_ValueChanged);
            // 
            // windowSizeLabel
            // 
            this.windowSizeLabel.AutoSize = true;
            this.windowSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowSizeLabel.Location = new System.Drawing.Point(3, 60);
            this.windowSizeLabel.Name = "windowSizeLabel";
            this.windowSizeLabel.Size = new System.Drawing.Size(88, 20);
            this.windowSizeLabel.TabIndex = 91;
            this.windowSizeLabel.Text = "100 px";
            this.windowSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 90;
            this.label6.Text = "Window Size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // windowSizeTrackBar
            // 
            this.windowSizeTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowSizeTrackBar.Enabled = false;
            this.windowSizeTrackBar.LargeChange = 2;
            this.windowSizeTrackBar.Location = new System.Drawing.Point(3, 23);
            this.windowSizeTrackBar.Maximum = 250;
            this.windowSizeTrackBar.Minimum = 1;
            this.windowSizeTrackBar.Name = "windowSizeTrackBar";
            this.windowSizeTrackBar.Size = new System.Drawing.Size(88, 34);
            this.windowSizeTrackBar.TabIndex = 89;
            this.windowSizeTrackBar.Value = 100;
            this.windowSizeTrackBar.ValueChanged += new System.EventHandler(this.windowSizeTrackBar_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BLOBRadioButton);
            this.groupBox2.Controls.Add(this.windowRadioButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 127);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox2.Size = new System.Drawing.Size(126, 56);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texture Window";
            // 
            // BLOBRadioButton
            // 
            this.BLOBRadioButton.AutoSize = true;
            this.BLOBRadioButton.Checked = true;
            this.BLOBRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.BLOBRadioButton.Location = new System.Drawing.Point(2, 16);
            this.BLOBRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BLOBRadioButton.Name = "BLOBRadioButton";
            this.BLOBRadioButton.Size = new System.Drawing.Size(53, 37);
            this.BLOBRadioButton.TabIndex = 32;
            this.BLOBRadioButton.TabStop = true;
            this.BLOBRadioButton.Text = "BLOB";
            this.BLOBRadioButton.UseVisualStyleBackColor = true;
            this.BLOBRadioButton.CheckedChanged += new System.EventHandler(this.BLOBRadioButton_CheckedChanged);
            // 
            // windowRadioButton
            // 
            this.windowRadioButton.AutoSize = true;
            this.windowRadioButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.windowRadioButton.Location = new System.Drawing.Point(60, 16);
            this.windowRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.windowRadioButton.Name = "windowRadioButton";
            this.windowRadioButton.Size = new System.Drawing.Size(64, 37);
            this.windowRadioButton.TabIndex = 31;
            this.windowRadioButton.Text = "Window";
            this.windowRadioButton.UseVisualStyleBackColor = true;
            this.windowRadioButton.CheckedChanged += new System.EventHandler(this.windowRadioButton_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 562);
            this.tableLayoutPanel1.TabIndex = 95;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(344, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(338, 558);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(338, 558);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.startButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.stopButton, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.browseButton, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(334, 40);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 46);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(334, 252);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.barChart, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(202, 2);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(130, 248);
            this.tableLayoutPanel6.TabIndex = 0;
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
            this.barChart.Location = new System.Drawing.Point(3, 189);
            this.barChart.Name = "barChart";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.barChart.Series.Add(series1);
            this.barChart.Size = new System.Drawing.Size(124, 56);
            this.barChart.TabIndex = 53;
            this.barChart.Text = "chart1";
            this.barChart.Visible = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel14, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel13, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel12, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel10, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(196, 248);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.windowSizeTrackBar, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.windowSizeLabel, 0, 2);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(2, 166);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 3;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(94, 80);
            this.tableLayoutPanel14.TabIndex = 102;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.morphologySizeLabel, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.morphologySizeTrackBar, 0, 1);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(100, 84);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 3;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(94, 78);
            this.tableLayoutPanel13.TabIndex = 101;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.binaryThresholdLabel, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.binaryThresholdTrackBar, 0, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(2, 84);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 3;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(94, 78);
            this.tableLayoutPanel12.TabIndex = 100;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.blobSizeTitle, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.blobSizeLabel, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.blobSizeTrackBar, 0, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(100, 2);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(94, 78);
            this.tableLayoutPanel10.TabIndex = 98;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.frameRateTitle, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.frameRateLabel, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.frameRateTrackBar, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 3;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(94, 78);
            this.tableLayoutPanel11.TabIndex = 99;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.sampleSizeLabel, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.binSizeTrackBar, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(100, 166);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(94, 80);
            this.tableLayoutPanel8.TabIndex = 96;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Texture Classification Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blobSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binaryThresholdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.morphologySizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowSizeTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton displayOff;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label frameRateLabel;
        private System.Windows.Forms.Label frameRateTitle;
        private System.Windows.Forms.TrackBar frameRateTrackBar;
        private System.Windows.Forms.RadioButton saveImagesOff;
        private System.Windows.Forms.Label blobSizeLabel;
        private System.Windows.Forms.Label blobSizeTitle;
        private System.Windows.Forms.TrackBar blobSizeTrackBar;
        private System.Windows.Forms.RadioButton saveImagesOn;
        private System.Windows.Forms.Label binaryThresholdLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar binaryThresholdTrackBar;
        private System.Windows.Forms.Label morphologySizeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar morphologySizeTrackBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton displayOn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label sampleSizeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar binSizeTrackBar;
        private System.Windows.Forms.Label windowSizeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar windowSizeTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton BLOBRadioButton;
        private System.Windows.Forms.RadioButton windowRadioButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.DataVisualization.Charting.Chart barChart;
    }
}

