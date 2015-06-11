namespace PatchExtraction
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.workingPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.runBtn = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.fileName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileCountLabel = new System.Windows.Forms.Label();
            this.windowCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalLantanaLabel = new System.Windows.Forms.Label();
            this.totalNonLantanaLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.maskPictureBox = new System.Windows.Forms.PictureBox();
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.patchPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.overlapComboBox = new System.Windows.Forms.ComboBox();
            this.blockSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cellSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.patchSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.rotationInvariantCheckBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.derivativeMaskComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.blockNormalisationCheckBox = new System.Windows.Forms.CheckBox();
            this.interpolationComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.colourSpaceComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shadowHighlightCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gammaCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.segmentationCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.smoothingComboBox = new System.Windows.Forms.ComboBox();
            this.signedOrientationCheckBox = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.binComboBox = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workingPictureBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchPictureBox)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.workingPictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.maskPictureBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.originalPictureBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.patchPictureBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1261, 673);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // workingPictureBox
            // 
            this.workingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workingPictureBox.Location = new System.Drawing.Point(424, 4);
            this.workingPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.workingPictureBox.Name = "workingPictureBox";
            this.workingPictureBox.Size = new System.Drawing.Size(412, 328);
            this.workingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.workingPictureBox.TabIndex = 2;
            this.workingPictureBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(412, 328);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.runBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBrowse, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(404, 57);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // runBtn
            // 
            this.runBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runBtn.Enabled = false;
            this.runBtn.Location = new System.Drawing.Point(4, 4);
            this.runBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(194, 49);
            this.runBtn.TabIndex = 0;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.Location = new System.Drawing.Point(206, 4);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(194, 49);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.fileName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.fileNameLabel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.fileCountLabel, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.windowCountLabel, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.totalLantanaLabel, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.totalNonLantanaLabel, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.textBox, 0, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 69);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(404, 255);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // fileName
            // 
            this.fileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(4, 4);
            this.fileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(75, 17);
            this.fileName.TabIndex = 0;
            this.fileName.Text = "File Name:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "File Count:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Window Count:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(296, 4);
            this.fileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(13, 17);
            this.fileNameLabel.TabIndex = 6;
            this.fileNameLabel.Text = "-";
            // 
            // fileCountLabel
            // 
            this.fileCountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fileCountLabel.AutoSize = true;
            this.fileCountLabel.Location = new System.Drawing.Point(296, 29);
            this.fileCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fileCountLabel.Name = "fileCountLabel";
            this.fileCountLabel.Size = new System.Drawing.Size(13, 17);
            this.fileCountLabel.TabIndex = 7;
            this.fileCountLabel.Text = "-";
            // 
            // windowCountLabel
            // 
            this.windowCountLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.windowCountLabel.AutoSize = true;
            this.windowCountLabel.Location = new System.Drawing.Point(296, 54);
            this.windowCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.windowCountLabel.Name = "windowCountLabel";
            this.windowCountLabel.Size = new System.Drawing.Size(13, 17);
            this.windowCountLabel.TabIndex = 8;
            this.windowCountLabel.Text = "-";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Lantana:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Non-Lantana:";
            // 
            // totalLantanaLabel
            // 
            this.totalLantanaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totalLantanaLabel.AutoSize = true;
            this.totalLantanaLabel.Location = new System.Drawing.Point(296, 79);
            this.totalLantanaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalLantanaLabel.Name = "totalLantanaLabel";
            this.totalLantanaLabel.Size = new System.Drawing.Size(13, 17);
            this.totalLantanaLabel.TabIndex = 9;
            this.totalLantanaLabel.Text = "-";
            // 
            // totalNonLantanaLabel
            // 
            this.totalNonLantanaLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totalNonLantanaLabel.AutoSize = true;
            this.totalNonLantanaLabel.Location = new System.Drawing.Point(296, 104);
            this.totalNonLantanaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalNonLantanaLabel.Name = "totalNonLantanaLabel";
            this.totalNonLantanaLabel.Size = new System.Drawing.Size(13, 17);
            this.totalNonLantanaLabel.TabIndex = 10;
            this.totalNonLantanaLabel.Text = "-";
            // 
            // textBox
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.textBox, 2);
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(3, 127);
            this.textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(398, 126);
            this.textBox.TabIndex = 11;
            // 
            // maskPictureBox
            // 
            this.maskPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maskPictureBox.Location = new System.Drawing.Point(844, 4);
            this.maskPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.maskPictureBox.Name = "maskPictureBox";
            this.maskPictureBox.Size = new System.Drawing.Size(413, 328);
            this.maskPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maskPictureBox.TabIndex = 5;
            this.maskPictureBox.TabStop = false;
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalPictureBox.Location = new System.Drawing.Point(844, 340);
            this.originalPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(413, 329);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalPictureBox.TabIndex = 6;
            this.originalPictureBox.TabStop = false;
            // 
            // patchPictureBox
            // 
            this.patchPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patchPictureBox.Location = new System.Drawing.Point(424, 340);
            this.patchPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.patchPictureBox.Name = "patchPictureBox";
            this.patchPictureBox.Size = new System.Drawing.Size(412, 329);
            this.patchPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.patchPictureBox.TabIndex = 3;
            this.patchPictureBox.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 338);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(414, 333);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel9.Controls.Add(this.overlapComboBox, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.blockSizeComboBox, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel9.Controls.Add(this.cellSizeComboBox, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.patchSizeComboBox, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 168);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(201, 163);
            this.tableLayoutPanel9.TabIndex = 16;
            // 
            // overlapComboBox
            // 
            this.overlapComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overlapComboBox.FormattingEnabled = true;
            this.overlapComboBox.Items.AddRange(new object[] {
            "0",
            "1/4",
            "1/2",
            "3/4"});
            this.overlapComboBox.Location = new System.Drawing.Point(124, 124);
            this.overlapComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.overlapComboBox.Name = "overlapComboBox";
            this.overlapComboBox.Size = new System.Drawing.Size(73, 24);
            this.overlapComboBox.TabIndex = 37;
            this.overlapComboBox.Text = "1/2";
            // 
            // blockSizeComboBox
            // 
            this.blockSizeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blockSizeComboBox.FormattingEnabled = true;
            this.blockSizeComboBox.Items.AddRange(new object[] {
            "1x1",
            "2x2",
            "3x3",
            "4x4"});
            this.blockSizeComboBox.Location = new System.Drawing.Point(124, 44);
            this.blockSizeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blockSizeComboBox.Name = "blockSizeComboBox";
            this.blockSizeComboBox.Size = new System.Drawing.Size(73, 24);
            this.blockSizeComboBox.TabIndex = 35;
            this.blockSizeComboBox.Text = "2x2";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 120);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 17);
            this.label17.TabIndex = 34;
            this.label17.Text = "Block Overlap:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cellSizeComboBox
            // 
            this.cellSizeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cellSizeComboBox.FormattingEnabled = true;
            this.cellSizeComboBox.Items.AddRange(new object[] {
            "4x4",
            "6x6",
            "8x8",
            "10x10",
            "12x12"});
            this.cellSizeComboBox.Location = new System.Drawing.Point(124, 84);
            this.cellSizeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cellSizeComboBox.Name = "cellSizeComboBox";
            this.cellSizeComboBox.Size = new System.Drawing.Size(73, 24);
            this.cellSizeComboBox.TabIndex = 36;
            this.cellSizeComboBox.Text = "8x8";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 34);
            this.label15.TabIndex = 32;
            this.label15.Text = "Block Size (cells):";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 17);
            this.label16.TabIndex = 33;
            this.label16.Text = "Cell Size (px):";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // patchSizeComboBox
            // 
            this.patchSizeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patchSizeComboBox.FormattingEnabled = true;
            this.patchSizeComboBox.Items.AddRange(new object[] {
            "64",
            "96",
            "128"});
            this.patchSizeComboBox.Location = new System.Drawing.Point(124, 4);
            this.patchSizeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.patchSizeComboBox.Name = "patchSizeComboBox";
            this.patchSizeComboBox.Size = new System.Drawing.Size(73, 24);
            this.patchSizeComboBox.TabIndex = 30;
            this.patchSizeComboBox.Text = "96";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Patch Size (px):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel8.Controls.Add(this.rotationInvariantCheckBox, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.derivativeMaskComboBox, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label20, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.label18, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.blockNormalisationCheckBox, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.interpolationComboBox, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(210, 168);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 4;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(201, 163);
            this.tableLayoutPanel8.TabIndex = 15;
            // 
            // rotationInvariantCheckBox
            // 
            this.rotationInvariantCheckBox.AutoSize = true;
            this.rotationInvariantCheckBox.Checked = true;
            this.rotationInvariantCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rotationInvariantCheckBox.Enabled = false;
            this.rotationInvariantCheckBox.Location = new System.Drawing.Point(123, 122);
            this.rotationInvariantCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rotationInvariantCheckBox.Name = "rotationInvariantCheckBox";
            this.rotationInvariantCheckBox.Size = new System.Drawing.Size(18, 17);
            this.rotationInvariantCheckBox.TabIndex = 42;
            this.rotationInvariantCheckBox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "Derivative Mask:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // derivativeMaskComboBox
            // 
            this.derivativeMaskComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivativeMaskComboBox.Enabled = false;
            this.derivativeMaskComboBox.FormattingEnabled = true;
            this.derivativeMaskComboBox.Items.AddRange(new object[] {
            "1D Centred",
            "1D Non-Centred",
            "1D Cubic-Corrected",
            "2D Roberts Cross",
            "3D Prewitt",
            "3D Sobel"});
            this.derivativeMaskComboBox.Location = new System.Drawing.Point(124, 4);
            this.derivativeMaskComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.derivativeMaskComboBox.Name = "derivativeMaskComboBox";
            this.derivativeMaskComboBox.Size = new System.Drawing.Size(73, 24);
            this.derivativeMaskComboBox.TabIndex = 37;
            this.derivativeMaskComboBox.Text = "3D Sobel";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 34);
            this.label20.TabIndex = 41;
            this.label20.Text = "Rotation Invariant:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 34);
            this.label18.TabIndex = 34;
            this.label18.Text = "Block Normalisation:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // blockNormalisationCheckBox
            // 
            this.blockNormalisationCheckBox.AutoSize = true;
            this.blockNormalisationCheckBox.Checked = true;
            this.blockNormalisationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blockNormalisationCheckBox.Enabled = false;
            this.blockNormalisationCheckBox.Location = new System.Drawing.Point(123, 82);
            this.blockNormalisationCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blockNormalisationCheckBox.Name = "blockNormalisationCheckBox";
            this.blockNormalisationCheckBox.Size = new System.Drawing.Size(18, 17);
            this.blockNormalisationCheckBox.TabIndex = 38;
            this.blockNormalisationCheckBox.UseVisualStyleBackColor = true;
            // 
            // interpolationComboBox
            // 
            this.interpolationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interpolationComboBox.Enabled = false;
            this.interpolationComboBox.FormattingEnabled = true;
            this.interpolationComboBox.Items.AddRange(new object[] {
            "None",
            "Linear",
            "Trilinear"});
            this.interpolationComboBox.Location = new System.Drawing.Point(124, 44);
            this.interpolationComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.interpolationComboBox.Name = "interpolationComboBox";
            this.interpolationComboBox.Size = new System.Drawing.Size(73, 24);
            this.interpolationComboBox.TabIndex = 40;
            this.interpolationComboBox.Text = "Trilinear";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 17);
            this.label12.TabIndex = 39;
            this.label12.Text = "Interpolation:";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.Controls.Add(this.colourSpaceComboBox, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.shadowHighlightCheckBox, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.gammaCheckBox, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.segmentationCheckBox, 1, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(201, 162);
            this.tableLayoutPanel6.TabIndex = 13;
            // 
            // colourSpaceComboBox
            // 
            this.colourSpaceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colourSpaceComboBox.FormattingEnabled = true;
            this.colourSpaceComboBox.Items.AddRange(new object[] {
            "RGB",
            "Gray"});
            this.colourSpaceComboBox.Location = new System.Drawing.Point(124, 4);
            this.colourSpaceComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.colourSpaceComboBox.Name = "colourSpaceComboBox";
            this.colourSpaceComboBox.Size = new System.Drawing.Size(73, 24);
            this.colourSpaceComboBox.TabIndex = 30;
            this.colourSpaceComboBox.Text = "RGB";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "Colour Space:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 34);
            this.label3.TabIndex = 22;
            this.label3.Text = "Shadow Highlight:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // shadowHighlightCheckBox
            // 
            this.shadowHighlightCheckBox.AutoSize = true;
            this.shadowHighlightCheckBox.Checked = true;
            this.shadowHighlightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shadowHighlightCheckBox.Location = new System.Drawing.Point(123, 42);
            this.shadowHighlightCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.shadowHighlightCheckBox.Name = "shadowHighlightCheckBox";
            this.shadowHighlightCheckBox.Size = new System.Drawing.Size(18, 17);
            this.shadowHighlightCheckBox.TabIndex = 23;
            this.shadowHighlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Gamma:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gammaCheckBox
            // 
            this.gammaCheckBox.AutoSize = true;
            this.gammaCheckBox.Location = new System.Drawing.Point(123, 82);
            this.gammaCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gammaCheckBox.Name = "gammaCheckBox";
            this.gammaCheckBox.Size = new System.Drawing.Size(18, 17);
            this.gammaCheckBox.TabIndex = 27;
            this.gammaCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Segmentation:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // segmentationCheckBox
            // 
            this.segmentationCheckBox.AutoSize = true;
            this.segmentationCheckBox.Checked = true;
            this.segmentationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.segmentationCheckBox.Location = new System.Drawing.Point(123, 122);
            this.segmentationCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.segmentationCheckBox.Name = "segmentationCheckBox";
            this.segmentationCheckBox.Size = new System.Drawing.Size(18, 17);
            this.segmentationCheckBox.TabIndex = 29;
            this.segmentationCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.smoothingComboBox, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.signedOrientationCheckBox, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.label19, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.binComboBox, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.checkBox2, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(210, 2);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(201, 162);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 34);
            this.label8.TabIndex = 25;
            this.label8.Text = "Gradient Smoothing:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // smoothingComboBox
            // 
            this.smoothingComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smoothingComboBox.Enabled = false;
            this.smoothingComboBox.FormattingEnabled = true;
            this.smoothingComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.smoothingComboBox.Location = new System.Drawing.Point(124, 4);
            this.smoothingComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.smoothingComboBox.Name = "smoothingComboBox";
            this.smoothingComboBox.Size = new System.Drawing.Size(73, 24);
            this.smoothingComboBox.TabIndex = 28;
            this.smoothingComboBox.Text = "0";
            // 
            // signedOrientationCheckBox
            // 
            this.signedOrientationCheckBox.AutoSize = true;
            this.signedOrientationCheckBox.Checked = true;
            this.signedOrientationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.signedOrientationCheckBox.Enabled = false;
            this.signedOrientationCheckBox.Location = new System.Drawing.Point(123, 82);
            this.signedOrientationCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signedOrientationCheckBox.Name = "signedOrientationCheckBox";
            this.signedOrientationCheckBox.Size = new System.Drawing.Size(18, 17);
            this.signedOrientationCheckBox.TabIndex = 34;
            this.signedOrientationCheckBox.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 34);
            this.label19.TabIndex = 39;
            this.label19.Text = "Signed Orientation:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 34);
            this.label14.TabIndex = 36;
            this.label14.Text = "Orientation Resolution:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 34);
            this.label13.TabIndex = 35;
            this.label13.Text = "Spatial Smoothing:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // binComboBox
            // 
            this.binComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binComboBox.FormattingEnabled = true;
            this.binComboBox.Items.AddRange(new object[] {
            "4",
            "9",
            "18",
            "36",
            "72",
            "90",
            "180",
            "360"});
            this.binComboBox.Location = new System.Drawing.Point(124, 124);
            this.binComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.binComboBox.Name = "binComboBox";
            this.binComboBox.Size = new System.Drawing.Size(73, 24);
            this.binComboBox.TabIndex = 37;
            this.binComboBox.Text = "9";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(123, 42);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 38;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 673);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Patch Extraction";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workingPictureBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maskPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patchPictureBox)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox workingPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label fileCountLabel;
        private System.Windows.Forms.Label windowCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalLantanaLabel;
        private System.Windows.Forms.Label totalNonLantanaLabel;
        private System.Windows.Forms.PictureBox maskPictureBox;
        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.PictureBox patchPictureBox;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox patchSizeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox shadowHighlightCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox gammaCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox segmentationCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ComboBox smoothingComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox colourSpaceComboBox;
        private System.Windows.Forms.ComboBox blockSizeComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox overlapComboBox;
        private System.Windows.Forms.ComboBox cellSizeComboBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox binComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox signedOrientationCheckBox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox derivativeMaskComboBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox blockNormalisationCheckBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox rotationInvariantCheckBox;
        private System.Windows.Forms.ComboBox interpolationComboBox;
        private System.Windows.Forms.Label label20;

    }
}

