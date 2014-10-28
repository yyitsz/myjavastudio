using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Model;
using SimpleCrm.Facade;
using SimpleCrm.Utils;

namespace SimpleCrm.CustomerForm
{
    public partial class CustomerBaseDetailForm : BaseForm
    {
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public long? PrimaryCustomerId { get; set; }
        public string PrimaryCustomerName { get; set; }
        private bool showOnly = false;

        public CustomerBaseDetailForm()
        {
            InitializeComponent();
        }

        private void CustomerDetailForm_Load(object sender, EventArgs e)
        {
            InitForm();
            BindData();
        }

        private void BindData()
        {
            if (this.Customer == null)
            {
                if (this.FormMode == SimpleCrm.FormMode.Add)
                {
                    this.Customer = new Customer();
                }
                else
                {
                    Customer = AppFacade.Facade.GetCustomer(CustomerId);
                }
            }
            else 
            {
                showOnly = true;
                btnClose.Text = "取消(&C)";
                btnSave.Text = "确定(&O)";
            }
            this.dataBindingCustomer.MapToControl(this.Customer);
            this.customerBaseInfoUC.BindDataToUI(this.Customer);

            if (FormMode == SimpleCrm.FormMode.View)
            {
                this.Text = "客户基本信息 - " + this.Customer.CustomerName;
                new ReadonlyHelper(this).SetReadonly();
                this.btnSave.Visible = false;
            }
            else if (FormMode == SimpleCrm.FormMode.Add)
            {
                this.Text = "新增客户基本信息";
            }
            else if (FormMode == SimpleCrm.FormMode.Edit)
            {
                this.Text = "修改客户基本信息 - " + this.Customer.CustomerName;
            }
        }

        private void InitForm()
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (superValidator.Validate()
                    && this.customerBaseInfoUC.ValidateData(true))
                {
                    this.customerBaseInfoUC.BindDataFromUI();
                    this.dataBindingCustomer.MapToObject(this.Customer);
                    if (showOnly == false)
                    {
                        AppFacade.Facade.SaveCustomerBaseInfo(this.Customer);
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
