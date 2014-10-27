using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SimpleCrm.Utils;
using SimpleCrm.Security;
using SimpleCrm.MasterForm;
using SimpleCrm.Manager;
using SimpleCrm.Facade;
using SimpleCrm.ScheduleForm;
using SimpleCrm.PendingItemForm;

namespace SimpleCrm
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }




        private void AutopayMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel == false
                && MessageBoxHelper.ShowYesNo("ÍË³öÏµÍ³Âð?") == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void mnuSysConfig_Click(object sender, EventArgs e)
        {
            FormHelper.ShowDialogForm<OptionsForm>();
        }


        private void AutopayMainForm_Load(object sender, EventArgs e)
        {
            // tssUserId.Text = "User Id: " + UserManager.UserProfile.UserId;
            //   ttsUserName.Text = "User Name: " + UserManager.UserProfile.UserName;

        }

        private void mnuChangePassword_Click(object sender, EventArgs e)
        {
            FormHelper.ShowDialogForm<ChangePasswordForm>();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdCustomerManagement_Executed(object sender, EventArgs e)
        {
            this.ShowMdiChildForm<CustomerForm.CustomerMainForm>();
        }

        private void cmdUserMain_Executed(object sender, EventArgs e)
        {
            this.ShowMdiChildForm<UserMainForm>();
        }

        private void cmdLovMain_Executed(object sender, EventArgs e)
        {
            this.ShowMdiChildForm<LovMainForm>();
        }

        private void cmbAddCustomer_Executed(object sender, EventArgs e)
        {
            this.ShowMdiChildForm<CustomerForm.CustomerDetailForm>();
        }

        private void cmdScheduleMain_Executed(object sender, EventArgs e)
        {
            this.ShowMdiChildForm<ScheduleMainForm>();
        }

        private void btnBirthdayPendingItem_Click(object sender, EventArgs e)
        {
            this.ShowMdiChildForm<PendingItemForm.PendingItemListForm>(
                () =>
                {
                    PendingItemListForm form = new PendingItemListForm();
                    form.PendingItemCategory = Model.PendingItemCategory.Birthday;
                    return form;
                }
                , f => f.PendingItemCategory == Model.PendingItemCategory.Birthday
                );
        }

        private void btnRenewalPremium_Click(object sender, EventArgs e)
        {
            this.ShowMdiChildForm<PendingItemForm.PendingItemListForm>(
                () =>
                {
                    PendingItemListForm form = new PendingItemListForm();
                    form.PendingItemCategory = Model.PendingItemCategory.RenewalPremium;
                    return form;
                }
                , f => f.PendingItemCategory == Model.PendingItemCategory.RenewalPremium
                );
        }
    }
}