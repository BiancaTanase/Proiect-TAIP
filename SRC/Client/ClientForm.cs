using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity;

namespace Client
{
    public partial class ClientForm : Form
    {
        IUnityContainer container = new UnityContainer();
        public static ICommand command;

        public ClientForm()
        {
            InitializeComponent();
            container = Microsoft.Practices.Unity.Configuration.UnityContainerExtensions.LoadConfiguration(container);
            command = Microsoft.Practices.Unity.UnityContainerExtensions.Resolve<ICommand>(container);
        }

        CFile objFile = CFile.GetInstance;


        private void btEncrypt_Click(object sender, EventArgs e)
        {
            PrincipalProcedure objEncrypt = new PrincipalProcedure();
            rtCipherText.Text = (objEncrypt.AES_Encrypt(rtPlaintext.Text, Encoding.UTF8.GetBytes(teKey.Text)));
        }

        private void btDecrypt_Click(object sender, EventArgs e)
        {
            PrincipalProcedure objEncrypt = new PrincipalProcedure();
            rtCipherText.Text = (objEncrypt.AES_Decrypt(rtPlaintext.Text, Encoding.UTF8.GetBytes(teKey.Text)));
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
            PrincipalProcedure objEncrypt = new PrincipalProcedure();
            textPreview.Text = (objEncrypt.AES_Encrypt(objFile.retFileText(), Encoding.UTF8.GetBytes(tePassword.Text)));
            objFile.updateFileText(textPreview.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrincipalProcedure objEncrypt = new PrincipalProcedure();
            textPreview.Text = (objEncrypt.AES_Decrypt(objFile.retFileText(), Encoding.UTF8.GetBytes(tePassword.Text)));
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
