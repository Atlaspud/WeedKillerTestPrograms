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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.picboxOriginal = new System.Windows.Forms.PictureBox();
            this.picboxOutputImage = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOutputImage)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.picboxOriginal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picboxOutputImage, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(573, 542);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnIdentify, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBrowse, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.34653F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(242, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnIdentify
            // 
            this.btnIdentify.Enabled = false;
            this.btnIdentify.Location = new System.Drawing.Point(3, 3);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(115, 23);
            this.btnIdentify.TabIndex = 0;
            this.btnIdentify.Text = "Identify Target";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(124, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(115, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
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
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxOutputImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.PictureBox picboxOriginal;
        private System.Windows.Forms.PictureBox picboxOutputImage;
    }
}

