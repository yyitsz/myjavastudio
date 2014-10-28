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
    public partial class CustomerDetailForm : BaseForm
    {
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }

        public CustomerDetailForm()
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
            if (this.FormMode == SimpleCrm.FormMode.Add)
            {
                this.Customer = new Customer();
                this.grdFamily.DataSource = new BindingList<Customer>();
            }
            else
            {
                Customer = AppFacade.Facade.GetCustomer(CustomerId);
                this.dataBindingCustomer.MapToControl(this.Customer);
                this.grdFamily.DataSource = new BindingList<Customer>(AppFacade.Facade.GetCustomerByRelation(CustomerId));
            }
            this.customerBaseInfoUC.BindDataToUI(this.Customer);

            if (FormMode == SimpleCrm.FormMode.View)
            {
                this.Text = "查看客户详细信息";
                new ReadonlyHelper(this).SetReadonly();
                this.btnSave.Visible = false;
            }
            else if (FormMode == SimpleCrm.FormMode.Add)
            {
                this.Text = "新增客户详细信息";
            }
            else if (FormMode == SimpleCrm.FormMode.Edit)
            {
                this.Text = "修改客户详细信息 - " + this.Customer.CustomerName;
            }
        }

        private void InitForm()
        {
            ComboBoxUtil.BindLov(LovType.CustomerClass, cmbCustomerClass);
            ComboBoxUtil.BindLov(LovType.CustomerSource, cmbCustomerSource);
            ComboBoxUtil.BindLov(LovType.IntentPhase, cmbIntentPhase);
            ComboBoxUtil.BindLov(LovType.CustomerStatus, cmbCustomerStatus);
            ComboBoxUtil.BindEnumType(typeof(GenderType), colGender);
            ComboBoxUtil.BindLov(LovType.IdCardType, colIdType);
            ComboBoxUtil.BindLov(LovType.Relation, colRelation);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (superValidator.Validate()
                    && this.customerBaseInfoUC.ValidateData(true)
                    && this.ValidateData())
                {
                    this.dataBindingCustomer.MapToObject(this.Customer);
                    this.customerBaseInfoUC.BindDataFromUI();
                    List<Customer> relation = new List<Customer>();

                    relation.AddRange(this.grdFamily.DataSource as IList<Customer>);
                    AppFacade.Facade.SaveCustomer(this.Customer, relation);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private bool ValidateData()
        {
            bool isValid = true;
            foreach (Customer c in grdFamily.DataSource as IList<Customer>)
            {
                if (String.IsNullOrWhiteSpace(c.CustomerName))
                {
                    MessageBoxHelper.ShowPrompt("客户姓名是必填的.");
                    isValid = false;
                    break;
                }
                if (String.IsNullOrWhiteSpace(c.Relation))
                {
                    MessageBoxHelper.ShowPrompt("关系是必填的.");
                    isValid = false;
                    break;
                }
            }
            if (isValid == false)
            {
                tabCustomer.SelectedTab = tiFamily;
            }
            return isValid;
        }

        private void grdFamily_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var column = grdFamily.Columns[e.ColumnIndex];
            if (column.Name == "colDelete")
            {
                Customer customer = grdFamily.Rows[e.RowIndex].DataBoundItem as Customer;
                String msg = ErrorCode.DELETE_CUSTOMER;
                if (customer.CustomerId != null)
                {
                    msg = ErrorCode.DELETE_CUSTOMER_RELATION;
                }
                if (customer != null
                    && MessageBoxHelper.ShowYesNo(msg) == System.Windows.Forms.DialogResult.Yes)
                {
                    grdFamily.Rows.RemoveAt(e.RowIndex);
                }
            }
            else if (column.Name == "colEdit")
            {
                Customer customer = grdFamily.Rows[e.RowIndex].DataBoundItem as Customer;
                CustomerBaseDetailForm form = new CustomerBaseDetailForm();
                form.Customer = customer;
                form.ShowDialog();
            }
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            CustomerPickListForm form = new CustomerPickListForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK && form.CustomerDto != null)
            {
                if (form.CustomerDto.CustomerId == this.Customer.CustomerId)
                {
                    return;
                }
                foreach (Customer c in grdFamily.DataSource as IList<Customer>)
                {
                    if (c.CustomerId == form.CustomerDto.CustomerId)
                    {
                        return;
                    }
                }

                Customer selectedCustomer = AppFacade.Facade.GetCustomer(form.CustomerDto.CustomerId.Value);
                (grdFamily.DataSource as BindingList<Customer>).Add(selectedCustomer);
            }
        }
    }
}
