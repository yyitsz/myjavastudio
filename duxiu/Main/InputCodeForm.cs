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
    public partial class InputCodeForm : Form
    {
        public InputCodeForm()
        {
            InitializeComponent();
        }

        public String Code 
        {
            get { return txtCode.Text; }
        }

        public Byte[] Image {

            set
            {
                this.picCode.Image = System.Drawing.Image.FromStream(new MemoryStream(value));
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtCode.Text.Trim().Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
