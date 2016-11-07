using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CFile objFile = new CFile();

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

        private void btEncrypt_Click(object sender, EventArgs e)
        {
            CEncryption objEncrypt = new CEncryption();
            rtCipherText.Text = (CEncryption.AES_Encrypt(rtPlaintext.Text, Encoding.UTF8.GetBytes(teKey.Text)));
        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            CEncryption objDecrypt = new CEncryption();
            rtCipherText.Text = (CEncryption.AES_Decrypt(rtPlaintext.Text, Encoding.UTF8.GetBytes(teKey.Text)));
        }

        private void btPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TXT|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tePath.Text = ofd.FileName;
                objFile.setFile(ofd.FileName);
            }
        }

        private void preview_Click(object sender, EventArgs e)
        {
            textPreview.Text = objFile.retFileText();
        }

        private void btEncryptText_Click(object sender, EventArgs e)
        {
            CEncryption objEncrypt = new CEncryption();
            textPreview.Text = (CEncryption.AES_Encrypt(objFile.retFileText(), Encoding.UTF8.GetBytes(tePassword.Text)));
            objFile.updateFileText(textPreview.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CEncryption objDecrypt = new CEncryption();
            textPreview.Text = (CEncryption.AES_Decrypt(objFile.retFileText(), Encoding.UTF8.GetBytes(tePassword.Text)));
            objFile.updateFileText(textPreview.Text);
        }

        private void btSaveText_Click(object sender, EventArgs e)
        {
            objFile.writeFile();
        }

 

        private void DragAndDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void DragAndDrop_DragDrop_1(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (files.Length == 1 && files[0].Contains(".txt"))
            {
                tePath.Text = files[0];
                objFile.setFile(tePath.Text);
                Array.Clear(files, 0, files.Length);
            }
            else
                Array.Clear(files, 0, files.Length);
        }
    }
}
