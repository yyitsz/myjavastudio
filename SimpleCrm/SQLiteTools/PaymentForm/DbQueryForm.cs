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
    public partial class DbQueryForm : Form
    {
        public DbQueryForm()
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



        public SQLiteConnection GetConnection(String file, String pwd)
        {
            String connStr = String.Format("Data Source={0};Version=3;Password={1}", file, pwd ?? "");
            SQLiteConnection cnn = new SQLiteConnection(connStr);
            return cnn;

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            String dbFile = txtDbFile.Text.Trim();
            String pwd = txtPwd.Text.Trim();
            if (dbFile.Length == 0)
            {
                MessageBoxHelper.ShowPrompt("Please set DB file.");
                return;
            }

            if (txtCmd.Text.Trim().Length == 0)
            {
                MessageBoxHelper.ShowPrompt("Please input sql command.");
                return;
            }
            try
            {
                txtMessage.Clear();
                String command = txtCmd.Text.Trim();
                grdResult.DataSource = null;
                txtMessage.AppendText("Executing " + command + Environment.NewLine);
                txtMessage.AppendText("Start: " + DateTime.Now + Environment.NewLine);
                using (var conn = GetConnection(dbFile, pwd))
                {
                    conn.Open();

                    SQLiteCommand sqlcmd = conn.CreateCommand();
                    sqlcmd.CommandText = command;

                    if (command.StartsWith("select", StringComparison.InvariantCultureIgnoreCase))
                    {
                        DataSet ds = new DataSet();
                        SQLiteDataAdapter adaper = new SQLiteDataAdapter(sqlcmd);
                        adaper.Fill(ds);
                        grdResult.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        int count = sqlcmd.ExecuteNonQuery();
                        txtMessage.AppendText("Executed Successful. Affected Records: " + count + Environment.NewLine);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                txtMessage.AppendText("Error:");
                txtMessage.AppendText(ex.Message);
                txtMessage.AppendText(ex.StackTrace);
                txtMessage.AppendText(Environment.NewLine);
            }
            finally
            {
                txtMessage.AppendText("End: " + DateTime.Now + Environment.NewLine);
            }

        }

    }
}
