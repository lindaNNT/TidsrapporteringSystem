namespace TestAvWCFApp
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.rt1 = new System.Windows.Forms.RichTextBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.mc1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(48, 39);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(131, 20);
            this.tb1.TabIndex = 0;
            this.tb1.Text = "linda";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(45, 72);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(23, 13);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "lbl1";
            this.lbl1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(45, 102);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(23, 13);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "lbl2";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(389, 37);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 3;
            this.btn1.Text = "testa";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(45, 129);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(23, 13);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "lbl3";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(45, 154);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(23, 13);
            this.lbl4.TabIndex = 5;
            this.lbl4.Text = "lbl4";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(45, 176);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(23, 13);
            this.lbl5.TabIndex = 6;
            this.lbl5.Text = "lbl5";
            // 
            // rt1
            // 
            this.rt1.Location = new System.Drawing.Point(194, 72);
            this.rt1.Name = "rt1";
            this.rt1.Size = new System.Drawing.Size(420, 175);
            this.rt1.TabIndex = 7;
            this.rt1.Text = "";
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(45, 202);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(23, 13);
            this.lbl6.TabIndex = 8;
            this.lbl6.Text = "lbl6";
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(194, 40);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(131, 20);
            this.tb2.TabIndex = 9;
            this.tb2.Text = "201212";
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(48, 234);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(23, 13);
            this.lbl7.TabIndex = 10;
            this.lbl7.Text = "lbl7";
            // 
            // mc1
            // 
            this.mc1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.mc1.Location = new System.Drawing.Point(194, 259);
            this.mc1.MaxSelectionCount = 31;
            this.mc1.Name = "mc1";
            this.mc1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 515);
            this.Controls.Add(this.mc1);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.rt1);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.tb1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.RichTextBox rt1;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.MonthCalendar mc1;
    }
}

