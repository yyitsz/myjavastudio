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
        private void FLoginForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnOkLogin;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs"></see> that contains the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                return;
            }

            base.OnKeyPress(e);
        }

        /// <summary>
        /// Handles the Click event of the btnOKLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOKLogin_Click(object sender, EventArgs e)
        {
            Cursor cursor = this.Cursor;
            try
            {
                if (txtUserName.Text.Trim().Length == 0 || txtPassword.Text.Length == 0)
                {
                    MessageBoxHelper.ShowPrompt("Please input user id and password");
                    return;

                }

                this.Cursor = Cursors.WaitCursor;
                string userId = this.txtUserName.Text.Trim();
                string plainPwd = this.txtPassword.Text;
                UserProfile profile = AppFacade.Facade.Authenticate(userId, plainPwd);
                UserManager.UserProfile.UserId = profile.UserId;
                UserManager.UserProfile.RoleList = profile.RoleList;
                UserManager.UserProfile.UserName = profile.UserName;
                RoleExtender.UserProfile = UserManager.UserProfile;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
            finally
            {
                this.Cursor = cursor;
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
