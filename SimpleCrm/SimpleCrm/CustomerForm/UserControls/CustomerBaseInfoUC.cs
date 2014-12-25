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
            grdContactInfo.Enabled = false;
            grdContactInfo.Enabled = true;
            if (customerIsRequired)
            {
                valid = ValidationHelper.ValidateRequiredField(errorProvider, highlighter, this.txtCustomerName) && valid;
            }
            if (txtIdCardNo.Text.Trim().Length > 0 || ComboBoxUtil.Selected(this.cmbIdType))
            {
                valid = ValidationHelper.ValidateRequiredField(errorProvider, highlighter, this.cmbIdType) && valid;
                valid = ValidationHelper.ValidateRequiredField(errorProvider, highlighter, this.txtIdCardNo) && valid;
                if (valid && this.cmbIdType.SelectedValue.Equals("IDCard"))
                {
                    valid = ValidationHelper.FillBirthdayAndGenderWithIdCardNo(txtIdCardNo, errorProvider);
                }
            }

            foreach (DataGridViewRow row in this.grdContactInfo.Rows)
            {
                ContactInfo contactInfo = row.DataBoundItem as ContactInfo;
                if (contactInfo != null)
                {
                    valid = ValidationHelper.ValidateRequiredField(row, "colContactType", "colContactMethod") && valid;
                }
            }

            IList<ContactInfo> contacts = grdContactInfo.DataSource as IList<ContactInfo>;
            if (valid && contacts != null)
            {
                foreach (var v1 in contacts)
                {
                    foreach (var v2 in contacts)
                    {
                        if (v1 != v2 && v1.ContactType == v2.ContactType)
                        {
                            MessageBoxHelper.ShowPrompt("录入了重复的联系方式类别！");
                            return false;
                        }
                    }
                }
            }
            return valid;
        }

        private void txtIdCardNo_Leave(object sender, EventArgs e)
        {
            if (ComboBoxUtil.Selected(cmbIdType) && this.cmbIdType.SelectedValue.Equals("IDCard"))
            {
                ValidationHelper.FillBirthdayAndGenderWithIdCardNo(txtIdCardNo, this.errorProvider, dtBirthday, cmbGender);
            }
        }

    }
}
