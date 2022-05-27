namespace Book1
{
    partial class FormParent
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
            this.text1 = new System.Windows.Forms.LinkLabel();
            this.p1 = new System.Windows.Forms.Panel();
            this.text3 = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Panel();
            this.p1.SuspendLayout();
            this.SuspendLayout();
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(13, 18);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(67, 15);
            this.text1.TabIndex = 0;
            this.text1.TabStop = true;
            this.text1.Text = "图书管理";
            // 
            // p1
            // 
            this.p1.Controls.Add(this.text3);
            this.p1.Controls.Add(this.text2);
            this.p1.Controls.Add(this.text1);
            this.p1.Location = new System.Drawing.Point(-1, 0);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(801, 62);
            this.p1.TabIndex = 1;
            // 
            // text3
            // 
            this.text3.AutoSize = true;
            this.text3.Location = new System.Drawing.Point(98, 18);
            this.text3.Name = "text3";
            this.text3.Size = new System.Drawing.Size(67, 15);
            this.text3.TabIndex = 2;
            this.text3.Text = "添加图书";
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Location = new System.Drawing.Point(77, 18);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(15, 15);
            this.text2.TabIndex = 1;
            this.text2.Text = "|";
            // 
            // p2
            // 
            this.p2.Location = new System.Drawing.Point(-1, 61);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(801, 390);
            this.p2.TabIndex = 2;
            // 
            // FormParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Name = "FormParent";
            this.Text = "FormParent";
            this.p1.ResumeLayout(false);
            this.p1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel text1;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Label text3;
        private System.Windows.Forms.Label text2;
        private System.Windows.Forms.Panel p2;
    }
}