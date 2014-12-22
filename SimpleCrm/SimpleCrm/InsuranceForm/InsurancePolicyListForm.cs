using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Facade;
using SimpleCrm.DTO;
using SimpleCrm.Utils;
using SimpleCrm.Model;

namespace SimpleCrm.InsuranceForm
{
    public partial class InsurancePolicyListForm : SimpleCrm.BaseForm
    {
        public CustomerSearchResultDto CustomerDto { get; set; }
        public InsurancePolicyListForm()
        {
            InitializeComponent();
        }

        private void CustomerMainForm_Load(object sender, EventArgs e)
        {
            InitForm();
            SearchData();
        }

        private void InitForm()
        {
            ComboBoxUtil.BindLov(LovType.InsurancePolicyCategory, colCategory);
            ComboBoxUtil.BindLov(LovType.InsurancePolicyStatus, colStatus);

            this.Text = "保单列表 - " + this.CustomerDto.CustomerName;
            this.ribbonBarMergeContainer1.RibbonTabText = this.Text;
        }

        private void SearchData()
        {
            List<InsurancePolicyResultDto> searchResult = AppFacade.Facade.GetInsurancePolicyByCustomer(CustomerDto.CustomerId.Value);
            grdResult.DataSource = new SortableBindingList<InsurancePolicyResultDto>(searchResult);
        }

        private void grdResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var column = grdResult.Columns[e.ColumnIndex];
                var row = grdResult.Rows[e.RowIndex];
                InsurancePolicyResultDto dto = row.DataBoundItem as InsurancePolicyResultDto;
                if (dto == null)
                {
                    return;
                }
                long insurancePolicyId = dto.InsurancePolicyId.Value;

                if (column.Name == "colEdit")
                {
                    this.ShowMdiChildForm<InsurancePolicyDetailForm>(() =>
                        {
                            InsurancePolicyDetailForm form = new InsurancePolicyDetailForm();
                            form.FormMode = SimpleCrm.FormMode.Edit;
                            form.InsurancePolicyId = insurancePolicyId;
                            form.PrimaryCustomerId = GetPrimaryCustomerId();
                            return form;
                        }
                        , f => f.InsurancePolicyId == insurancePolicyId && f.FormMode == SimpleCrm.FormMode.Edit
                        , childform =>
                        {
                            if (childform.DialogResult == DialogResult.OK) { SearchData(); };
                        }
                      );
                }
                else if (column.Name == "colDelete")
                {
                    if (MessageBoxHelper.ShowYesNo(ErrorCode.DELETE_POLICY) == System.Windows.Forms.DialogResult.Yes)
                    {
                        AppFacade.Facade.DeleteInsurancePolicy(insurancePolicyId);
                    }
                }
                else if (column.Name == "colInsurancePolicyNo")
                {
                    this.ShowMdiChildForm<InsurancePolicyDetailForm>(() =>
                    {
                        InsurancePolicyDetailForm form = new InsurancePolicyDetailForm();
                        form.FormMode = SimpleCrm.FormMode.View;
                        form.InsurancePolicyId = insurancePolicyId;
                        form.PrimaryCustomerId = GetPrimaryCustomerId();
                        return form;
                    }
                        , f => f.InsurancePolicyId == insurancePolicyId && f.FormMode == SimpleCrm.FormMode.View
                    );
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private long GetPrimaryCustomerId()
        {
            return this.CustomerDto.CustomerId.Value;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.SearchData();
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMdiChildForm<InsurancePolicyDetailForm>(() =>
                    {
                        InsurancePolicyDetailForm form = new InsurancePolicyDetailForm();
                        form.FormMode = SimpleCrm.FormMode.Add;
                        form.PrimaryCustomerId = GetPrimaryCustomerId(); ;
                        return form;
                    }
                     , f => f.PrimaryCustomerId == GetPrimaryCustomerId() && f.FormMode == SimpleCrm.FormMode.Add
                    , childform =>
                    {
                        if (childform.DialogResult == DialogResult.OK) { SearchData(); };
                    }
                    );
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }
    }
}
