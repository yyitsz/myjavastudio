using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using SQLiteTools.Utils;
using System.Linq;
using System.IO;

namespace SQLiteTools.PaymentForm
{
    public partial class DbToolsForm : Form
    {
        public DbToolsForm()
        {
            InitializeComponent();
        }

        private void btnSelectDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.FileName = txtDbFile.Text.Trim();
            diag.Multiselect = false;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                txtDbFile.Text = diag.FileName;
            }
        }

        private void btnEncryptDb_Click(object sender, EventArgs e)
        {
            if (txtDbFile.Text.Trim().Length == 0)
            {
                MessageBoxHelper.ShowPrompt("Please select db.");
            }
            String connectionStr = "Data Source = " + txtDbFile.Text;
            String oldPwd = txtOldPwd.Text.Trim();
            String newPwd = txtNewPwd.Text.Trim();

            using (var conn = GetConnection(connectionStr))
            {
                if (oldPwd.Length > 0)
                {
                    conn.SetPassword(oldPwd);
                }
                conn.Open();
                if (String.IsNullOrEmpty(newPwd))
                {
                    newPwd = null;
                }
                conn.ChangePassword(newPwd);
            }
            MessageBoxHelper.ShowPrompt("Changed Password successful");
        }

        public static SQLiteConnection GetConnection(String connStr)
        {
            SQLiteConnection cnn = new SQLiteConnection(connStr);
            return cnn;

        }

        private void btnCreateNewDb_Click(object sender, EventArgs e)
        {
            String dbFile = txtNewDbFile.Text.Trim();
            if (dbFile.Length == 0)
            {
                MessageBoxHelper.ShowPrompt("Please set DB file.");
                return;
            }

            if (File.Exists(dbFile))
            {
                 MessageBoxHelper.ShowPrompt("Exsist DB file.");
                return;
            }
            SQLiteConnection.CreateFile(dbFile);

            String connectionStr = "Data Source = " + txtNewDbFile.Text;
            String pwd = txtPwdForCreation.Text.Trim();
            using (var conn = GetConnection(connectionStr))
            {
                if (pwd.Length > 0)
                {
                    conn.SetPassword(pwd);
                }
                conn.Open();
                String[] scriptFile = StringToFileNameArray(txtNewSqlScriptFiles.Text.Trim());
                foreach (String file in scriptFile)
                {
                    ExecuteSqlScriptFile(conn, file);
                }
                
            }
            MessageBoxHelper.ShowPrompt("Create successful");
        }

        private static void ExecuteSqlScript(SQLiteConnection conn, String file)
        {
            String content = File.ReadAllText(file);
            String[] cmds = content.Split(new string[] { ";\r\n" },StringSplitOptions.RemoveEmptyEntries);
            foreach (var cmdTxt in cmds)
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = cmdTxt;
                cmd.ExecuteNonQuery();
            }

        }

        private static void ExecuteSqlScriptFile(SQLiteConnection conn, String file)
        {

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = File.ReadAllText(file);
                cmd.ExecuteNonQuery();
        }

        private void btnSqlScriptFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            //diag.FileName = txtNewSqlScriptFiles.Text.Trim();
            diag.Filter = "sql file(*.sql)|*.sql";
            diag.Multiselect = true;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                txtNewSqlScriptFiles.Text = FileNameArrayToString(diag.FileNames);
            }
        }

        public String[] StringToFileNameArray(String str)
        {
            return str.Split(':');
        }
        public String FileNameArrayToString(String[] stringArray)
        {
            if (stringArray.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var s in stringArray)
                {
                    sb.Append(s).Append(":");
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
            else {
                return "";
            }
        }

        private void btnNewDbBrowse_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog diag = new SaveFileDialog();
            diag.FileName = txtNewDbFile.Text.Trim();
            diag.Filter = "sqlite file(*.sqlite)|*.sqlite";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                txtNewDbFile.Text = diag.FileName;
            }
        }

        private void btnEncrpt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = PasswordUtil.Encrypt(txtInput.Text);            
        }

        private void btnDecrpt_Click(object sender, EventArgs e)
        {
            txtOutput.Text = PasswordUtil.Decrypt(txtInput.Text); 
        }

   
    }
}
