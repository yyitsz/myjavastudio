using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SQLiteTools.Utils;
using SQLiteTools.PaymentForm;

namespace SQLiteTools
{
    public partial class SQLiteToolsMainForm : Form
    {
        public SQLiteToolsMainForm()
        {
            InitializeComponent();
        }



        private void ShowForm<T>()
            where T : Form, new()
        {
            T form = FindOpenedForm<T>();
            if (form == null)
            {
                form = new T();
                form.MdiParent = this;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.WindowState = FormWindowState.Maximized;
                form.Show();
            }
            else
            {
                form.Activate();
                if (form.WindowState == FormWindowState.Minimized)
                {
                    form.WindowState = FormWindowState.Normal;
                }
            }
        }
        private T FindOpenedForm<T>() where T : Form
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.GetType() == typeof(T))
                {
                    return (T)form;
                }
            }
            return default(T);
        }

        private void SQLiteMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxHelper.ShowYesNo("Are you sure to quit SQLiteTools Application?") == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void mntExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SQLiteMainForm_Load(object sender, EventArgs e)
        {

        }

        private void mnuDbManager_Click(object sender, EventArgs e)
        {
            ShowForm<DbToolsForm>();
        }

        private void mnuDbQuery_Click(object sender, EventArgs e)
        {
            ShowForm<DbQueryForm>();
        }

        private void mnuReg_Click(object sender, EventArgs e)
        {
            ShowForm<RegisterForm.RegisterManagerForm>();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm<DynamicSqlTestForm>();
        }
    }
}