namespace Client
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.buttonAddData = new System.Windows.Forms.Button();
            this.textBoxDataToAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
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
            // buttonAddData
            // 
            this.buttonAddData.Location = new System.Drawing.Point(483, 154);
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
            this.textBoxDataToAdd.Size = new System.Drawing.Size(455, 117);
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
    }
}

