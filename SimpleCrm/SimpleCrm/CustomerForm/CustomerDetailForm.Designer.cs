namespace SimpleCrm.CustomerForm
{
    partial class CustomerDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDetailForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.superValidator = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.cmbCustomerStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textBoxX6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbCustomerSource = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbCustomerClass = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbIntentPhase = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tabCustomer = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.grdFamily = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colEdit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRelation = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colIdType = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.idCardNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.birthdayDataGridViewTextBoxColumn = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.houseInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familyInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incomingInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otherInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerClassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intentPhaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.introducerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.btnSelectCustomer = new DevComponents.DotNetBar.ButtonX();
            this.tiFamily = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.customerBaseInfoUC = new SimpleCrm.CustomerForm.UserControls.CustomerBaseInfoUC();
            this.tiBaseInfo = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBoxX4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tiOther = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tiAsset = new DevComponents.DotNetBar.TabItem(this.components);
            this.dataBindingCustomer = new SimpleCrm.Utils.DataBinding(this.components);
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomer)).BeginInit();
            this.tabCustomer.SuspendLayout();
            this.tabControlPanel5.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFamily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCustomer)).BeginInit();
            this.ribbonBarMergeContainer1.SuspendLayout();
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
            // cmbCustomerStatus
            // 
            this.cmbCustomerStatus.DisplayMember = "Text";
            this.cmbCustomerStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingCustomer.SetFormatString(this.cmbCustomerStatus, null);
            this.cmbCustomerStatus.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.cmbCustomerStatus, true);
            this.cmbCustomerStatus.ItemHeight = 15;
            this.cmbCustomerStatus.Location = new System.Drawing.Point(381, 7);
            this.cmbCustomerStatus.Name = "cmbCustomerStatus";
            this.dataBindingCustomer.SetPropertyName(this.cmbCustomerStatus, "Status");
            this.cmbCustomerStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomerStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerStatus.TabIndex = 23;
            this.superValidator.SetValidator1(this.cmbCustomerStatus, this.requiredFieldValidator1);
            // 
            // textBoxX6
            // 
            // 
            // 
            // 
            this.textBoxX6.Border.Class = "TextBoxBorder";
            this.textBoxX6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingCustomer.SetFormatString(this.textBoxX6, null);
            this.highlighter.SetHighlightOnFocus(this.textBoxX6, true);
            this.textBoxX6.Location = new System.Drawing.Point(652, 34);
            this.textBoxX6.Name = "textBoxX6";
            this.textBoxX6.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.textBoxX6, "Introducer");
            this.textBoxX6.Size = new System.Drawing.Size(120, 21);
            this.textBoxX6.TabIndex = 30;
            // 
            // cmbCustomerSource
            // 
            this.cmbCustomerSource.DisplayMember = "Text";
            this.cmbCustomerSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingCustomer.SetFormatString(this.cmbCustomerSource, null);
            this.cmbCustomerSource.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.cmbCustomerSource, true);
            this.cmbCustomerSource.ItemHeight = 15;
            this.cmbCustomerSource.Location = new System.Drawing.Point(381, 34);
            this.cmbCustomerSource.Name = "cmbCustomerSource";
            this.dataBindingCustomer.SetPropertyName(this.cmbCustomerSource, "CustomerSource");
            this.cmbCustomerSource.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomerSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerSource.TabIndex = 28;
            // 
            // cmbCustomerClass
            // 
            this.cmbCustomerClass.DisplayMember = "Text";
            this.cmbCustomerClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingCustomer.SetFormatString(this.cmbCustomerClass, null);
            this.cmbCustomerClass.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.cmbCustomerClass, true);
            this.cmbCustomerClass.ItemHeight = 15;
            this.cmbCustomerClass.Location = new System.Drawing.Point(109, 34);
            this.cmbCustomerClass.Name = "cmbCustomerClass";
            this.dataBindingCustomer.SetPropertyName(this.cmbCustomerClass, "CustomerClass");
            this.cmbCustomerClass.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomerClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerClass.TabIndex = 26;
            // 
            // cmbIntentPhase
            // 
            this.cmbIntentPhase.DisplayMember = "Text";
            this.cmbIntentPhase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingCustomer.SetFormatString(this.cmbIntentPhase, null);
            this.cmbIntentPhase.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.cmbIntentPhase, true);
            this.cmbIntentPhase.ItemHeight = 15;
            this.cmbIntentPhase.Location = new System.Drawing.Point(651, 7);
            this.cmbIntentPhase.Name = "cmbIntentPhase";
            this.dataBindingCustomer.SetPropertyName(this.cmbIntentPhase, "IntentPhase");
            this.cmbIntentPhase.Size = new System.Drawing.Size(121, 21);
            this.cmbIntentPhase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbIntentPhase.TabIndex = 24;
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
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel1.Controls.Add(this.textBoxX6);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.cmbCustomerSource);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.cmbCustomerClass);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.cmbIntentPhase);
            this.groupPanel1.Controls.Add(this.cmbCustomerStatus);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.textBoxX5);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(876, 83);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(557, 34);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 21);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 29;
            this.labelX6.Text = "介绍人";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(268, 34);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 21);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 27;
            this.labelX5.Text = "客户来源";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(9, 34);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 21);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 25;
            this.labelX4.Text = "客户级别";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(557, 7);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 21);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 21;
            this.labelX3.Text = "跟进阶段";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(268, 7);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 21);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 19;
            this.labelX2.Text = "客户状态";
            // 
            // textBoxX5
            // 
            // 
            // 
            // 
            this.textBoxX5.Border.Class = "TextBoxBorder";
            this.textBoxX5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingCustomer.SetFormatString(this.textBoxX5, null);
            this.textBoxX5.Location = new System.Drawing.Point(109, 7);
            this.textBoxX5.Name = "textBoxX5";
            this.textBoxX5.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.textBoxX5, "CustomerId");
            this.textBoxX5.ReadOnly = true;
            this.textBoxX5.Size = new System.Drawing.Size(120, 21);
            this.textBoxX5.TabIndex = 18;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(10, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 21);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 17;
            this.labelX1.Text = "客户ID";
            // 
            // tabCustomer
            // 
            this.tabCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.tabCustomer.CanReorderTabs = true;
            this.tabCustomer.Controls.Add(this.tabControlPanel1);
            this.tabCustomer.Controls.Add(this.tabControlPanel2);
            this.tabCustomer.Controls.Add(this.tabControlPanel4);
            this.tabCustomer.Controls.Add(this.tabControlPanel5);
            this.tabCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCustomer.Location = new System.Drawing.Point(0, 83);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.SelectedTabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.tabCustomer.SelectedTabIndex = 0;
            this.tabCustomer.Size = new System.Drawing.Size(876, 380);
            this.tabCustomer.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabCustomer.TabIndex = 3;
            this.tabCustomer.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabCustomer.Tabs.Add(this.tiBaseInfo);
            this.tabCustomer.Tabs.Add(this.tiAsset);
            this.tabCustomer.Tabs.Add(this.tiOther);
            this.tabCustomer.Tabs.Add(this.tiFamily);
            this.tabCustomer.Text = "tabControl1";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Controls.Add(this.panelEx2);
            this.tabControlPanel5.Controls.Add(this.panelEx3);
            this.tabControlPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(876, 355);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 5;
            this.tabControlPanel5.TabItem = this.tiFamily;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.grdFamily);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(1, 1);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(874, 306);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            // 
            // grdFamily
            // 
            this.grdFamily.AutoGenerateColumns = false;
            this.grdFamily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFamily.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colDelete,
            this.customerIdDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.colRelation,
            this.colIdType,
            this.idCardNoDataGridViewTextBoxColumn,
            this.colGender,
            this.birthdayDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.houseInfoDataGridViewTextBoxColumn,
            this.familyInfoDataGridViewTextBoxColumn,
            this.incomingInfoDataGridViewTextBoxColumn,
            this.carInfoDataGridViewTextBoxColumn,
            this.otherInfoDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.customerClassDataGridViewTextBoxColumn,
            this.intentPhaseDataGridViewTextBoxColumn,
            this.customerSourceDataGridViewTextBoxColumn,
            this.introducerDataGridViewTextBoxColumn,
            this.createTimeDataGridViewTextBoxColumn,
            this.updatedByDataGridViewTextBoxColumn,
            this.updateTimeDataGridViewTextBoxColumn,
            this.versionNoDataGridViewTextBoxColumn});
            this.grdFamily.DataSource = this.customerBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFamily.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdFamily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFamily.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdFamily.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdFamily.Location = new System.Drawing.Point(0, 0);
            this.grdFamily.Name = "grdFamily";
            this.grdFamily.RowTemplate.Height = 23;
            this.grdFamily.Size = new System.Drawing.Size(874, 306);
            this.grdFamily.TabIndex = 0;
            this.grdFamily.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFamily_CellContentClick);
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEdit.HeaderText = "";
            this.colEdit.Image = ((System.Drawing.Image)(resources.GetObject("colEdit.Image")));
            this.colEdit.MinimumWidth = 20;
            this.colEdit.Name = "colEdit";
            this.colEdit.Text = null;
            this.colEdit.Width = 22;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = ((System.Drawing.Image)(resources.GetObject("colDelete.Image")));
            this.colDelete.Name = "colDelete";
            this.colDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colDelete.Text = null;
            this.colDelete.Width = 20;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "姓名";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            // 
            // colRelation
            // 
            this.colRelation.DataPropertyName = "Relation";
            this.colRelation.DisplayMember = "Text";
            this.colRelation.DropDownHeight = 106;
            this.colRelation.DropDownWidth = 121;
            this.colRelation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colRelation.HeaderText = "关系";
            this.colRelation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colRelation.IntegralHeight = false;
            this.colRelation.ItemHeight = 16;
            this.colRelation.Name = "colRelation";
            this.colRelation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // colIdType
            // 
            this.colIdType.DataPropertyName = "IdType";
            this.colIdType.DisplayMember = "Text";
            this.colIdType.DropDownHeight = 106;
            this.colIdType.DropDownWidth = 121;
            this.colIdType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colIdType.HeaderText = "证件类别";
            this.colIdType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colIdType.IntegralHeight = false;
            this.colIdType.ItemHeight = 16;
            this.colIdType.Name = "colIdType";
            this.colIdType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIdType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colIdType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // idCardNoDataGridViewTextBoxColumn
            // 
            this.idCardNoDataGridViewTextBoxColumn.DataPropertyName = "IdCardNo";
            this.idCardNoDataGridViewTextBoxColumn.HeaderText = "证件号码";
            this.idCardNoDataGridViewTextBoxColumn.MaxInputLength = 30;
            this.idCardNoDataGridViewTextBoxColumn.Name = "idCardNoDataGridViewTextBoxColumn";
            // 
            // colGender
            // 
            this.colGender.DataPropertyName = "Gender";
            this.colGender.DisplayMember = "Text";
            this.colGender.DropDownHeight = 106;
            this.colGender.DropDownWidth = 121;
            this.colGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colGender.HeaderText = "性别";
            this.colGender.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colGender.IntegralHeight = false;
            this.colGender.ItemHeight = 16;
            this.colGender.Name = "colGender";
            this.colGender.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGender.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colGender.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            // 
            // 
            // 
            this.birthdayDataGridViewTextBoxColumn.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.birthdayDataGridViewTextBoxColumn.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.birthdayDataGridViewTextBoxColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.birthdayDataGridViewTextBoxColumn.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.HeaderText = "出生日期";
            this.birthdayDataGridViewTextBoxColumn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.DisplayMonth = new System.DateTime(2014, 10, 1, 0, 0, 0, 0);
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.birthdayDataGridViewTextBoxColumn.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            this.birthdayDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "单位";
            this.unitDataGridViewTextBoxColumn.MaxInputLength = 100;
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "职务";
            this.positionDataGridViewTextBoxColumn.MaxInputLength = 50;
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            // 
            // houseInfoDataGridViewTextBoxColumn
            // 
            this.houseInfoDataGridViewTextBoxColumn.DataPropertyName = "HouseInfo";
            this.houseInfoDataGridViewTextBoxColumn.HeaderText = "HouseInfo";
            this.houseInfoDataGridViewTextBoxColumn.Name = "houseInfoDataGridViewTextBoxColumn";
            this.houseInfoDataGridViewTextBoxColumn.Visible = false;
            // 
            // familyInfoDataGridViewTextBoxColumn
            // 
            this.familyInfoDataGridViewTextBoxColumn.DataPropertyName = "FamilyInfo";
            this.familyInfoDataGridViewTextBoxColumn.HeaderText = "FamilyInfo";
            this.familyInfoDataGridViewTextBoxColumn.Name = "familyInfoDataGridViewTextBoxColumn";
            this.familyInfoDataGridViewTextBoxColumn.Visible = false;
            // 
            // incomingInfoDataGridViewTextBoxColumn
            // 
            this.incomingInfoDataGridViewTextBoxColumn.DataPropertyName = "IncomingInfo";
            this.incomingInfoDataGridViewTextBoxColumn.HeaderText = "IncomingInfo";
            this.incomingInfoDataGridViewTextBoxColumn.Name = "incomingInfoDataGridViewTextBoxColumn";
            this.incomingInfoDataGridViewTextBoxColumn.Visible = false;
            // 
            // carInfoDataGridViewTextBoxColumn
            // 
            this.carInfoDataGridViewTextBoxColumn.DataPropertyName = "CarInfo";
            this.carInfoDataGridViewTextBoxColumn.HeaderText = "CarInfo";
            this.carInfoDataGridViewTextBoxColumn.Name = "carInfoDataGridViewTextBoxColumn";
            this.carInfoDataGridViewTextBoxColumn.Visible = false;
            // 
            // otherInfoDataGridViewTextBoxColumn
            // 
            this.otherInfoDataGridViewTextBoxColumn.DataPropertyName = "OtherInfo";
            this.otherInfoDataGridViewTextBoxColumn.HeaderText = "其它信息";
            this.otherInfoDataGridViewTextBoxColumn.Name = "otherInfoDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerClassDataGridViewTextBoxColumn
            // 
            this.customerClassDataGridViewTextBoxColumn.DataPropertyName = "CustomerClass";
            this.customerClassDataGridViewTextBoxColumn.HeaderText = "CustomerClass";
            this.customerClassDataGridViewTextBoxColumn.Name = "customerClassDataGridViewTextBoxColumn";
            this.customerClassDataGridViewTextBoxColumn.Visible = false;
            // 
            // intentPhaseDataGridViewTextBoxColumn
            // 
            this.intentPhaseDataGridViewTextBoxColumn.DataPropertyName = "IntentPhase";
            this.intentPhaseDataGridViewTextBoxColumn.HeaderText = "IntentPhase";
            this.intentPhaseDataGridViewTextBoxColumn.Name = "intentPhaseDataGridViewTextBoxColumn";
            this.intentPhaseDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerSourceDataGridViewTextBoxColumn
            // 
            this.customerSourceDataGridViewTextBoxColumn.DataPropertyName = "CustomerSource";
            this.customerSourceDataGridViewTextBoxColumn.HeaderText = "CustomerSource";
            this.customerSourceDataGridViewTextBoxColumn.Name = "customerSourceDataGridViewTextBoxColumn";
            this.customerSourceDataGridViewTextBoxColumn.Visible = false;
            // 
            // introducerDataGridViewTextBoxColumn
            // 
            this.introducerDataGridViewTextBoxColumn.DataPropertyName = "Introducer";
            this.introducerDataGridViewTextBoxColumn.HeaderText = "Introducer";
            this.introducerDataGridViewTextBoxColumn.Name = "introducerDataGridViewTextBoxColumn";
            this.introducerDataGridViewTextBoxColumn.Visible = false;
            // 
            // createTimeDataGridViewTextBoxColumn
            // 
            this.createTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.HeaderText = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.Name = "createTimeDataGridViewTextBoxColumn";
            this.createTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // updatedByDataGridViewTextBoxColumn
            // 
            this.updatedByDataGridViewTextBoxColumn.DataPropertyName = "UpdatedBy";
            this.updatedByDataGridViewTextBoxColumn.HeaderText = "UpdatedBy";
            this.updatedByDataGridViewTextBoxColumn.Name = "updatedByDataGridViewTextBoxColumn";
            this.updatedByDataGridViewTextBoxColumn.Visible = false;
            // 
            // updateTimeDataGridViewTextBoxColumn
            // 
            this.updateTimeDataGridViewTextBoxColumn.DataPropertyName = "UpdateTime";
            this.updateTimeDataGridViewTextBoxColumn.HeaderText = "UpdateTime";
            this.updateTimeDataGridViewTextBoxColumn.Name = "updateTimeDataGridViewTextBoxColumn";
            this.updateTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // versionNoDataGridViewTextBoxColumn
            // 
            this.versionNoDataGridViewTextBoxColumn.DataPropertyName = "VersionNo";
            this.versionNoDataGridViewTextBoxColumn.HeaderText = "VersionNo";
            this.versionNoDataGridViewTextBoxColumn.Name = "versionNoDataGridViewTextBoxColumn";
            this.versionNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(SimpleCrm.Model.Customer);
            // 
            // panelEx3
            // 
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.btnSelectCustomer);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx3.Location = new System.Drawing.Point(1, 307);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(874, 47);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 1;
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectCustomer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectCustomer.Location = new System.Drawing.Point(31, 7);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(99, 23);
            this.btnSelectCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelectCustomer.TabIndex = 0;
            this.btnSelectCustomer.Text = "加入已有客户";
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // tiFamily
            // 
            this.tiFamily.AttachedControl = this.tabControlPanel5;
            this.tiFamily.Name = "tiFamily";
            this.tiFamily.Text = "家庭成员";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tabControlPanel1.Controls.Add(this.customerBaseInfoUC);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(876, 355);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tiBaseInfo;
            // 
            // customerBaseInfoUC
            // 
            this.customerBaseInfoUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerBaseInfoUC.Location = new System.Drawing.Point(1, 1);
            this.customerBaseInfoUC.Name = "customerBaseInfoUC";
            this.customerBaseInfoUC.Size = new System.Drawing.Size(874, 353);
            this.customerBaseInfoUC.TabIndex = 0;
            // 
            // tiBaseInfo
            // 
            this.tiBaseInfo.AttachedControl = this.tabControlPanel1;
            this.tiBaseInfo.Name = "tiBaseInfo";
            this.tiBaseInfo.Text = "基本信息";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.groupPanel5);
            this.tabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(876, 355);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.tiOther;
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel5.Controls.Add(this.textBoxX4);
            this.groupPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel5.Location = new System.Drawing.Point(1, 1);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(874, 353);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 5;
            this.groupPanel5.Text = "其它";
            // 
            // textBoxX4
            // 
            // 
            // 
            // 
            this.textBoxX4.Border.Class = "TextBoxBorder";
            this.textBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataBindingCustomer.SetFormatString(this.textBoxX4, null);
            this.textBoxX4.Location = new System.Drawing.Point(0, 0);
            this.textBoxX4.Multiline = true;
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.textBoxX4, "OtherInfo");
            this.textBoxX4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX4.Size = new System.Drawing.Size(868, 329);
            this.textBoxX4.TabIndex = 0;
            // 
            // tiOther
            // 
            this.tiOther.AttachedControl = this.tabControlPanel4;
            this.tiOther.Name = "tiOther";
            this.tiOther.Text = "其它";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.groupPanel4);
            this.tabControlPanel2.Controls.Add(this.groupPanel3);
            this.tabControlPanel2.Controls.Add(this.groupPanel2);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(876, 355);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tiAsset;
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel4.Controls.Add(this.textBoxX3);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel4.Location = new System.Drawing.Point(1, 200);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(874, 154);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 3;
            this.groupPanel4.Text = "车辆";
            // 
            // textBoxX3
            // 
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataBindingCustomer.SetFormatString(this.textBoxX3, null);
            this.textBoxX3.Location = new System.Drawing.Point(0, 0);
            this.textBoxX3.Multiline = true;
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.textBoxX3, "CarInfo");
            this.textBoxX3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX3.Size = new System.Drawing.Size(868, 130);
            this.textBoxX3.TabIndex = 0;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel3.Controls.Add(this.textBoxX2);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel3.Location = new System.Drawing.Point(1, 106);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(874, 94);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 2;
            this.groupPanel3.Text = "房产";
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataBindingCustomer.SetFormatString(this.textBoxX2, null);
            this.textBoxX2.Location = new System.Drawing.Point(0, 0);
            this.textBoxX2.Multiline = true;
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.textBoxX2, "HouseInfo");
            this.textBoxX2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX2.Size = new System.Drawing.Size(868, 70);
            this.textBoxX2.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel2.Controls.Add(this.textBoxX1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(1, 1);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(874, 105);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "收入";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataBindingCustomer.SetFormatString(this.textBoxX1, null);
            this.textBoxX1.Location = new System.Drawing.Point(0, 0);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.textBoxX1, "IncomingInfo");
            this.textBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX1.Size = new System.Drawing.Size(868, 81);
            this.textBoxX1.TabIndex = 0;
            // 
            // tiAsset
            // 
            this.tiAsset.AttachedControl = this.tabControlPanel2;
            this.tiAsset.Name = "tiAsset";
            this.tiAsset.Text = "资产";
            // 
            // dataBindingCustomer
            // 
            this.dataBindingCustomer.DateTimeFormat = "yyyy-MM-dd";
            // 
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarMergeContainer1.Controls.Add(this.ribbonBar1);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(246, 202);
            this.ribbonBarMergeContainer1.Name = "ribbonBarMergeContainer1";
            this.ribbonBarMergeContainer1.RibbonTabText = "保单详细信息";
            this.ribbonBarMergeContainer1.Size = new System.Drawing.Size(384, 59);
            // 
            // 
            // 
            this.ribbonBarMergeContainer1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarMergeContainer1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBarMergeContainer1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBarMergeContainer1.TabIndex = 7;
            this.ribbonBarMergeContainer1.Visible = false;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSave});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(384, 59);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "保单";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.TitleVisible = false;
            // 
            // btnSave
            // 
            this.btnSave.BeginGroup = true;
            this.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSave.Image = global::SimpleCrm.Properties.Resources.save;
            this.btnSave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSave.Name = "btnSave";
            this.btnSave.SubItemsExpandWidth = 14;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomerDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 463);
            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Controls.Add(this.tabCustomer);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.Name = "CustomerDetailForm";
            this.Text = "客户详细信息";
            this.Load += new System.EventHandler(this.CustomerDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomer)).EndInit();
            this.tabCustomer.ResumeLayout(false);
            this.tabControlPanel5.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFamily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.groupPanel5.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCustomer)).EndInit();
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Validator.SuperValidator superValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.TabControl tabCustomer;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tiBaseInfo;
        private UserControls.CustomerBaseInfoUC customerBaseInfoUC;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tiAsset;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdFamily;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private DevComponents.DotNetBar.TabItem tiFamily;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX4;
        private DevComponents.DotNetBar.TabItem tiOther;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX5;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX6;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerSource;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerClass;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbIntentPhase;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerStatus;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryCustomerIdDataGridViewTextBoxColumn;
        private Utils.DataBinding dataBindingCustomer;
        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonX btnSelectCustomer;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colEdit;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colRelation;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colIdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCardNoDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colGender;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn birthdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn houseInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn familyInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incomingInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otherInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerClassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intentPhaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn introducerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionNoDataGridViewTextBoxColumn;
    }
}