namespace Client
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelHome = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPasswordLogin = new System.Windows.Forms.TextBox();
            this.textBoxNameLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxPasswordRegister = new System.Windows.Forms.TextBox();
            this.textBoxNameRegister = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btDecrypt = new System.Windows.Forms.Button();
            this.rtCipherText = new System.Windows.Forms.RichTextBox();
            this.rtPlaintext = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.teKey = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btEncrypt = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonAddData = new System.Windows.Forms.Button();
            this.textBoxDataToAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btSaveText = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tePassword = new System.Windows.Forms.TextBox();
            this.btEncryptText = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.Button();
            this.textPreview = new System.Windows.Forms.RichTextBox();
            this.btPath = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tePath = new System.Windows.Forms.TextBox();
            this.DragAndDrop = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 331);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelHome);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelHome
            // 
            this.labelHome.Location = new System.Drawing.Point(32, 72);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(556, 110);
            this.labelHome.TabIndex = 0;
            this.labelHome.Text = resources.GetString("labelHome.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonLogin);
            this.tabPage2.Controls.Add(this.textBoxPasswordLogin);
            this.tabPage2.Controls.Add(this.textBoxNameLogin);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(615, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Login";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(179, 137);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPasswordLogin
            // 
            this.textBoxPasswordLogin.Location = new System.Drawing.Point(155, 93);
            this.textBoxPasswordLogin.Name = "textBoxPasswordLogin";
            this.textBoxPasswordLogin.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordLogin.TabIndex = 3;
            // 
            // textBoxNameLogin
            // 
            this.textBoxNameLogin.Location = new System.Drawing.Point(155, 62);
            this.textBoxNameLogin.Name = "textBoxNameLogin";
            this.textBoxNameLogin.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameLogin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User name";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonRegister);
            this.tabPage3.Controls.Add(this.textBoxPasswordRegister);
            this.tabPage3.Controls.Add(this.textBoxNameRegister);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(615, 305);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Register";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(148, 136);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(75, 23);
            this.buttonRegister.TabIndex = 9;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            // 
            // textBoxPasswordRegister
            // 
            this.textBoxPasswordRegister.Location = new System.Drawing.Point(124, 92);
            this.textBoxPasswordRegister.Name = "textBoxPasswordRegister";
            this.textBoxPasswordRegister.Size = new System.Drawing.Size(100, 20);
            this.textBoxPasswordRegister.TabIndex = 8;
            // 
            // textBoxNameRegister
            // 
            this.textBoxNameRegister.Location = new System.Drawing.Point(124, 61);
            this.textBoxNameRegister.Name = "textBoxNameRegister";
            this.textBoxNameRegister.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameRegister.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "User name";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btDecrypt);
            this.tabPage4.Controls.Add(this.rtCipherText);
            this.tabPage4.Controls.Add(this.rtPlaintext);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.teKey);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.btEncrypt);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.buttonAddData);
            this.tabPage4.Controls.Add(this.textBoxDataToAdd);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(615, 305);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "AddData";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btDecrypt
            // 
            this.btDecrypt.Location = new System.Drawing.Point(286, 201);
            this.btDecrypt.Name = "btDecrypt";
            this.btDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btDecrypt.TabIndex = 27;
            this.btDecrypt.Text = "Decrypt";
            this.btDecrypt.UseVisualStyleBackColor = true;
            this.btDecrypt.Click += new System.EventHandler(this.btDecrypt_Click);
            // 
            // rtCipherText
            // 
            this.rtCipherText.Location = new System.Drawing.Point(103, 229);
            this.rtCipherText.Name = "rtCipherText";
            this.rtCipherText.Size = new System.Drawing.Size(379, 64);
            this.rtCipherText.TabIndex = 26;
            this.rtCipherText.Text = "";
            // 
            // rtPlaintext
            // 
            this.rtPlaintext.Location = new System.Drawing.Point(103, 106);
            this.rtPlaintext.Name = "rtPlaintext";
            this.rtPlaintext.Size = new System.Drawing.Size(379, 40);
            this.rtPlaintext.TabIndex = 25;
            this.rtPlaintext.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Password";
            // 
            // teKey
            // 
            this.teKey.Location = new System.Drawing.Point(103, 168);
            this.teKey.Name = "teKey";
            this.teKey.Size = new System.Drawing.Size(379, 20);
            this.teKey.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "CipherText";
            // 
            // btEncrypt
            // 
            this.btEncrypt.Location = new System.Drawing.Point(205, 201);
            this.btEncrypt.Name = "btEncrypt";
            this.btEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btEncrypt.TabIndex = 21;
            this.btEncrypt.Text = "Encrypt";
            this.btEncrypt.UseVisualStyleBackColor = true;
            this.btEncrypt.Click += new System.EventHandler(this.btEncrypt_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Plaintext";
            // 
            // buttonAddData
            // 
            this.buttonAddData.Location = new System.Drawing.Point(241, 62);
            this.buttonAddData.Name = "buttonAddData";
            this.buttonAddData.Size = new System.Drawing.Size(75, 23);
            this.buttonAddData.TabIndex = 12;
            this.buttonAddData.Text = "Add";
            this.buttonAddData.UseVisualStyleBackColor = true;
            // 
            // textBoxDataToAdd
            // 
            this.textBoxDataToAdd.Location = new System.Drawing.Point(103, 31);
            this.textBoxDataToAdd.Multiline = true;
            this.textBoxDataToAdd.Name = "textBoxDataToAdd";
            this.textBoxDataToAdd.Size = new System.Drawing.Size(455, 25);
            this.textBoxDataToAdd.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.textBox2);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.textBoxQuery);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(615, 305);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "QueryData";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Results";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(105, 97);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(455, 93);
            this.textBox2.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(105, 25);
            this.textBoxQuery.Multiline = true;
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(455, 37);
            this.textBoxQuery.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Query";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.DragAndDrop);
            this.tabPage6.Controls.Add(this.btSaveText);
            this.tabPage6.Controls.Add(this.button2);
            this.tabPage6.Controls.Add(this.label11);
            this.tabPage6.Controls.Add(this.tePassword);
            this.tabPage6.Controls.Add(this.btEncryptText);
            this.tabPage6.Controls.Add(this.preview);
            this.tabPage6.Controls.Add(this.textPreview);
            this.tabPage6.Controls.Add(this.btPath);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.tePath);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(615, 305);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "EncryptFile";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btSaveText
            // 
            this.btSaveText.Location = new System.Drawing.Point(521, 262);
            this.btSaveText.Name = "btSaveText";
            this.btSaveText.Size = new System.Drawing.Size(75, 23);
            this.btSaveText.TabIndex = 21;
            this.btSaveText.Text = "Save Text";
            this.btSaveText.UseVisualStyleBackColor = true;
            this.btSaveText.Click += new System.EventHandler(this.btSaveText_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Decrypt Text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(294, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Password";
            // 
            // tePassword
            // 
            this.tePassword.Location = new System.Drawing.Point(353, 220);
            this.tePassword.Name = "tePassword";
            this.tePassword.Size = new System.Drawing.Size(243, 20);
            this.tePassword.TabIndex = 18;
            // 
            // btEncryptText
            // 
            this.btEncryptText.Location = new System.Drawing.Point(342, 262);
            this.btEncryptText.Name = "btEncryptText";
            this.btEncryptText.Size = new System.Drawing.Size(83, 23);
            this.btEncryptText.TabIndex = 17;
            this.btEncryptText.Text = "Encrypt Text";
            this.btEncryptText.UseVisualStyleBackColor = true;
            this.btEncryptText.Click += new System.EventHandler(this.btEncryptText_Click);
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(126, 262);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(102, 23);
            this.preview.TabIndex = 16;
            this.preview.Text = "Text Preview";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // textPreview
            // 
            this.textPreview.Location = new System.Drawing.Point(294, 20);
            this.textPreview.Name = "textPreview";
            this.textPreview.Size = new System.Drawing.Size(302, 179);
            this.textPreview.TabIndex = 15;
            this.textPreview.Text = "";
            // 
            // btPath
            // 
            this.btPath.Location = new System.Drawing.Point(22, 262);
            this.btPath.Name = "btPath";
            this.btPath.Size = new System.Drawing.Size(97, 23);
            this.btPath.TabIndex = 14;
            this.btPath.Text = "Choose Path";
            this.btPath.UseVisualStyleBackColor = true;
            this.btPath.Click += new System.EventHandler(this.btPath_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Path";
            // 
            // tePath
            // 
            this.tePath.Enabled = false;
            this.tePath.Location = new System.Drawing.Point(54, 221);
            this.tePath.Name = "tePath";
            this.tePath.Size = new System.Drawing.Size(205, 20);
            this.tePath.TabIndex = 12;
            // 
            // DragAndDrop
            // 
            this.DragAndDrop.AllowDrop = true;
            this.DragAndDrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DragAndDrop.Location = new System.Drawing.Point(31, 20);
            this.DragAndDrop.Name = "DragAndDrop";
            this.DragAndDrop.Size = new System.Drawing.Size(237, 179);
            this.DragAndDrop.TabIndex = 22;
            this.DragAndDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragAndDrop_DragDrop_1);
            this.DragAndDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragAndDrop_DragEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 356);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelHome;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxPasswordLogin;
        private System.Windows.Forms.TextBox textBoxNameLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxPasswordRegister;
        private System.Windows.Forms.TextBox textBoxNameRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddData;
        private System.Windows.Forms.TextBox textBoxDataToAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btDecrypt;
        private System.Windows.Forms.RichTextBox rtCipherText;
        private System.Windows.Forms.RichTextBox rtPlaintext;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox teKey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btEncrypt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btSaveText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tePassword;
        private System.Windows.Forms.Button btEncryptText;
        private System.Windows.Forms.Button preview;
        private System.Windows.Forms.RichTextBox textPreview;
        private System.Windows.Forms.Button btPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tePath;
        private System.Windows.Forms.Panel DragAndDrop;
    }
}

