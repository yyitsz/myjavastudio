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
using SimpleCrm.DTO;
using SimpleCrm.Manager;

namespace SimpleCrm.CustomerForm
{
    public partial class FollowUpRecordForm : BaseForm
    {
        public CustomerSearchResultDto Customer { get; set; }
        private BindingList<FollowUpRecord> followUpRecords;
        private FollowUpRecord currentRecord;

        public FollowUpRecordForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (superValidator.Validate())
                {
                    FollowUpRecord record = currentRecord;
                    if (record == null)
                    {
                        record = new FollowUpRecord();
                        record.CustomerId = Customer.CustomerId;
                        record.InputDate = DateTime.Now.Date;
                        record.InputtedBy = UserManager.UserProfile.UserId;
                        record.FollowedBy = UserManager.UserProfile.UserId;
                    }
                    dataBindingFollow.MapToObject(record);
                    AppFacade.Facade.SaveFollowUpRecord(record);
                    if (currentRecord == null)
                    {
                        this.followUpRecords.Insert(0, record);
                    }
                    UpdateIntentPhase();                 
                    InitAddPart();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private void UpdateIntentPhase()
        {
            if (this.followUpRecords != null && this.followUpRecords.Count > 0)
            {
                FollowUpRecord record = this.followUpRecords[0];
                if (Customer.IntentPhase != record.IntentPhase)
                {
                    Customer.IntentPhase = record.IntentPhase;
                    AppFacade.Facade.UpdateIntentPhase(record.CustomerId.Value, record.IntentPhase);
                }
            }
        }

        private void FollowUpRecordForm_Load(object sender, EventArgs e)
        {
            InitForm();
            BindData();
            InitAddPart();
        }

        private void InitAddPart()
        {
            dtFollowDate.Value = DateTime.Now.Date;
            dtNextFollowDate.ValueObject = null;
            txtContent.Text = "";
            cmbIntentPhase.SelectedValue = Customer.IntentPhase ?? "";
            cmbIntentPhaseCustomer.SelectedValue = Customer.IntentPhase ?? "";
            currentRecord = null;
        }
        private void BindData()
        {
            dataBindingCustomer.MapToControl(Customer);
            var list = AppFacade.Facade.GetFollowUpRecordByCustomer(Customer.CustomerId.Value);
            list.Sort(new FollowUpRecordDateComparrer());
            followUpRecords = new BindingList<FollowUpRecord>(list);           
            this.grdResult.DataSource = followUpRecords;

            this.Text = "跟进记录 - " + this.Customer.CustomerName;
        }

        private void InitForm()
        {
            ComboBoxUtil.BindLov(LovType.CustomerClass, cmbCustomerClass);
            ComboBoxUtil.BindLov(LovType.IntentPhase, cmbIntentPhaseCustomer);
            ComboBoxUtil.BindLov(LovType.CustomerStatus, cmbCustomerStatus);

            ComboBoxUtil.BindLov(LovType.IntentPhase, cmbIntentPhase);
            ComboBoxUtil.BindLov(LovType.IntentPhase, colIntentPhase);

        }

        private void grdResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var column = grdResult.Columns[e.ColumnIndex];
                FollowUpRecord record = grdResult.Rows[e.RowIndex].DataBoundItem as FollowUpRecord;
                if (record != null)
                {
                    if (column.Name == "colEdit")
                    {
                        currentRecord = record;
                        dataBindingFollow.MapToControl(currentRecord);
                    }
                    else if (column.Name == "colDelete")
                    {
                        if (MessageBoxHelper.ShowYesNo("确定删除?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            AppFacade.Facade.DeleteFollowUpRecord(record);
                            //this.followUpRecords.Remove(record);
                            grdResult.Rows.RemoveAt(e.RowIndex);
                            UpdateIntentPhase();
                            InitAddPart();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitAddPart();
        }

        private void superValidator_CustomValidatorValidateValue(object sender, DevComponents.DotNetBar.Validator.ValidateValueEventArgs e)
        {
            if (e.ControlToValidate == dtNextFollowDate)
            {
                if (dtNextFollowDate.ValueObject == null || dtFollowDate.ValueObject == null)
                {
                    e.IsValid = true;
                    return;
                }

                e.IsValid = dtNextFollowDate.Value > dtFollowDate.Value;
            }
        }


    }
}
