namespace TestAvWCFApp
{
    partial class Form2
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
            this.lKundNr = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lOrder = new System.Windows.Forms.ListBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lKundNr
            // 
            this.lKundNr.FormattingEnabled = true;
            this.lKundNr.Location = new System.Drawing.Point(16, 36);
            this.lKundNr.Name = "lKundNr";
            this.lKundNr.Size = new System.Drawing.Size(197, 225);
            this.lKundNr.TabIndex = 0;
            this.lKundNr.SelectedValueChanged += new System.EventHandler(this.lKundNr_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "KundNr";
            // 
            // lOrder
            // 
            this.lOrder.FormattingEnabled = true;
            this.lOrder.Location = new System.Drawing.Point(219, 36);
            this.lOrder.Name = "lOrder";
            this.lOrder.Size = new System.Drawing.Size(484, 225);
            this.lOrder.TabIndex = 2;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(219, 17);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(33, 13);
            this.lblOrder.TabIndex = 3;
            this.lblOrder.Text = "Order";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(138, 267);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 4;
            this.btn1.Text = "Get Cust";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(18, 267);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(23, 13);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "lbl1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 457);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.lOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lKundNr);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lKundNr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Label lbl1;
    }
}