namespace AutomaticExposureExperiment
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.outsideDarkButton = new System.Windows.Forms.Button();
            this.outsideLightButton = new System.Windows.Forms.Button();
            this.insideLightButton = new System.Windows.Forms.Button();
            this.insideDarkButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 562);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(249, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(732, 556);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 556);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.outsideDarkButton, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.outsideLightButton, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.insideLightButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.insideDarkButton, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(234, 272);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // outsideDarkButton
            // 
            this.outsideDarkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outsideDarkButton.Location = new System.Drawing.Point(3, 207);
            this.outsideDarkButton.Name = "outsideDarkButton";
            this.outsideDarkButton.Size = new System.Drawing.Size(228, 62);
            this.outsideDarkButton.TabIndex = 3;
            this.outsideDarkButton.Text = "Outside Dark";
            this.outsideDarkButton.UseVisualStyleBackColor = true;
            this.outsideDarkButton.Click += new System.EventHandler(this.experimentButton_Click);
            // 
            // outsideLightButton
            // 
            this.outsideLightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outsideLightButton.Location = new System.Drawing.Point(3, 139);
            this.outsideLightButton.Name = "outsideLightButton";
            this.outsideLightButton.Size = new System.Drawing.Size(228, 62);
            this.outsideLightButton.TabIndex = 2;
            this.outsideLightButton.Text = "Outside Light";
            this.outsideLightButton.UseVisualStyleBackColor = true;
            this.outsideLightButton.Click += new System.EventHandler(this.experimentButton_Click);
            // 
            // insideLightButton
            // 
            this.insideLightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insideLightButton.Location = new System.Drawing.Point(3, 3);
            this.insideLightButton.Name = "insideLightButton";
            this.insideLightButton.Size = new System.Drawing.Size(228, 62);
            this.insideLightButton.TabIndex = 0;
            this.insideLightButton.Text = "Inside Light";
            this.insideLightButton.UseVisualStyleBackColor = true;
            this.insideLightButton.Click += new System.EventHandler(this.experimentButton_Click);
            // 
            // insideDarkButton
            // 
            this.insideDarkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insideDarkButton.Location = new System.Drawing.Point(3, 71);
            this.insideDarkButton.Name = "insideDarkButton";
            this.insideDarkButton.Size = new System.Drawing.Size(228, 62);
            this.insideDarkButton.TabIndex = 1;
            this.insideDarkButton.Text = "Inside Dark";
            this.insideDarkButton.UseVisualStyleBackColor = true;
            this.insideDarkButton.Click += new System.EventHandler(this.experimentButton_Click);
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(3, 281);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(234, 272);
            this.textBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Automatic Exposure Experiment";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button insideLightButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button outsideLightButton;
        private System.Windows.Forms.Button insideDarkButton;
        private System.Windows.Forms.Button outsideDarkButton;
    }
}

