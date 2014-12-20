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
    public partial class UserAddForm : BaseForm
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public UserAddForm()
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

                if (superValidator.Validate() == false)
                {
                    return;
                }

                User saveUser = new User();
                saveUser.UserId = txtUserId.Text.Trim();
                saveUser.Password = PasswordUtil.Encrypt(txtPassword.Text);
                saveUser.UserName = saveUser.UserId;
                saveUser.Status = "Normal";
                //saveUser.RoleList = "Admin";
                saveUser.CreateTime = DateTime.Now;
                saveUser.UpdatedBy = "system";
                saveUser.UpdateTime = DateTime.Now;
                AppFacade.Facade.CreateUser(saveUser);

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
