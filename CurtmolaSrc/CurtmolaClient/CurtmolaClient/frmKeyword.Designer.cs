namespace CurtmolaClient
{
    partial class frmKeyword
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.keywordTxtBox = new System.Windows.Forms.TextBox();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(154, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 41);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add keyword";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // keywordTxtBox
            // 
            this.keywordTxtBox.Location = new System.Drawing.Point(133, 43);
            this.keywordTxtBox.Name = "keywordTxtBox";
            this.keywordTxtBox.Size = new System.Drawing.Size(228, 20);
            this.keywordTxtBox.TabIndex = 1;
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Location = new System.Drawing.Point(69, 46);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(51, 13);
            this.lblKeyword.TabIndex = 2;
            this.lblKeyword.Text = "Keyword:";
            // 
            // frmKeyword
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 169);
            this.Controls.Add(this.lblKeyword);
            this.Controls.Add(this.keywordTxtBox);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmKeyword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmKeyword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox keywordTxtBox;
        private System.Windows.Forms.Label lblKeyword;
    }
}