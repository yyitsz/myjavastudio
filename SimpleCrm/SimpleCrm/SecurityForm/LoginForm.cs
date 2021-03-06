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
using SimpleCrm.Model;
using SimpleCrm.Facade;


namespace SimpleCrm.Security
{
    /// <summary>
    /// Login form
    /// </summary>
    public partial class LoginForm : BaseForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {

            InitializeComponent();

        }

        /// <summary>
        /// Handles the Load event of the FLoginForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnOkLogin;
            txtUserName.Select();
        }

       

        /// <summary>
        /// Handles the Click event of the btnOKLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOKLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtUserName.Text.Trim().Length == 0 || txtPassword.Text.Length == 0)
                {
                    MessageBoxHelper.ShowPrompt("请输入用户名和密码！");
                    return;

                }

                string userId = this.txtUserName.Text.Trim();
                string plainPwd = this.txtPassword.Text;
                UserProfile profile = AppFacade.Facade.Authenticate(userId, plainPwd);
                UserManager.UserProfile.UserId = profile.UserId;
                UserManager.UserProfile.RoleList = profile.RoleList;
                UserManager.UserProfile.UserName = profile.UserName;
                RoleExtender.UserProfile = UserManager.UserProfile;
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
            if (MessageBoxHelper.ShowYesNo(ErrorCode.EXIT_APP) == System.Windows.Forms.DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing
                && ( this.DialogResult != System.Windows.Forms.DialogResult.OK
                && this.DialogResult != System.Windows.Forms.DialogResult.Cancel))
            {
                e.Cancel = true;
            }
        }

        public static DialogResult Login()
        {
            LoginForm form = new LoginForm();
            return form.ShowDialog();
        }
    }


}
