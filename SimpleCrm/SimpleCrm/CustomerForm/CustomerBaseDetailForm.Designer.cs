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
            this.cmbRelation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.grpPrimaryInfo = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtPrimaryCustomerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.customerBaseInfoUC = new SimpleCrm.CustomerForm.UserControls.CustomerBaseInfoUC();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.dataBindingCustomer = new SimpleCrm.Utils.DataBinding(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpPrimaryInfo.SuspendLayout();
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
            // cmbRelation
            // 
            this.cmbRelation.DisplayMember = "Text";
            this.cmbRelation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRelation.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.cmbRelation, true);
            this.cmbRelation.ItemHeight = 15;
            this.cmbRelation.Location = new System.Drawing.Point(529, 7);
            this.cmbRelation.Name = "cmbRelation";
            this.cmbRelation.Size = new System.Drawing.Size(121, 21);
            this.cmbRelation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbRelation.TabIndex = 23;
            this.superValidator.SetValidator1(this.cmbRelation, this.requiredFieldValidator1);
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
            // grpPrimaryInfo
            // 
            this.grpPrimaryInfo.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpPrimaryInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grpPrimaryInfo.Controls.Add(this.cmbRelation);
            this.grpPrimaryInfo.Controls.Add(this.labelX2);
            this.grpPrimaryInfo.Controls.Add(this.txtPrimaryCustomerName);
            this.grpPrimaryInfo.Controls.Add(this.labelX1);
            this.grpPrimaryInfo.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPrimaryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPrimaryInfo.Location = new System.Drawing.Point(0, 0);
            this.grpPrimaryInfo.Name = "grpPrimaryInfo";
            this.grpPrimaryInfo.Size = new System.Drawing.Size(876, 41);
            // 
            // 
            // 
            this.grpPrimaryInfo.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grpPrimaryInfo.Style.BackColorGradientAngle = 90;
            this.grpPrimaryInfo.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grpPrimaryInfo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPrimaryInfo.Style.BorderBottomWidth = 1;
            this.grpPrimaryInfo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grpPrimaryInfo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPrimaryInfo.Style.BorderLeftWidth = 1;
            this.grpPrimaryInfo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPrimaryInfo.Style.BorderRightWidth = 1;
            this.grpPrimaryInfo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPrimaryInfo.Style.BorderTopWidth = 1;
            this.grpPrimaryInfo.Style.CornerDiameter = 4;
            this.grpPrimaryInfo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpPrimaryInfo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpPrimaryInfo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpPrimaryInfo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpPrimaryInfo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpPrimaryInfo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpPrimaryInfo.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(428, 7);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 21);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "关系";
            // 
            // txtPrimaryCustomerName
            // 
            // 
            // 
            // 
            this.txtPrimaryCustomerName.Border.Class = "TextBoxBorder";
            this.txtPrimaryCustomerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrimaryCustomerName.Location = new System.Drawing.Point(131, 7);
            this.txtPrimaryCustomerName.Name = "txtPrimaryCustomerName";
            this.txtPrimaryCustomerName.PreventEnterBeep = true;
            this.txtPrimaryCustomerName.ReadOnly = true;
            this.txtPrimaryCustomerName.Size = new System.Drawing.Size(120, 21);
            this.txtPrimaryCustomerName.TabIndex = 18;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(9, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(96, 21);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 17;
            this.labelX1.Text = "主关联客户姓名";
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
            this.customerBaseInfoUC.Location = new System.Drawing.Point(0, 41);
            this.customerBaseInfoUC.Name = "customerBaseInfoUC";
            this.customerBaseInfoUC.Size = new System.Drawing.Size(876, 388);
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
            this.Controls.Add(this.grpPrimaryInfo);
            this.Name = "CustomerBaseDetailForm";
            this.Text = "客户详细信息";
            this.Load += new System.EventHandler(this.CustomerDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpPrimaryInfo.ResumeLayout(false);
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
        private DevComponents.DotNetBar.Controls.GroupPanel grpPrimaryInfo;
        private UserControls.CustomerBaseInfoUC customerBaseInfoUC;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPrimaryCustomerName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbRelation;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private Utils.DataBinding dataBindingCustomer;
    }
}