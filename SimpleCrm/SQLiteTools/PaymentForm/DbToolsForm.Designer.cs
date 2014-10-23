namespace SQLiteTools.PaymentForm
{
    partial class DbToolsForm
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
            this.btnEncryptDb = new System.Windows.Forms.Button();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDbFile = new System.Windows.Forms.TextBox();
            this.btnSelectDb = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEncrpt = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSqlScriptFileBrowse = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewSqlScriptFiles = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreateNewDb = new System.Windows.Forms.Button();
            this.txtPwdForCreation = new System.Windows.Forms.TextBox();
            this.btnNewDbBrowse = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNewDbFile = new System.Windows.Forms.TextBox();
            this.btnDecrpt = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEncryptDb
            // 
            this.btnEncryptDb.Location = new System.Drawing.Point(129, 115);
            this.btnEncryptDb.Name = "btnEncryptDb";
            this.btnEncryptDb.Size = new System.Drawing.Size(121, 23);
            this.btnEncryptDb.TabIndex = 0;
            this.btnEncryptDb.Text = "Change Password";
            this.btnEncryptDb.UseVisualStyleBackColor = true;
            this.btnEncryptDb.Click += new System.EventHandler(this.btnEncryptDb_Click);
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(129, 47);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(100, 21);
            this.txtNewPwd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "DB";
            // 
            // txtDbFile
            // 
            this.txtDbFile.Location = new System.Drawing.Point(129, 76);
            this.txtDbFile.Name = "txtDbFile";
            this.txtDbFile.Size = new System.Drawing.Size(312, 21);
            this.txtDbFile.TabIndex = 3;
            // 
            // btnSelectDb
            // 
            this.btnSelectDb.Location = new System.Drawing.Point(457, 75);
            this.btnSelectDb.Name = "btnSelectDb";
            this.btnSelectDb.Size = new System.Drawing.Size(32, 23);
            this.btnSelectDb.TabIndex = 5;
            this.btnSelectDb.Text = "...";
            this.btnSelectDb.UseVisualStyleBackColor = true;
            this.btnSelectDb.Click += new System.EventHandler(this.btnSelectDb_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Old Password";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(129, 19);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(100, 21);
            this.txtOldPwd.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEncryptDb);
            this.groupBox1.Controls.Add(this.txtOldPwd);
            this.groupBox1.Controls.Add(this.txtNewPwd);
            this.groupBox1.Controls.Add(this.btnSelectDb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDbFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 151);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encrypt/Decrypt Database";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDecrpt);
            this.groupBox2.Controls.Add(this.btnEncrpt);
            this.groupBox2.Controls.Add(this.txtInput);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 128);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Encrypt/Decrypt Password";
            // 
            // btnEncrpt
            // 
            this.btnEncrpt.Location = new System.Drawing.Point(88, 90);
            this.btnEncrpt.Name = "btnEncrpt";
            this.btnEncrpt.Size = new System.Drawing.Size(141, 23);
            this.btnEncrpt.TabIndex = 0;
            this.btnEncrpt.Text = "Encrypt Password";
            this.btnEncrpt.UseVisualStyleBackColor = true;
            this.btnEncrpt.Click += new System.EventHandler(this.btnEncrpt_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(163, 20);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(253, 21);
            this.txtInput.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Input";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Output";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(163, 49);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(253, 21);
            this.txtOutput.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSqlScriptFileBrowse);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtNewSqlScriptFiles);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnCreateNewDb);
            this.groupBox3.Controls.Add(this.txtPwdForCreation);
            this.groupBox3.Controls.Add(this.btnNewDbBrowse);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtNewDbFile);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(748, 151);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create Database";
            // 
            // btnSqlScriptFileBrowse
            // 
            this.btnSqlScriptFileBrowse.Location = new System.Drawing.Point(457, 79);
            this.btnSqlScriptFileBrowse.Name = "btnSqlScriptFileBrowse";
            this.btnSqlScriptFileBrowse.Size = new System.Drawing.Size(32, 23);
            this.btnSqlScriptFileBrowse.TabIndex = 10;
            this.btnSqlScriptFileBrowse.Text = "...";
            this.btnSqlScriptFileBrowse.UseVisualStyleBackColor = true;
            this.btnSqlScriptFileBrowse.Click += new System.EventHandler(this.btnSqlScriptFileBrowse_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "Sql Script File";
            // 
            // txtNewSqlScriptFiles
            // 
            this.txtNewSqlScriptFiles.Location = new System.Drawing.Point(129, 80);
            this.txtNewSqlScriptFiles.Name = "txtNewSqlScriptFiles";
            this.txtNewSqlScriptFiles.Size = new System.Drawing.Size(312, 21);
            this.txtNewSqlScriptFiles.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Password";
            // 
            // btnCreateNewDb
            // 
            this.btnCreateNewDb.Location = new System.Drawing.Point(129, 107);
            this.btnCreateNewDb.Name = "btnCreateNewDb";
            this.btnCreateNewDb.Size = new System.Drawing.Size(121, 23);
            this.btnCreateNewDb.TabIndex = 0;
            this.btnCreateNewDb.Text = "Create Database";
            this.btnCreateNewDb.UseVisualStyleBackColor = true;
            this.btnCreateNewDb.Click += new System.EventHandler(this.btnCreateNewDb_Click);
            // 
            // txtPwdForCreation
            // 
            this.txtPwdForCreation.Location = new System.Drawing.Point(129, 19);
            this.txtPwdForCreation.Name = "txtPwdForCreation";
            this.txtPwdForCreation.Size = new System.Drawing.Size(100, 21);
            this.txtPwdForCreation.TabIndex = 6;
            // 
            // btnNewDbBrowse
            // 
            this.btnNewDbBrowse.Location = new System.Drawing.Point(457, 51);
            this.btnNewDbBrowse.Name = "btnNewDbBrowse";
            this.btnNewDbBrowse.Size = new System.Drawing.Size(32, 23);
            this.btnNewDbBrowse.TabIndex = 5;
            this.btnNewDbBrowse.Text = "...";
            this.btnNewDbBrowse.UseVisualStyleBackColor = true;
            this.btnNewDbBrowse.Click += new System.EventHandler(this.btnNewDbBrowse_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "DB";
            // 
            // txtNewDbFile
            // 
            this.txtNewDbFile.Location = new System.Drawing.Point(129, 52);
            this.txtNewDbFile.Name = "txtNewDbFile";
            this.txtNewDbFile.Size = new System.Drawing.Size(312, 21);
            this.txtNewDbFile.TabIndex = 3;
            // 
            // btnDecrpt
            // 
            this.btnDecrpt.Location = new System.Drawing.Point(237, 90);
            this.btnDecrpt.Name = "btnDecrpt";
            this.btnDecrpt.Size = new System.Drawing.Size(146, 23);
            this.btnDecrpt.TabIndex = 5;
            this.btnDecrpt.Text = "Decrypt Password";
            this.btnDecrpt.UseVisualStyleBackColor = true;
            this.btnDecrpt.Click += new System.EventHandler(this.btnDecrpt_Click);
            // 
            // DbToolsForm
            // 
            this.ClientSize = new System.Drawing.Size(748, 465);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DbToolsForm";
            this.Text = "DB Tools";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEncryptDb;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDbFile;
        private System.Windows.Forms.Button btnSelectDb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEncrpt;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSqlScriptFileBrowse;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNewSqlScriptFiles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateNewDb;
        private System.Windows.Forms.TextBox txtPwdForCreation;
        private System.Windows.Forms.Button btnNewDbBrowse;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNewDbFile;
        private System.Windows.Forms.Button btnDecrpt;
    }
}
