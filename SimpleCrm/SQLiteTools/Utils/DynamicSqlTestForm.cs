using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Globalization;
using SimpleCrm.DynamicSql;

namespace SQLiteTools.Utils
{
    public partial class DynamicSqlTestForm : Form
    {
        public DynamicSqlTestForm()
        {
            InitializeComponent();
        }

        private void btnGetMachineCode_Click(object sender, EventArgs e)
        {
            SqlGenerator generator = new SqlGenerator();
            var sqltuple = generator.GenerateSql(txtDynamicSql.Text, new Customer() { Name = this.txtName.Text, Address = this.txtAddress.Text });
            txtSql.Text = sqltuple.Item1;
        }

    }

    public class Customer
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public Boolean HasNameAndAddress
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Address);
            }
        }
    }
}
