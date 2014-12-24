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
                    MessageBoxHelper.ShowPrompt("请输入旧密码和新密码.");
                    return;
                }

                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    MessageBoxHelper.ShowPrompt("新密码必须与确认新密码相同。");
                    return;
                }

                if (txtOldPassword.Text == txtNewPassword.Text)
                {
                    MessageBoxHelper.ShowPrompt("新密码不能与旧密码相同。");
                    return;
                }

                if (txtNewPassword.Text.Length < 6)
                {
                    MessageBoxHelper.ShowPrompt("密码长度不能小于6.");
                    return;
                }
                string userId = UserManager.UserProfile.UserId;
                String newPwd = this.txtNewPassword.Text;
                string oldPwd = this.txtOldPassword.Text;
                AppFacade.Facade.ChangePassword(userId, oldPwd, newPwd);
                MessageBoxHelper.ShowPrompt("密码修改成功。");
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
