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
            this.btnCancelLogin = new DevComponents.DotNetBar.ButtonX();
            this.lblPassword = new DevComponents.DotNetBar.LabelX();
            this.btnOkLogin = new DevComponents.DotNetBar.ButtonX();
            this.lblSlogon = new DevComponents.DotNetBar.LabelX();
            this.label1 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtOldPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNewPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtConfirmPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
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
            this.lblUserName.Size = new System.Drawing.Size(44, 16);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "新密码";
            // 
            // btnCancelLogin
            // 
            this.btnCancelLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelLogin.Location = new System.Drawing.Point(346, 131);
            this.btnCancelLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelLogin.Name = "btnCancelLogin";
            this.btnCancelLogin.Size = new System.Drawing.Size(74, 30);
            this.btnCancelLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelLogin.TabIndex = 2;
            this.btnCancelLogin.Text = "取消(&L)";
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
            this.lblPassword.Size = new System.Drawing.Size(68, 16);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "确认新密码";
            // 
            // btnOkLogin
            // 
            this.btnOkLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOkLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOkLogin.Location = new System.Drawing.Point(249, 131);
            this.btnOkLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnOkLogin.Name = "btnOkLogin";
            this.btnOkLogin.Size = new System.Drawing.Size(74, 30);
            this.btnOkLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOkLogin.TabIndex = 1;
            this.btnOkLogin.Text = "确认(C)";
            this.btnOkLogin.Click += new System.EventHandler(this.btnConfirm_Click);
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
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "旧密码";
            // 
            // groupBox1
            // 
            this.groupBox1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupBox1.Controls.Add(this.txtConfirmPassword);
            this.groupBox1.Controls.Add(this.txtNewPassword);
            this.groupBox1.Controls.Add(this.txtOldPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblUserName);
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
            // txtOldPassword
            // 
            // 
            // 
            // 
            this.txtOldPassword.Border.Class = "TextBoxBorder";
            this.txtOldPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOldPassword.Location = new System.Drawing.Point(114, 12);
            this.txtOldPassword.MaxLength = 20;
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.PreventEnterBeep = true;
            this.txtOldPassword.Size = new System.Drawing.Size(160, 20);
            this.txtOldPassword.TabIndex = 0;
            // 
            // txtNewPassword
            // 
            // 
            // 
            // 
            this.txtNewPassword.Border.Class = "TextBoxBorder";
            this.txtNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNewPassword.Location = new System.Drawing.Point(114, 38);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.PreventEnterBeep = true;
            this.txtNewPassword.Size = new System.Drawing.Size(160, 21);
            this.txtNewPassword.TabIndex = 18;
            // 
            // txtConfirmPassword
            // 
            // 
            // 
            // 
            this.txtConfirmPassword.Border.Class = "TextBoxBorder";
            this.txtConfirmPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConfirmPassword.Location = new System.Drawing.Point(114, 65);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.PreventEnterBeep = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(160, 21);
            this.txtConfirmPassword.TabIndex = 19;
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
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.ChangePasswordForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelX lblUserName;
        private LabelX lblPassword;
        private ButtonX btnOkLogin;
        private ButtonX btnCancelLogin;
        private LabelX lblSlogon;
        private LabelX label1;
        private GroupPanel groupBox1;
        private TextBoxX txtOldPassword;
        private TextBoxX txtConfirmPassword;
        private TextBoxX txtNewPassword;
    }
}

