using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mouse.Main
{
    public partial class InputCode2Form : Form
    {
        public InputCode2Form()
        {
            InitializeComponent();
        }

        public String Url { get; set; }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void InputCode2Form_Load(object sender, EventArgs e)
        {
            if (Url == null)
            {
                this.Url = "http://www.lishidl.cn/n/antispiderShowVerify.ac";
            }
            this.webBrowser.Navigate(this.Url);
        }
    }
}
