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
    public partial class CustomerPickListForm : SimpleCrm.BaseForm
    {
        public CustomerSearchResultDto CustomerDto { get; set; }

        public CustomerPickListForm()
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

            BaseSearchResultDto<CustomerSearchResultDto> searchResult = AppFacade.Facade.SearchCustomer(param);
            if (searchResult.Results != null)
            {
                grdResult.DataSource = searchResult.Results;
            }
        }

      

        private void grdResult_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CustomerSearchResultDto dto = grdResult.Rows[e.RowIndex].DataBoundItem as CustomerSearchResultDto;
            if (dto != null)
            {
                this.CustomerDto = dto;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
