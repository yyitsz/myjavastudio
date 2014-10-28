namespace SimpleCrm.CustomerForm
{
    partial class CustomerBaseDetailForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerBaseDetailForm));
            this.superValidator = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.customerBaseInfoUC = new SimpleCrm.CustomerForm.UserControls.CustomerBaseInfoUC();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.dataBindingCustomer = new SimpleCrm.Utils.DataBinding(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // superValidator
            // 
            this.superValidator.ContainerControl = this;
            this.superValidator.ErrorProvider = this.errorProvider;
            this.superValidator.Highlighter = this.highlighter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // highlighter
            // 
            this.highlighter.ContainerControl = this;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            this.requiredFieldValidator1.ValuePropertyName = "SelectedValue";
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "Your error message here.";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnClose);
            this.panelEx1.Controls.Add(this.btnSave);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 429);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(876, 34);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(724, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(634, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // customerBaseInfoUC
            // 
            this.customerBaseInfoUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerBaseInfoUC.Location = new System.Drawing.Point(0, 0);
            this.customerBaseInfoUC.Name = "customerBaseInfoUC";
            this.customerBaseInfoUC.Size = new System.Drawing.Size(876, 429);
            this.customerBaseInfoUC.TabIndex = 0;
            // 
            // tabItem4
            // 
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "家庭成员";
            // 
            // dataBindingCustomer
            // 
            this.dataBindingCustomer.DateTimeFormat = "yyyy-MM-dd";
            // 
            // CustomerBaseDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 463);
            this.Controls.Add(this.customerBaseInfoUC);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "CustomerBaseDetailForm";
            this.Text = "客户详细信息";
            this.Load += new System.EventHandler(this.CustomerDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Validator.SuperValidator superValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private UserControls.CustomerBaseInfoUC customerBaseInfoUC;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private Utils.DataBinding dataBindingCustomer;
    }
}