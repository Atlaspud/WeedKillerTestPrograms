namespace IMUTest
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.serialTextOutput = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.getValues = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.errorText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.serialTextOutput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.errorText, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 262);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.startButton);
            this.flowLayoutPanel1.Controls.Add(this.getValues);
            this.flowLayoutPanel1.Controls.Add(this.stop);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 199);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(278, 33);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // serialTextOutput
            // 
            this.serialTextOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serialTextOutput.Location = new System.Drawing.Point(3, 3);
            this.serialTextOutput.Multiline = true;
            this.serialTextOutput.Name = "serialTextOutput";
            this.serialTextOutput.Size = new System.Drawing.Size(278, 190);
            this.serialTextOutput.TabIndex = 1;
            this.serialTextOutput.TextChanged += new System.EventHandler(this.serialTextOutput_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(3, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(86, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // getValues
            // 
            this.getValues.Location = new System.Drawing.Point(95, 3);
            this.getValues.Name = "getValues";
            this.getValues.Size = new System.Drawing.Size(86, 23);
            this.getValues.TabIndex = 1;
            this.getValues.Text = "Get Values";
            this.getValues.UseVisualStyleBackColor = true;
            this.getValues.Click += new System.EventHandler(this.getValues_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(187, 3);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(86, 23);
            this.stop.TabIndex = 2;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // errorText
            // 
            this.errorText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorText.Location = new System.Drawing.Point(3, 238);
            this.errorText.Multiline = true;
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(278, 21);
            this.errorText.TabIndex = 2;
            this.errorText.TextChanged += new System.EventHandler(this.errorText_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button getValues;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox serialTextOutput;
        private System.Windows.Forms.TextBox errorText;
    }
}

