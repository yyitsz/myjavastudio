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
    public partial class RegisterForm : BaseForm
    {
        public enum RegisterFormType { LoggingOn, LoggedOn }
        public RegisterFormType FormType { get; set; }

        public LicenseInfo LicenseInfo { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FLoginForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txtMachineCode.Text = RegHelper.GetCpuInfo();

            if (LicenseInfo != null)
            {
                //trial user
                if (LicenseInfo.Status == 0)
                {
                    btnTrial.Visible = false;
                    //lblMsg.Text = String.Format("试用用户，过期日{0}。", LicenseInfo.ExpireDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                }
                else if (LicenseInfo.Status == 1 || LicenseInfo.Status == 2)
                {
                    lblMsg.Text = String.Format("授权给{0}使用，到期日{1}。", LicenseInfo.CustomerName
                        , LicenseInfo.ExpireDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                }
                else if (LicenseInfo.Status == 3)
                {
                    lblMsg.Text = "无效授权码";
                }
                else
                {
                    btnTrial.Visible = false;
                }
            }
            else
            {
                btnTrial.Visible = false;
            }

            if (FormType == RegisterFormType.LoggingOn)
            {
            }

            else
            {
                btnTrial.Visible = false;
            }

        }

        /// <summary>
        /// Handles the Click event of the btnOKLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtMachineCode.Text.Trim().Length == 0
                    || txtLicense.Text.Trim().Length == 0)
                {
                    MessageBoxHelper.ShowPrompt("请输入授权码！");
                    return;

                }

                LicenseInfo licenseInfo = RegHelper.CheckLicense(txtLicense.Text.Trim());
                if (licenseInfo.Status == 1)
                {
                    MessageBoxHelper.ShowPrompt(ErrorCode.VALID_LICENSE);
                    RegHelper.SaveLicense(txtLicense.Text.Trim());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBoxHelper.ShowPrompt(ErrorCode.INVALID_LICENSE);
                }

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

        private void btnTrial_Click(object sender, EventArgs e)
        {
            RegHelper.SaveTrialDate();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }


}
