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
        private HashSet<Customer> deletingList = new HashSet<Model.Customer>();

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
            }
            else
            {
                Customer = AppFacade.Facade.GetCustomer(CustomerId);
              ;
                this.dataBindingCustomer.MapToControl(this.Customer);
            }
            Customer spouse = this.Customer.GetSpouse();
            this.customerBaseInfoUC.BindDataToUI(this.Customer);
            this.customerSpouseBaseInfoUC.BindDataToUI(spouse);

            this.grdFamily.DataSource = new BindingList<Customer>(this.Customer.GetOtherFamilyMember());


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
            ComboBoxUtil.BindLov(LovType.Relation, colRelatio);
            ComboBoxUtil.BindEnumType(typeof(GenderType), colGender);
            ComboBoxUtil.BindLov(LovType.IdCardType, colIdType);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (superValidator.Validate()
                    && this.customerBaseInfoUC.ValidateData(true)
                    && this.customerSpouseBaseInfoUC.ValidateData())
                {
                    this.dataBindingCustomer.MapToObject(this.Customer);
                    this.customerBaseInfoUC.BindDataFromUI();
                    List<Customer> relation = new List<Model.Customer>();
                    Customer spouse = this.customerSpouseBaseInfoUC.BindDataFromUI();
                    if (String.IsNullOrWhiteSpace(spouse.CustomerName))
                    {
                        if (spouse.CustomerId != null)
                        {
                            this.deletingList.Add(spouse);
                        }
                    }
                    else
                    {
                        spouse.RelationWithPrimary = RelationType.Spouse.ToString();
                        relation.Add(spouse);
                    }

                    relation.AddRange(this.grdFamily.DataSource as IList<Customer>);
                    this.Customer.FamilyMember = relation;

                    AppFacade.Facade.SaveCustomer(this.Customer, this.deletingList);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private void grdFamily_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var column = grdFamily.Columns[e.ColumnIndex];
            if (column.Name == "colDelete")
            {
                Customer customer = grdFamily.Rows[e.RowIndex].DataBoundItem as Customer;
                if (customer != null
                    && MessageBoxHelper.ShowYesNo("确认删除？") == System.Windows.Forms.DialogResult.Yes)
                {
                    if (customer.CustomerId != null)
                    {
                        this.deletingList.Add(customer);
                    }
                    grdFamily.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
