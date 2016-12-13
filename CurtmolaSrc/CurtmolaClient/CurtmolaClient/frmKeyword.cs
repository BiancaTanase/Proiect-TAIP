using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtmolaClient
{
    public partial class frmKeyword : Form
    {
        public string Keyword
        {
            get;
            set;
        }

        public bool IsValid
        {
            get;
            set;
        }
        public frmKeyword()
        {
            InitializeComponent();
            this.Keyword = string.Empty;
            this.IsValid = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (false == string.IsNullOrEmpty(this.keywordTxtBox.Text))
            {
                this.Keyword = this.keywordTxtBox.Text.Trim();
                if (false == Program.client.keywords.Contains(this.Keyword))
                {
                    this.IsValid = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This keyword has already been chosen.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a keyword.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
