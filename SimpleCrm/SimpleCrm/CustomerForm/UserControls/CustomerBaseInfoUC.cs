using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Utils;
using SimpleCrm.Model;
using DevComponents.DotNetBar.Validator;
using SimpleCrm.Facade;
using DevComponents.DotNetBar.Controls;

namespace SimpleCrm.CustomerForm.UserControls
{
    public partial class CustomerBaseInfoUC : UserControl
    {
        private Customer customer;
        public Customer Customer { get { return customer; } }
        public CustomerBaseInfoUC()
        {
            InitializeComponent();
            if (AppFacade.Facade.MainForm != null)
            {
                InitForm();
            }
        }

        private void CustomerBaseInfoUC_Load(object sender, EventArgs e)
        {

        }

        private void InitForm()
        {
            ComboBoxUtil.BindLov(Model.LovType.ContactType, colContactType, false);
            ComboBoxUtil.BindLov(Model.LovType.IdCardType, cmbIdType, true);
            ComboBoxUtil.BindEnumType(typeof(GenderType), cmbGender, true);

        }

        private void grdContactInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var column = grdContactInfo.Columns[e.ColumnIndex];
            if (column.Name == "colDelete")
            {
                if (MessageBoxHelper.ShowYesNo("确实要删除吗？") == DialogResult.Yes)
                {
                    grdContactInfo.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        //public void BindCustomerList(IList<Customer> customerList)
        //{
        //    Customer newCus = new Customer();
        //    newCus.CustomerName = "新增客户...";
        //    newCus.CustomerId = -9999;
        //    customerList.Add(newCus);

        //    txtCustomerName.DataSource = this.customerList;
        //    txtCustomerName.DisplayMember = "CustomerName";
        //    txtCustomerName.ValueMember = "CustomerName";
        //    txtCustomerName.SelectedIndexChanged += txtCustomerName_SelectedIndexChanged;

        //}
        public void BindDataToUI(Customer customer)
        {

            this.customer = customer;
            if (this.customer == null)
            {
                this.dataBindingCustomer.ClearControlValue();
                this.grdContactInfo.DataSource = new BindingList<ContactInfo>();
            }
            else
            {
                this.dataBindingCustomer.MapToControl(this.customer);
                this.txtCustomerName.Text = this.customer.CustomerName;
                List<ContactInfo> contactInfoList = this.customer.Contacts;
                if (contactInfoList == null)
                {
                    contactInfoList = new List<ContactInfo>();
                }

                this.grdContactInfo.DataSource = new BindingList<ContactInfo>(customer.Contacts);
            }

        }

        public Customer BindDataFromUI()
        {
            if (this.customer == null)
            {
                this.customer = new Customer();
            }
            dataBindingCustomer.MapToObject(this.customer);
            this.customer.CustomerName = txtCustomerName.Text.Trim();
            IList<ContactInfo> list = this.grdContactInfo.DataSource as IList<ContactInfo>;
            if (list != null)
            {
                this.customer.Contacts = list.ToList();
            }
            else
            {
                this.customer.Contacts = new List<ContactInfo>();
            }
            return this.customer;
        }

        public bool ValidateData(bool customerIsRequired = false)
        {
            bool valid = true;
            if (customerIsRequired)
            {
                valid = ValidationHelper.ValidateRequiredField(errorProvider, highlighter, this.txtCustomerName) && valid;
            }

            foreach (DataGridViewRow row in this.grdContactInfo.Rows)
            {
                ContactInfo contactInfo = row.DataBoundItem as ContactInfo;
                if (contactInfo != null)
                {
                    valid = ValidationHelper.ValidateRequiredField(row, "colContactType", "colContactMethod") && valid;
                }
            }
            return valid;
        }


        //private void txtCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrWhiteSpace(txtCustomerName.Text.Trim()))
        //    {
        //        String customerName = txtCustomerName.Text.Trim();
        //        Customer c = txtCustomerName.SelectedItem as Customer;
        //        if (c != null)
        //        {
        //            if (c.CustomerId == -9999)
        //            {
        //                BindDataToUI(new Customer());
        //            }
        //            else 
        //            {
        //                BindDataToUI(customer);
        //            }
        //        }               
        //    }
        //}

    }
}
