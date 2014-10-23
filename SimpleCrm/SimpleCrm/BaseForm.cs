using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Facade;

namespace SimpleCrm
{
    public partial class BaseForm : DevComponents.DotNetBar.Office2007Form
    {

        public FormMode FormMode { get; set; }
        public BaseForm()
        {
            FormMode = SimpleCrm.FormMode.Add;
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(BaseForm_FormClosing);
        }

        void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var form in this.OwnedForms)
            {
                form.Close();
            }
        }
    }

    public enum FormMode
    {
        Add,
        Edit,
        Delete,
        View,
    }
}