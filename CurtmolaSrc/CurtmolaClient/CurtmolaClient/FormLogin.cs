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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            Program.client = new Client();

            if (null == Program.client.socket)
            {
                Program.client.socket = Program.client.CreateEndPoint();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != Program.client.socket)
                {
                    Program.client.DeserializeStructures();

                    Program.client.name = textBoxNameLogin.Text;
                    Program.client.password = textBoxPasswordLogin.Text;

                    if (true == Program.client.Login())
                    {
                        frmMain update = new frmMain();
                        this.Hide();
                        update.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect account/password!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Refresh!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("An error to login!");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != Program.client.socket)
                {
                    Program.client.DeserializeStructures();

                    Program.client.name = textBoxNameLogin.Text;
                    Program.client.password = textBoxPasswordLogin.Text;

                    Program.client.Register();
                }
                else
                {
                    MessageBox.Show("Please Refresh!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("An error to register!");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //if (null == Program.client.socket)
            {
                Program.client.socket = Program.client.CreateEndPoint();
            }
        }
    }
}
