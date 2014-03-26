using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SqlParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            Parser p = new Parser(txtSource.Text);
            Expression exp = p.Parse();
            ExpressionContext ctx = new ExpressionContext();
            ctx.Add("a", false);
            ctx.Add("b", true);
            List<String> list = new List<string>();
            list.Add("Leo");
            list.Add("Michael");
            ctx.Add("names", list);
            txtResult.Text = exp.Eval(ctx);
            foreach (string var in p.VarList)
            {
                txtVarList.Text += var + Environment.NewLine;
            }
        }
    }
}