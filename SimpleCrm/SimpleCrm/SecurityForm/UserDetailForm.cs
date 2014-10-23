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
using System.Linq;
using SimpleCrm.Facade;

namespace SimpleCrm.Security
{
    /// <summary>
    /// Login form
    /// </summary>
    public partial class UserDetailForm : BaseForm
    {
        public User User { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public UserDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FLoginForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UserDetailForm_Load(object sender, EventArgs e)
        {
            if (this.User != null)
            {
                txtUserId.Text = this.User.UserId;
                txtUserName.Text = this.User.UserName;
                txtPassword.Text = PasswordUtil.Decrypt(this.User.Password);
                String[] roles = User.Roles;
                foreach (String role in roles)
                {
                    clbRole.SetItemChecked(clbRole.Items.IndexOf(role), true);
                }
                cmbStatus.SelectedItem = this.User.Status;

                txtUserId.ReadOnly = true;

                //if (this.User.UserId == "admin")
                //{
                //    cmbStatus.Enabled = false;
                //}
            }
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
                //if (txtUserId.Text.Trim().Length == 0
                //    || txtUserName.Text.Trim().Length == 0
                //   // || clbRole.CheckedItems.Count == 0
                //    || cmbStatus.SelectedItem == null
                //    || txtPassword.Text.Length == 0)
                //{
                //    MessageBoxHelper.ShowPrompt("Please input all required fields.");
                //    return;
                //}

                //if (txtPassword.Text.Length < 6)
                //{
                //    MessageBoxHelper.ShowPrompt("The length of password must not be less than 6.");
                //    return;
                //}

                if (superValidator.Validate() == false)
                {
                    return;
                }

                User saveUser = this.User;
                if (saveUser == null)
                {
                    saveUser = new User();
                }
                saveUser.UserId = txtUserId.Text.Trim();
                saveUser.Password = PasswordUtil.Encrypt(txtPassword.Text);
                saveUser.UserName = txtUserName.Text.Trim();
                saveUser.Roles = clbRole.CheckedItems.Cast<String>().ToArray();
                saveUser.Status = cmbStatus.SelectedItem.ToString();
                if (this.User == null)
                {
                    AppFacade.Facade.CreateUser(saveUser);
                }
                else
                {
                    AppFacade.Facade.UpdateUser(saveUser);
                }
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
