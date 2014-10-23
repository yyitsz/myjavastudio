using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using SimpleCrm.Utils;
using SimpleCrm.Manager;
using SimpleCrm.Facade;


namespace SimpleCrm.Security
{
    /// <summary>
    /// Login form
    /// </summary>
    public partial class ChangePasswordForm : BaseForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FLoginForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnOKLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPassword.Text.Length == 0
                    || txtConfirmPassword.Text.Length == 0
                    || txtOldPassword.Text.Length == 0)
                {
                    MessageBoxHelper.ShowPrompt("Please input old password and new password.");
                    return;
                }

                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    MessageBoxHelper.ShowPrompt("New Password and Confirm Password must be same.");
                    return;
                }

                if (txtOldPassword.Text == txtNewPassword.Text)
                {
                    MessageBoxHelper.ShowPrompt("New Password can not be same to Old Password.");
                    return;
                }

                if (txtNewPassword.Text.Length < 6)
                {
                    MessageBoxHelper.ShowPrompt("The length of New Password must not be less than 6.");
                    return;
                }
                string userId = UserManager.UserProfile.UserId;
                String newPwd = this.txtNewPassword.Text;
                string oldPwd = this.txtOldPassword.Text;
                AppFacade.Facade.ChangePassword(userId, oldPwd, newPwd);
                MessageBoxHelper.ShowPrompt("Change password successful.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }

        }
        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }


}
