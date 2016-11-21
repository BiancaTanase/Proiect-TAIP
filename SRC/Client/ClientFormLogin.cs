using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                List<Object> parameters = new List<object>();
                parameters.Add(textBoxNameLogin.Text);
                parameters.Add(textBoxPasswordLogin.Text);
                command.setCommand(Request.VerifyLogin, parameters);

                command.setCommandBytes();

                string response = (string)command.execute(AsynchronousClient.client);

                if ("Success" == response)
                {
                    MessageBox.Show("Autentificat!");
                }
                else
                {
                    MessageBox.Show("Neautorizat!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
