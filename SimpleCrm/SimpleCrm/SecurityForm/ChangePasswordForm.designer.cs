using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;
namespace SimpleCrm.Security
{
    partial class ChangePasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUserName = new DevComponents.DotNetBar.LabelX();
            this.txtNewPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancelLogin = new DevComponents.DotNetBar.ButtonX();
            this.lblPassword = new DevComponents.DotNetBar.LabelX();
            this.btnOkLogin = new DevComponents.DotNetBar.ButtonX();
            this.txtConfirmPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblSlogon = new DevComponents.DotNetBar.LabelX();
            this.label1 = new DevComponents.DotNetBar.LabelX();
            this.txtOldPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            // 
            // 
            // 
            this.lblUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUserName.Location = new System.Drawing.Point(13, 43);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(82, 16);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "New Password";
            // 
            // txtNewPassword
            // 
            // 
            // 
            // 
            this.txtNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNewPassword.Location = new System.Drawing.Point(114, 42);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(160, 15);
            this.txtNewPassword.TabIndex = 1;
            // 
            // btnCancelLogin
            // 
            this.btnCancelLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelLogin.Location = new System.Drawing.Point(224, 128);
            this.btnCancelLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelLogin.Name = "btnCancelLogin";
            this.btnCancelLogin.Size = new System.Drawing.Size(74, 30);
            this.btnCancelLogin.TabIndex = 2;
            this.btnCancelLogin.Text = "Cance&l";
            this.btnCancelLogin.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            // 
            // 
            // 
            this.lblPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPassword.Location = new System.Drawing.Point(13, 70);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(99, 16);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Confirm Password";
            // 
            // btnOkLogin
            // 
            this.btnOkLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOkLogin.Location = new System.Drawing.Point(127, 128);
            this.btnOkLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnOkLogin.Name = "btnOkLogin";
            this.btnOkLogin.Size = new System.Drawing.Size(74, 30);
            this.btnOkLogin.TabIndex = 1;
            this.btnOkLogin.Text = "&Confirm";
            this.btnOkLogin.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtConfirmPassword
            // 
            // 
            // 
            // 
            this.txtConfirmPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConfirmPassword.Location = new System.Drawing.Point(114, 68);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(160, 15);
            this.txtConfirmPassword.TabIndex = 2;
            // 
            // lblSlogon
            // 
            // 
            // 
            // 
            this.lblSlogon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSlogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlogon.Location = new System.Drawing.Point(13, 67);
            this.lblSlogon.Margin = new System.Windows.Forms.Padding(2);
            this.lblSlogon.Name = "lblSlogon";
            this.lblSlogon.Size = new System.Drawing.Size(326, 23);
            this.lblSlogon.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            // 
            // 
            // 
            this.label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Old Password";
            // 
            // txtOldPassword
            // 
            // 
            // 
            // 
            this.txtOldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOldPassword.Location = new System.Drawing.Point(114, 18);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtOldPassword.MaxLength = 20;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(160, 14);
            this.txtOldPassword.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOldPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtConfirmPassword);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.txtNewPassword);
            this.groupBox1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 114);
            // 
            // 
            // 
            this.groupBox1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupBox1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupBox1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupBox1.TabIndex = 0;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 172);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelLogin);
            this.Controls.Add(this.btnOkLogin);
            this.Controls.Add(this.lblSlogon);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelX lblUserName;
        private TextBoxX txtNewPassword;
        private LabelX lblPassword;
        private TextBoxX txtConfirmPassword;
        private ButtonX btnOkLogin;
        private ButtonX btnCancelLogin;
        private LabelX lblSlogon;
        private LabelX label1;
        private TextBoxX txtOldPassword;
        private GroupPanel groupBox1;
    }
}
