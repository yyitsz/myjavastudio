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
using SimpleCrm.SecurityForm;

namespace SimpleCrm
{
    public partial class MainForm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel == false
                && e.CloseReason == CloseReason.UserClosing
                && MessageBoxHelper.ShowYesNo(ErrorCode.EXIT_APP) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void mnuSysConfig_Click(object sender, EventArgs e)
        {
            FormHelper.ShowDialogForm<OptionsForm>();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            // tssUserId.Text = "User Id: " + UserManager.UserProfile.UserId;
            //   ttsUserName.Text = "User Name: " + UserManager.UserProfile.UserName;
#if PRD
            LicenseInfo licenseInfo = RegHelper.CheckLicenseFromRegister();
            if (licenseInfo.Status != 1)
            {
                DialogResult result = FormHelper.ShowDialogForm<RegisterForm>(f =>
                   {
                       f.LicenseInfo = licenseInfo;
                       f.FormType = RegisterForm.RegisterFormType.LoggingOn;
                   });
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
            if (!AppFacade.Facade.ExistAnyUser())
            {
                DialogResult result = FormHelper.ShowDialogForm<UserAddForm>();
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
#endif
            if (LoginForm.Login() == System.Windows.Forms.DialogResult.OK)
            {
                AppFacade.Facade.InitSystem();
            }
            else
            {
                Application.Exit();
            }
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

        private void cmdRegister_Executed(object sender, EventArgs e)
        {
            LicenseInfo licenseInfo = RegHelper.CheckLicenseFromRegister();
            DialogResult result = FormHelper.ShowDialogForm<RegisterForm>(f =>
            {
                f.LicenseInfo = licenseInfo;
                f.FormType = RegisterForm.RegisterFormType.LoggedOn;
            });
        }

        private void cmdChangePassword_Executed(object sender, EventArgs e)
        {
            FormHelper.ShowDialogForm<ChangePasswordForm>();
        }

        private void btnAbount_Click(object sender, EventArgs e)
        {
            FormHelper.ShowDialogForm<AboutForm>();
        }
    }
}