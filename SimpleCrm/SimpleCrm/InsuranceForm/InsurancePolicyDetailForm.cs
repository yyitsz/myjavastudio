using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.DTO;
using SimpleCrm.Model;
using SimpleCrm.Facade;
using SimpleCrm.Common;
using SimpleCrm.Utils;
using SimpleCrm.CustomerForm.UserControls;

namespace SimpleCrm.InsuranceForm
{
    public partial class InsurancePolicyDetailForm : BaseForm
    {
        public long? InsurancePolicyId { get; set; }
        public long? PrimaryCustomerId { get; set; }
        private Customer primaryCustomer;
        private InsurancePolicy insurancePolicy;
        private List<Customer> relatedCustomerList;
        private Customer newTag = new Customer();
        private Customer emptyTag = new Customer();

        public InsurancePolicyDetailForm()
        {
            newTag.CustomerName = "新增...";
            emptyTag.CustomerName = "";

            InitializeComponent();
        }

        private void InsurancePolicyDetailForm_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();

        }

        private void LoadData()
        {
            GetPrimaryCustomer();
            if (InsurancePolicyId != null)
            {
                this.insurancePolicy = AppFacade.Facade.GetInsurancePolicy(InsurancePolicyId.Value);
                if (this.insurancePolicy == null)
                {
                    throw new AppException("找不到保单。");
                }

                if (this.PrimaryCustomerId == null)
                {
                    this.PrimaryCustomerId = this.insurancePolicy.CustomerId.Value;
                    GetPrimaryCustomer();
                }
            }

            if (this.insurancePolicy != null)
            {
                this.dataBindingIP.MapToControl(this.insurancePolicy);
                this.holderBaseInfo.BindDataToUI(this.insurancePolicy.PolicyHolder);
                this.insuredBaseInfo.BindDataToUI(this.insurancePolicy.Insured);
                if (this.insurancePolicy.Insured != null && this.insurancePolicy.Insured.CustomerId != this.insurancePolicy.PolicyHolder.CustomerId)
                {
                    this.cmbRelation.SelectedValue = this.insurancePolicy.Insured.Relation;

                }
                this.grdBeneficiary.DataSource = new BindingList<Customer>(this.insurancePolicy.Beneficiaries);
            }

            if (this.FormMode == SimpleCrm.FormMode.View)
            {
                new ReadonlyHelper(this).SetReadonly();
                btnSave.Visible = false;
                ribbonBarMergeContainer1.Visible = false;
            }
            else
            {
                relatedCustomerList = AppFacade.Facade.GetCustomerByRelation(this.PrimaryCustomerId.Value);
                HashSet<Customer> customerSet = new HashSet<Customer>(new ModelEqualityComparer<Customer>());
                if (this.insurancePolicy != null)
                {
                    if (this.insurancePolicy.PolicyHolder != null)
                    {
                        customerSet.Add(this.insurancePolicy.PolicyHolder);
                    }
                    if (this.insurancePolicy.Insured != null)
                    {
                        customerSet.Add(this.insurancePolicy.Insured);
                    }
                    customerSet.AddRange(this.insurancePolicy.Beneficiaries);

                    if (this.insurancePolicy.Insured != null && this.insurancePolicy.PolicyHolder == this.insurancePolicy.Insured)
                    {
                        chkSameHolderAndInsured.Checked = true;
                    }
                }
                if (this.primaryCustomer != null)
                {
                    customerSet.Add(this.primaryCustomer);
                }
                customerSet.AddRange(relatedCustomerList);
                relatedCustomerList = customerSet.ToList();

                BindRelatedCustomerToComboBox();
            }


            this.txtCustomerName.Text = this.primaryCustomer.CustomerName;
            this.Text = "保单详细信息 - " + this.primaryCustomer.CustomerName;
            this.ribbonBarMergeContainer1.RibbonTabText = this.Text;
        }

        private void GetPrimaryCustomer()
        {
            if (this.PrimaryCustomerId != null)
            {
                this.primaryCustomer = AppFacade.Facade.GetCustomer(this.PrimaryCustomerId.Value);
                if (this.primaryCustomer == null)
                {
                    throw new AppException("找不到客户。");
                }
            }
        }

        private void BindRelatedCustomerToComboBox()
        {
            List<Customer> ds = new List<Customer>();
            ds.Add(emptyTag);
            ds.Add(newTag);
            ds.AddRange(this.relatedCustomerList);
            cmbCustomerList.DisplayMember = "CustomerName";
            cmbCustomerList.Items.AddRange(ds.ToArray());
            cmbCustomerList.SelectedIndexChanged += new EventHandler(cmbCustomerList_SelectedIndexChanged);
        }

        private void cmbCustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer c = cmbCustomerList.SelectedItem as Customer;
            if (c != null && c != emptyTag)
            {
                if (tabIPInfo.SelectedTab == tiPolicyHolder)
                {
                    BindCustomerToUI(c, holderBaseInfo);
                    if (tiInsured.Visible && chkSameHolderAndInsured.Checked)
                    {
                        BindCustomerToUI(c, insuredBaseInfo);
                    }
                }
                else if (tiInsured.Visible && tabIPInfo.SelectedTab == tiInsured && chkSameHolderAndInsured.Checked == false)
                {
                    BindCustomerToUI(c, insuredBaseInfo);
                }
                else if (tiBeneficiary.Visible && tabIPInfo.SelectedTab == tiBeneficiary)
                {
                    AddCustomerToBeneficiary(c);
                }
            }
        }

        private void AddCustomerToBeneficiary(Customer customer)
        {
            if (customer != newTag)
            {
                IList<Customer> beneficiaries = grdBeneficiary.DataSource as IList<Customer>;
                if (beneficiaries.FirstOrDefault(c => c.CustomerId == customer.CustomerId) == null)
                {

                    if (MessageBoxHelper.ShowYesNo("添加现有的客户作为受益人. 是否继续?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        beneficiaries.Add(customer);
                    }
                }
            }

        }

        private void BindCustomerToUI(Customer c, CustomerBaseInfoUC control)
        {
            if (c == newTag)
            {
                if (control.Customer == null || control.Customer.CustomerId == null)
                {
                    // return;
                }
                else
                {
                    if (MessageBoxHelper.ShowYesNo("将创建新的投保人/被保人，原有投保人/被保人信息依然保留. 是否继续?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        control.BindDataToUI(new Customer());
                    }
                }
            }
            else if (control.Customer == null || control.Customer.CustomerId == null || control.Customer.CustomerId != c.CustomerId)
            {
                if (MessageBoxHelper.ShowYesNo("使用现有的客户作为投保人/被保人. 是否继续?") == System.Windows.Forms.DialogResult.Yes)
                {
                    control.BindDataToUI(c);
                }
            }
        }

        private void InitForm()
        {
            ComboBoxUtil.BindLov(LovType.InsurancePolicyCategory, cmbCategory);
            ComboBoxUtil.BindLov(LovType.InsurancePolicyStatus, cmbStatus);
            ComboBoxUtil.BindEnumType(typeof(GenderType), colGender);
            ComboBoxUtil.BindLov(LovType.IdCardType, colIdType);
            ComboBoxUtil.BindLov(LovType.Relation, colRelationWithInsured, true);
            ComboBoxUtil.BindLov(LovType.Relation, cmbRelation, true);
            cmbCustomerList.Enabled = false;

            this.grdBeneficiary.DataSource = new BindingList<Customer>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData())
                {
                    InsurancePolicy policy = this.insurancePolicy;
                    if (policy == null)
                    {
                        policy = new InsurancePolicy();
                        policy.CustomerId = this.PrimaryCustomerId;
                    }
                    dataBindingIP.MapToObject(policy);
                    policy.PolicyHolder = holderBaseInfo.BindDataFromUI();

                    if (tiInsured.Visible)
                    {
                        if (chkSameHolderAndInsured.Checked)
                        {
                            policy.Insured = policy.PolicyHolder;
                        }
                        else
                        {
                            policy.Insured = insuredBaseInfo.BindDataFromUI();
                            policy.Insured.Relation = cmbRelation.SelectedValue.ToString();
                        }

                        if (policy.Insured.CustomerName == policy.PolicyHolder.CustomerName)
                        {
                            MessageBoxHelper.ShowPrompt("投保人与被保人姓名相同，如果是本人投保，请勾选[本人投保]");
                            return;
                        }
                    }
                    else
                    {
                        policy.Insured = null;
                    }
                    if (tiBeneficiary.Visible)
                    {
                        policy.Beneficiaries = (grdBeneficiary.DataSource as BindingList<Customer>).ToList();
                    }
                    else
                    {
                        policy.Beneficiaries = new List<Customer>();
                    }

                    AppFacade.Facade.SaveInsurancePolicy(policy);
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
            isValid = superValidator.Validate();
            if (isValid == false)
            {
                tabIPInfo.SelectedTab = tiBaseInfo;
                return isValid;
            }
            isValid = holderBaseInfo.ValidateData(true);

            if (isValid == false)
            {
                tabIPInfo.SelectedTab = tiPolicyHolder;
                return isValid;
            }

            if (tiInsured.Visible && chkSameHolderAndInsured.Checked == false)
            {
                isValid = insuredBaseInfo.ValidateData(true) && isValid;

                if (ComboBoxUtil.Selected(cmbRelation) == false)
                {
                    MessageBoxHelper.ShowPrompt("与投保人关系是必填的");
                    isValid = false;
                }

                if (isValid == false)
                {
                    tabIPInfo.SelectedTab = tiInsured;
                    return isValid;
                }
            }
           

            if (tiBeneficiary.Visible)
            {
                grdBeneficiary.Enabled = false;
                grdBeneficiary.Enabled = true;

                foreach (DataGridViewRow row in grdBeneficiary.Rows)
                {
                    Customer c = row.DataBoundItem as Customer;
                    if (c != null)
                    {
                        isValid = ValidationHelper.ValidateRequiredField(row, "colCustomerName", "colRelationWithInsured") && isValid;
                    }
                }
                if (isValid == false)
                {
                    tabIPInfo.SelectedTab = tiBeneficiary;
                    return isValid;
                }
            }
            return isValid;
        }

        private void InsurancePolicyDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK
                && this.FormMode != SimpleCrm.FormMode.View
                && MessageBoxHelper.ShowYesNo("是否关闭保单窗体?") == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void tabIPInfo_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            cmbCustomerList.SelectedIndexChanged -= new EventHandler(cmbCustomerList_SelectedIndexChanged);
            cmbCustomerList.Enabled = false;
            if (tabIPInfo.SelectedTab == tiPolicyHolder)
            {
                cmbCustomerList.Enabled = true;
                UpdateCustomerListComboBox(holderBaseInfo);
            }
            else if (tiInsured.Visible && tabIPInfo.SelectedTab == tiInsured)
            {
                cmbCustomerList.Enabled = true;
                UpdateCustomerListComboBox(holderBaseInfo);
            }
            else if (tiBeneficiary.Visible && tabIPInfo.SelectedTab == tiBeneficiary)
            {
                cmbCustomerList.Enabled = true;
            }
            cmbCustomerList.SelectedIndexChanged += new EventHandler(cmbCustomerList_SelectedIndexChanged);
        }

        private void UpdateCustomerListComboBox(CustomerBaseInfoUC holderBaseInfo)
        {
            Customer customer = holderBaseInfo.Customer;
            if (customer == null || customer.CustomerId == null)
            {
                cmbCustomerList.SelectedItem = newTag;
            }
            else
            {
                cmbCustomerList.SelectedItem = customer;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = Convert.ToString(cmbCategory.SelectedValue);
            if (category == "Property")
            {
                tiInsured.Visible = false;
                tiBeneficiary.Visible = false;
                chkSameHolderAndInsured.Checked = false;
                chkSameHolderAndInsured.Enabled = false;
            }
            else
            {
                tiInsured.Visible = true;
                tiBeneficiary.Visible = true;
                chkSameHolderAndInsured.Enabled = true;
            }
        }

        private void chkSameHolderAndInsured_CheckedChanged(object sender, DevComponents.DotNetBar.CheckBoxChangeEventArgs e)
        {
            this.tcpInsured.Enabled = !chkSameHolderAndInsured.Checked;
        }

        private void grdBeneficiary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdBeneficiary.Columns[e.ColumnIndex].Name == "colDelete"
                && grdBeneficiary.Rows[e.RowIndex].DataBoundItem is Customer)
            {
                if (MessageBoxHelper.ShowYesNo("删除受益人吗？注意,已保存的客户资料是不会被删除的。") == System.Windows.Forms.DialogResult.Yes)
                {
                    grdBeneficiary.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

    }
}
