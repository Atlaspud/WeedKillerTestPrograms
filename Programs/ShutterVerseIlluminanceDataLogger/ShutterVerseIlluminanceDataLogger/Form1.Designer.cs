namespace ShutterVerseIlluminanceDataLogger
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cameraViewPicBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.addSun = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.addCloudShadeBtn = new System.Windows.Forms.Button();
            this.addOtherShade = new System.Windows.Forms.Button();
            this.autoCaptureBtn = new System.Windows.Forms.Button();
            this.logTxtBox = new System.Windows.Forms.TextBox();
            this.autoCaptureTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraViewPicBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ShutterVerseIlluminance";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.75936F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.24064F));
            this.tableLayoutPanel1.Controls.Add(this.cameraViewPicBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(989, 518);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cameraViewPicBox
            // 
            this.cameraViewPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraViewPicBox.Location = new System.Drawing.Point(346, 3);
            this.cameraViewPicBox.Name = "cameraViewPicBox";
            this.cameraViewPicBox.Size = new System.Drawing.Size(640, 512);
            this.cameraViewPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraViewPicBox.TabIndex = 0;
            this.cameraViewPicBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.logTxtBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(337, 512);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.addSun, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.browseBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.addCloudShadeBtn, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.addOtherShade, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.autoCaptureBtn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(331, 250);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // addSun
            // 
            this.addSun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addSun.Enabled = false;
            this.addSun.Location = new System.Drawing.Point(3, 167);
            this.addSun.Name = "addSun";
            this.addSun.Size = new System.Drawing.Size(159, 35);
            this.addSun.TabIndex = 1;
            this.addSun.Text = "Add Sunny Data";
            this.addSun.UseVisualStyleBackColor = true;
            // 
            // browseBtn
            // 
            this.browseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseBtn.Location = new System.Drawing.Point(3, 3);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(159, 35);
            this.browseBtn.TabIndex = 3;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // addCloudShadeBtn
            // 
            this.addCloudShadeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addCloudShadeBtn.Enabled = false;
            this.addCloudShadeBtn.Location = new System.Drawing.Point(3, 126);
            this.addCloudShadeBtn.Name = "addCloudShadeBtn";
            this.addCloudShadeBtn.Size = new System.Drawing.Size(159, 35);
            this.addCloudShadeBtn.TabIndex = 0;
            this.addCloudShadeBtn.Text = "Add Cloud Data";
            this.addCloudShadeBtn.UseVisualStyleBackColor = true;
            this.addCloudShadeBtn.Click += new System.EventHandler(this.addCloudShadeBtn_Click);
            // 
            // addOtherShade
            // 
            this.addOtherShade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addOtherShade.Enabled = false;
            this.addOtherShade.Location = new System.Drawing.Point(3, 208);
            this.addOtherShade.Name = "addOtherShade";
            this.addOtherShade.Size = new System.Drawing.Size(159, 39);
            this.addOtherShade.TabIndex = 2;
            this.addOtherShade.Text = "Add Indoor Data";
            this.addOtherShade.UseVisualStyleBackColor = true;
            // 
            // autoCaptureBtn
            // 
            this.autoCaptureBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoCaptureBtn.Enabled = false;
            this.autoCaptureBtn.Location = new System.Drawing.Point(168, 3);
            this.autoCaptureBtn.Name = "autoCaptureBtn";
            this.autoCaptureBtn.Size = new System.Drawing.Size(160, 35);
            this.autoCaptureBtn.TabIndex = 4;
            this.autoCaptureBtn.Text = "Auto Capture Start";
            this.autoCaptureBtn.UseVisualStyleBackColor = true;
            this.autoCaptureBtn.Click += new System.EventHandler(this.autoCaptureBtn_Click);
            // 
            // logTxtBox
            // 
            this.logTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTxtBox.Location = new System.Drawing.Point(3, 259);
            this.logTxtBox.Multiline = true;
            this.logTxtBox.Name = "logTxtBox";
            this.logTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTxtBox.Size = new System.Drawing.Size(331, 250);
            this.logTxtBox.TabIndex = 1;
            // 
            // autoCaptureTimer
            // 
            this.autoCaptureTimer.Interval = 143;
            this.autoCaptureTimer.Tick += new System.EventHandler(this.autoCaptureTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 537);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cameraViewPicBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox cameraViewPicBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button addCloudShadeBtn;
        private System.Windows.Forms.Button addSun;
        private System.Windows.Forms.Button addOtherShade;
        private System.Windows.Forms.TextBox logTxtBox;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button autoCaptureBtn;
        private System.Windows.Forms.Timer autoCaptureTimer;
    }
}

