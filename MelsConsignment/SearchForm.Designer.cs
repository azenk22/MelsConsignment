namespace MelsConsignment
{
    partial class SearchForm
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
            this.SearchBTN = new System.Windows.Forms.Button();
            this.LastNameTB = new System.Windows.Forms.TextBox();
            this.LastNameLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchBTN
            // 
            this.SearchBTN.Location = new System.Drawing.Point(72, 125);
            this.SearchBTN.Name = "SearchBTN";
            this.SearchBTN.Size = new System.Drawing.Size(75, 23);
            this.SearchBTN.TabIndex = 0;
            this.SearchBTN.Text = "Search";
            this.SearchBTN.UseVisualStyleBackColor = true;
            this.SearchBTN.Click += new System.EventHandler(this.SearchBTN_Click);
            // 
            // LastNameTB
            // 
            this.LastNameTB.Location = new System.Drawing.Point(47, 45);
            this.LastNameTB.Name = "LastNameTB";
            this.LastNameTB.Size = new System.Drawing.Size(100, 20);
            this.LastNameTB.TabIndex = 1;
            // 
            // LastNameLBL
            // 
            this.LastNameLBL.AutoSize = true;
            this.LastNameLBL.Location = new System.Drawing.Point(395, 54);
            this.LastNameLBL.Name = "LastNameLBL";
            this.LastNameLBL.Size = new System.Drawing.Size(35, 13);
            this.LastNameLBL.TabIndex = 2;
            this.LastNameLBL.Text = "label1";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LastNameLBL);
            this.Controls.Add(this.LastNameTB);
            this.Controls.Add(this.SearchBTN);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchBTN;
        private System.Windows.Forms.TextBox LastNameTB;
        private System.Windows.Forms.Label LastNameLBL;
    }
}