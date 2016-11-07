namespace CurtmolaClient
{
    partial class frmRetrieve
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
            this.grdDownloadKeys = new System.Windows.Forms.DataGridView();
            this.lblRetrieveKeywords = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.Keyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDownloadKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDownloadKeys
            // 
            this.grdDownloadKeys.AllowUserToAddRows = false;
            this.grdDownloadKeys.AllowUserToDeleteRows = false;
            this.grdDownloadKeys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdDownloadKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDownloadKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Keyword});
            this.grdDownloadKeys.Location = new System.Drawing.Point(12, 33);
            this.grdDownloadKeys.Name = "grdDownloadKeys";
            this.grdDownloadKeys.RowHeadersVisible = false;
            this.grdDownloadKeys.Size = new System.Drawing.Size(271, 268);
            this.grdDownloadKeys.TabIndex = 0;
            // 
            // lblRetrieveKeywords
            // 
            this.lblRetrieveKeywords.AutoSize = true;
            this.lblRetrieveKeywords.Location = new System.Drawing.Point(13, 13);
            this.lblRetrieveKeywords.Name = "lblRetrieveKeywords";
            this.lblRetrieveKeywords.Size = new System.Drawing.Size(53, 13);
            this.lblRetrieveKeywords.TabIndex = 1;
            this.lblRetrieveKeywords.Text = "Keywords";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(310, 130);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(150, 68);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // Keyword
            // 
            this.Keyword.HeaderText = "Keyword";
            this.Keyword.Name = "Keyword";
            // 
            // frmRetrieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 334);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblRetrieveKeywords);
            this.Controls.Add(this.grdDownloadKeys);
            this.Name = "frmRetrieve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRetrieve";
            ((System.ComponentModel.ISupportInitialize)(this.grdDownloadKeys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDownloadKeys;
        private System.Windows.Forms.Label lblRetrieveKeywords;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keyword;
    }
}