using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RecourceConverter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecourceConverter.frmResourceConverter form = new frmResourceConverter();
            form.MdiParent = this;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecourceConverter.frmXlsToXml form = new frmXlsToXml();
            form.MdiParent = this;
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = ".xls";
            dialog.Filter = "Excel File(*.xls)|*.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename= dialog.FileName;

                ExcelImportUtil2 util = new ExcelImportUtil2();
                DataSet ds = util.ExcelToDS(filename);
            }
        }
    }
}