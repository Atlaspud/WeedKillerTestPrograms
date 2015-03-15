namespace TextureClassificationTestProgram
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.picboxOriginal = new System.Windows.Forms.PictureBox();
            this.picboxOutputImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.thresholdTestBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.hSBHueH = new System.Windows.Forms.HScrollBar();
            this.hSBSatH = new System.Windows.Forms.HScrollBar();
            this.hSBValH = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrThreshold = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.hSBHueL = new System.Windows.Forms.HScrollBar();
            this.hSBSatL = new System.Windows.Forms.HScrollBar();
            this.hSBValL = new System.Windows.Forms.HScrollBar();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.hSBMorph = new System.Windows.Forms.HScrollBar();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOutputImage)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 561);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lantana Identifier";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.65217F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.34783F));
            this.tableLayoutPanel1.Controls.Add(this.txtLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.picboxOriginal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picboxOutputImage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(573, 542);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 274);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(255, 265);
            this.txtLog.TabIndex = 1;
            // 
            // picboxOriginal
            // 
            this.picboxOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picboxOriginal.Location = new System.Drawing.Point(264, 3);
            this.picboxOriginal.Name = "picboxOriginal";
            this.picboxOriginal.Size = new System.Drawing.Size(306, 265);
            this.picboxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxOriginal.TabIndex = 2;
            this.picboxOriginal.TabStop = false;
            // 
            // picboxOutputImage
            // 
            this.picboxOutputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picboxOutputImage.Location = new System.Drawing.Point(264, 274);
            this.picboxOutputImage.Name = "picboxOutputImage";
            this.picboxOutputImage.Size = new System.Drawing.Size(306, 265);
            this.picboxOutputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxOutputImage.TabIndex = 3;
            this.picboxOutputImage.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(255, 265);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnIdentify, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBrowse, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.thresholdTestBtn, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(249, 126);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnIdentify
            // 
            this.btnIdentify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIdentify.Enabled = false;
            this.btnIdentify.Location = new System.Drawing.Point(3, 3);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(118, 57);
            this.btnIdentify.TabIndex = 0;
            this.btnIdentify.Text = "Identify Target";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.Location = new System.Drawing.Point(127, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(119, 57);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // thresholdTestBtn
            // 
            this.thresholdTestBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thresholdTestBtn.Enabled = false;
            this.thresholdTestBtn.Location = new System.Drawing.Point(3, 66);
            this.thresholdTestBtn.Name = "thresholdTestBtn";
            this.thresholdTestBtn.Size = new System.Drawing.Size(118, 57);
            this.thresholdTestBtn.TabIndex = 2;
            this.thresholdTestBtn.Text = "Threshold";
            this.thresholdTestBtn.UseVisualStyleBackColor = true;
            this.thresholdTestBtn.Click += new System.EventHandler(this.thresholdTestBtn_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.51406F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.48595F));
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.hSBHueH, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.hSBValH, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.hSBSatH, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.hSBHueL, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.hSBSatL, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.hSBValL, 1, 5);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 135);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(249, 127);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // hSBHueH
            // 
            this.hSBHueH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hSBHueH.Location = new System.Drawing.Point(71, 2);
            this.hSBHueH.Maximum = 255;
            this.hSBHueH.Name = "hSBHueH";
            this.hSBHueH.Size = new System.Drawing.Size(178, 17);
            this.hSBHueH.TabIndex = 0;
            this.hSBHueH.Value = 89;
            // 
            // hSBSatH
            // 
            this.hSBSatH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hSBSatH.Location = new System.Drawing.Point(71, 46);
            this.hSBSatH.Maximum = 255;
            this.hSBSatH.Name = "hSBSatH";
            this.hSBSatH.Size = new System.Drawing.Size(178, 17);
            this.hSBSatH.TabIndex = 1;
            this.hSBSatH.Value = 246;
            // 
            // hSBValH
            // 
            this.hSBValH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hSBValH.Location = new System.Drawing.Point(71, 87);
            this.hSBValH.Maximum = 255;
            this.hSBValH.Name = "hSBValH";
            this.hSBValH.Size = new System.Drawing.Size(178, 17);
            this.hSBValH.TabIndex = 2;
            this.hSBValH.Value = 246;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hue  H";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sat H";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Val H";
            // 
            // tmrThreshold
            // 
            this.tmrThreshold.Interval = 10;
            this.tmrThreshold.Tick += new System.EventHandler(this.tmrThreshold_Tick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hue  L";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sat L";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Val L";
            // 
            // hSBHueL
            // 
            this.hSBHueL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hSBHueL.Location = new System.Drawing.Point(71, 24);
            this.hSBHueL.Maximum = 255;
            this.hSBHueL.Name = "hSBHueL";
            this.hSBHueL.Size = new System.Drawing.Size(178, 17);
            this.hSBHueL.TabIndex = 9;
            this.hSBHueL.Value = 35;
            // 
            // hSBSatL
            // 
            this.hSBSatL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hSBSatL.Location = new System.Drawing.Point(71, 67);
            this.hSBSatL.Maximum = 255;
            this.hSBSatL.Name = "hSBSatL";
            this.hSBSatL.Size = new System.Drawing.Size(178, 17);
            this.hSBSatL.TabIndex = 10;
            this.hSBSatL.Value = 87;
            // 
            // hSBValL
            // 
            this.hSBValL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hSBValL.Location = new System.Drawing.Point(71, 108);
            this.hSBValL.Maximum = 255;
            this.hSBValL.Name = "hSBValL";
            this.hSBValL.Size = new System.Drawing.Size(178, 17);
            this.hSBValL.TabIndex = 11;
            this.hSBValL.Value = 95;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.hSBMorph, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(127, 66);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.84211F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.15789F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(119, 57);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Morpholical Size";
            // 
            // hSBMorph
            // 
            this.hSBMorph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hSBMorph.Location = new System.Drawing.Point(0, 21);
            this.hSBMorph.Minimum = 5;
            this.hSBMorph.Name = "hSBMorph";
            this.hSBMorph.Size = new System.Drawing.Size(119, 36);
            this.hSBMorph.TabIndex = 1;
            this.hSBMorph.Value = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 561);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Lantana Identification Test Program";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOutputImage)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.PictureBox picboxOriginal;
        private System.Windows.Forms.PictureBox picboxOutputImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button thresholdTestBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.HScrollBar hSBHueH;
        private System.Windows.Forms.HScrollBar hSBSatH;
        private System.Windows.Forms.HScrollBar hSBValH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmrThreshold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.HScrollBar hSBHueL;
        private System.Windows.Forms.HScrollBar hSBSatL;
        private System.Windows.Forms.HScrollBar hSBValL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.HScrollBar hSBMorph;
    }
}

