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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdate update = new frmUpdate();
            this.Hide();
            update.ShowDialog();
            this.Show();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            frmRetrieve retrieve = new frmRetrieve();
            this.Hide();
            retrieve.ShowDialog();
            this.Show();
        }
    }
}
