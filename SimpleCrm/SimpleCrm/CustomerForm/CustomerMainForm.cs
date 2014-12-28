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
using SimpleCrm.InsuranceForm;

namespace SimpleCrm.CustomerForm
{
    public partial class CustomerMainForm : SimpleCrm.BaseForm
    {
        public CustomerMainForm()
        {
            InitializeComponent();
        }

        private void CustomerMainForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void InitForm()
        {
            ComboBoxUtil.BindLov(LovType.CustomerClass, cmbCustomerClass);
            ComboBoxUtil.BindLov(LovType.CustomerSource, cmbCustomerSource);
            ComboBoxUtil.BindLov(LovType.IntentPhase, cmbIntentPhase);
            ComboBoxUtil.BindLov(LovType.CustomerStatus, cmbCustomerStatus);
            ComboBoxUtil.BindLov(LovType.ContactType, cmbContactType);

            ComboBoxUtil.BindLov(LovType.CustomerClass, colCustomerClass);
            ComboBoxUtil.BindLov(LovType.CustomerSource, colCustomerSource);
            ComboBoxUtil.BindLov(LovType.IntentPhase, colIntentPhase);
            ComboBoxUtil.BindLov(LovType.CustomerStatus, colStatus);

            ComboBoxUtil.BindEnumType(typeof(GenderType), colGender);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // pcCustomer.CurrentPage = 1;
                SearchData();
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private void SearchData()
        {
            CustomerSearchParamDto param = new CustomerSearchParamDto();
            dataBindingParam.MapToObject(param);
            param.PageSize = pcCustomer.PageSize;
            param.StartPage = pcCustomer.CurrentPage; ;

            BaseSearchResultDto<CustomerSearchResultDto> searchResult = AppFacade.Facade.SearchCustomer(param);
            if (searchResult.Results != null)
            {
                grdResult.DataSource = new SortableBindingList<CustomerSearchResultDto>(searchResult.Results);
            }
            if (searchResult.TotalRecord == null)
            {
                pcCustomer.TotalRecords = searchResult.Results.Count;
            }
            else
            {
                pcCustomer.TotalRecords = searchResult.TotalRecord.Value;
            }
        }

        private void grdResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var column = grdResult.Columns[e.ColumnIndex];
            var row = grdResult.Rows[e.RowIndex];
            CustomerSearchResultDto dto = row.DataBoundItem as CustomerSearchResultDto;
            if (dto == null)
            {
                return;
            }
            long customerId = dto.CustomerId.Value;
            if (column.Name == "colEdit")
            {
                this.ShowMdiChildForm<CustomerDetailForm>(() =>
                    {
                        CustomerDetailForm form = new CustomerDetailForm();
                        form.FormMode = SimpleCrm.FormMode.Edit;
                        form.CustomerId = customerId;
                        return form;
                    }
                    , f => f.CustomerId == customerId && f.FormMode == SimpleCrm.FormMode.Edit
                   , f =>
                   {
                       if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                       {
                           SearchData();
                       }
                   }
                  );
            }
            else if (column.Name == "colDelete")
            {
                if (MessageBoxHelper.ShowYesNo(ErrorCode.DELETE_CUSTOMER) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (AppFacade.Facade.CanDeleteCustomer(dto.CustomerId.Value) == false)
                    {
                        MessageBoxHelper.ShowPrompt(ErrorCode.CAN_NOT_DEL_CUSTOMER);
                        return;
                    }
                    AppFacade.Facade.DeleteCustomer(dto.CustomerId.Value);
                    grdResult.Rows.Remove(row);
                }
            }
            else if (column.Name == "colIP")
            {
                this.ShowMdiChildForm<InsurancePolicyListForm>(() =>
                    {
                        InsurancePolicyListForm form = new InsurancePolicyListForm();
                        form.CustomerDto = dto;
                        return form;
                    }
                   , f => (f.CustomerDto.CustomerId.Value == dto.CustomerId.Value)
                 );
            }
            else if (column.Name == "colCustomerName")
            {
                this.ShowNonModalForm<CustomerDetailForm>(() =>
                {
                    CustomerDetailForm form = new CustomerDetailForm();
                    form.FormMode = SimpleCrm.FormMode.View;
                    form.CustomerId = customerId;
                    return form;
                }
                   , f => f.CustomerId == customerId && f.FormMode == SimpleCrm.FormMode.View
                 );
            }
            else if (column.Name == "colFollow")
            {
                this.ShowNonModalForm<FollowUpRecordForm>(() =>
                    {
                        FollowUpRecordForm form = new FollowUpRecordForm();
                        form.FormMode = SimpleCrm.FormMode.Edit;
                        form.CustomerId = customerId;
                        return form;
                    }
                    , f => f.CustomerId == customerId && f.FormMode == SimpleCrm.FormMode.Edit
                  );
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            this.dataBindingParam.ClearControlValue();
            this.grdResult.DataSource = new BindingList<CustomerSearchResultDto>();
        }

        private void pcCustomer_ScrollPage_1(object sender, PageControlArgs e)
        {
            SearchData();
        }
    }
}
