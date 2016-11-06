using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                List<Object> parameters = new List<object>();
                parameters.Add(textBoxNameLogin); 
                parameters.Add(textBoxPasswordLogin);
                Command comm = new Command(Request.VerifyLogin, parameters);

                bool response = (bool)comm.Execute(AsynchronousClient.client);

                if(true == response)
                {
                    MessageBox.Show("Autentificat!");
                }
                else
                {
                    MessageBox.Show("Neautorizat!!!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
