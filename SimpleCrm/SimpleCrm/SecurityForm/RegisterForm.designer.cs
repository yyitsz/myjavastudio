using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
namespace SimpleCrm.Security
{
    partial class RegisterForm
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
            this.lblLicense = new DevComponents.DotNetBar.LabelX();
            this.btnRegister = new DevComponents.DotNetBar.ButtonX();
            this.btnTrial = new DevComponents.DotNetBar.ButtonX();
            this.txtLicense = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblMsg = new DevComponents.DotNetBar.LabelX();
            this.txtMachineCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            // 
            // 
            // 
            this.lblUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUserName.Location = new System.Drawing.Point(26, 12);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(66, 22);
            this.lblUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "»úÆ÷Âë";
            // 
            // btnCancelLogin
            // 
            this.btnCancelLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelLogin.Location = new System.Drawing.Point(254, 199);
            this.btnCancelLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelLogin.Name = "btnCancelLogin";
            this.btnCancelLogin.Size = new System.Drawing.Size(74, 28);
            this.btnCancelLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelLogin.TabIndex = 3;
            this.btnCancelLogin.Text = "ÍË³ö(&X)";
            this.btnCancelLogin.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            // 
            // 
            // 
            this.lblLicense.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLicense.Location = new System.Drawing.Point(26, 51);
            this.lblLicense.Margin = new System.Windows.Forms.Padding(2);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(44, 18);
            this.lblLicense.TabIndex = 9;
            this.lblLicense.Text = "ÊÚÈ¨Âë";
            // 
            // btnRegister
            // 
            this.btnRegister.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegister.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegister.Location = new System.Drawing.Point(64, 199);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(74, 28);
            this.btnRegister.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "×¢²á(&R)";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnTrial
            // 
            this.btnTrial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTrial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTrial.Location = new System.Drawing.Point(159, 199);
            this.btnTrial.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Size = new System.Drawing.Size(74, 28);
            this.btnTrial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTrial.TabIndex = 2;
            this.btnTrial.Text = "ÊÔÓÃ(&T)";
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // txtLicense
            // 
            // 
            // 
            // 
            this.txtLicense.Border.Class = "TextBoxBorder";
            this.txtLicense.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLicense.Location = new System.Drawing.Point(114, 51);
            this.txtLicense.MaxLength = 500;
            this.txtLicense.Multiline = true;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.PreventEnterBeep = true;
            this.txtLicense.Size = new System.Drawing.Size(239, 109);
            this.txtLicense.TabIndex = 0;
            // 
            // lblMsg
            // 
            // 
            // 
            // 
            this.lblMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(36, 174);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(278, 20);
            this.lblMsg.TabIndex = 12;
            this.lblMsg.Text = "   ";
            // 
            // txtMachineCode
            // 
            // 
            // 
            // 
            this.txtMachineCode.Border.Class = "TextBoxBorder";
            this.txtMachineCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMachineCode.Location = new System.Drawing.Point(114, 12);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.PreventEnterBeep = true;
            this.txtMachineCode.ReadOnly = true;
            this.txtMachineCode.Size = new System.Drawing.Size(239, 21);
            this.txtMachineCode.TabIndex = 13;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 255);
            this.Controls.Add(this.txtMachineCode);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.btnTrial);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnCancelLogin);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.btnRegister);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "×¢²á";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelX lblUserName;
        private LabelX lblLicense;
        private ButtonX btnRegister;
        private ButtonX btnCancelLogin;
        private ButtonX btnTrial;
        private TextBoxX txtLicense;
        private LabelX lblMsg;
        private TextBoxX txtMachineCode;
    }
}

