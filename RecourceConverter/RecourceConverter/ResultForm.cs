using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RecourceConverter
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        public string Content
        {
            get { return this.richTextBox1.Text; }
            set { this.richTextBox1.Text = value; }
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {

        }
    }
}