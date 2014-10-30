namespace SimpleCrm.InsuranceForm
{
    partial class InsurancePolicyDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsurancePolicyDetailForm));
            this.labelX15 = new DevComponents.DotNetBar.LabelX();
            this.txtCustomerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX10 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX16 = new DevComponents.DotNetBar.LabelX();
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput3 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX12 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX13 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.tabIPInfo = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.grdBeneficiary = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tiBeneficiary = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.cmbStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            this.doubleInput1 = new DevComponents.Editors.DoubleInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tiBaseInfo = new DevComponents.DotNetBar.TabItem(this.components);
            this.tcpPolicyHolder = new DevComponents.DotNetBar.TabControlPanel();
            this.holderBaseInfo = new SimpleCrm.CustomerForm.UserControls.CustomerBaseInfoUC();
            this.tiPolicyHolder = new DevComponents.DotNetBar.TabItem(this.components);
            this.tcpInsured = new DevComponents.DotNetBar.TabControlPanel();
            this.insuredBaseInfo = new SimpleCrm.CustomerForm.UserControls.CustomerBaseInfoUC();
            this.tiInsured = new DevComponents.DotNetBar.TabItem(this.components);
            this.tcpPolicyInfo = new DevComponents.DotNetBar.TabControlPanel();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tiPolicyDetailInfo = new DevComponents.DotNetBar.TabItem(this.components);
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.icCustomerList = new DevComponents.DotNetBar.ItemContainer();
            this.cmbCustomerList = new DevComponents.DotNetBar.ComboBoxItem();
            this.chkSameHolderAndInsured = new DevComponents.DotNetBar.CheckBoxItem();
            this.dataBindingIP = new SimpleCrm.Utils.DataBinding(this.components);
            this.superValidator = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("必填项");
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("必填项");
            this.requiredFieldValidator5 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("必填项");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("必填项");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("必填项");
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.grpInsuredRelation = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cmbRelation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRelationWithInsured = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colIdType = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colIdCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabIPInfo)).BeginInit();
            this.tabIPInfo.SuspendLayout();
            this.tabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBeneficiary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput1)).BeginInit();
            this.tcpPolicyHolder.SuspendLayout();
            this.tcpInsured.SuspendLayout();
            this.tcpPolicyInfo.SuspendLayout();
            this.ribbonBarMergeContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.grpInsuredRelation.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX15
            // 
            // 
            // 
            // 
            this.labelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX15.Location = new System.Drawing.Point(4, 105);
            this.labelX15.Name = "labelX15";
            this.labelX15.Size = new System.Drawing.Size(75, 21);
            this.labelX15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX15.TabIndex = 25;
            this.labelX15.Text = "保单状态";
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.Border.Class = "TextBoxBorder";
            this.txtCustomerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerName.Location = new System.Drawing.Point(85, 3);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PreventEnterBeep = true;
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(120, 21);
            this.txtCustomerName.TabIndex = 24;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 21);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 18;
            this.labelX1.Text = "客户姓名";
            // 
            // textBoxX10
            // 
            // 
            // 
            // 
            this.textBoxX10.Border.Class = "TextBoxBorder";
            this.textBoxX10.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingIP.SetFormatString(this.textBoxX10, null);
            this.textBoxX10.Location = new System.Drawing.Point(86, 52);
            this.textBoxX10.Name = "textBoxX10";
            this.textBoxX10.PreventEnterBeep = true;
            this.dataBindingIP.SetPropertyName(this.textBoxX10, "InsurancePolicyNo");
            this.textBoxX10.Size = new System.Drawing.Size(117, 21);
            this.textBoxX10.TabIndex = 36;
            this.superValidator.SetValidator1(this.textBoxX10, this.requiredFieldValidator1);
            // 
            // labelX16
            // 
            // 
            // 
            // 
            this.labelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX16.Location = new System.Drawing.Point(4, 52);
            this.labelX16.Name = "labelX16";
            this.labelX16.Size = new System.Drawing.Size(75, 21);
            this.labelX16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX16.TabIndex = 35;
            this.labelX16.Text = "保单号码";
            // 
            // labelX14
            // 
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(4, 77);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(75, 21);
            this.labelX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX14.TabIndex = 33;
            this.labelX14.Text = "投保年限";
            // 
            // dateTimeInput3
            // 
            // 
            // 
            // 
            this.dateTimeInput3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput3.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput3.ButtonDropDown.Visible = true;
            this.dateTimeInput3.CustomFormat = "yyyy-MM-dd";
            this.dateTimeInput3.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dataBindingIP.SetFormatString(this.dateTimeInput3, null);
            this.dateTimeInput3.IsPopupCalendarOpen = false;
            this.dateTimeInput3.Location = new System.Drawing.Point(405, 77);
            this.dateTimeInput3.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dateTimeInput3.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTimeInput3.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput3.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput3.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput3.MonthCalendar.DisplayMonth = new System.DateTime(2014, 10, 1, 0, 0, 0, 0);
            this.dateTimeInput3.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeInput3.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput3.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput3.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeInput3.Name = "dateTimeInput3";
            this.dataBindingIP.SetPropertyName(this.dateTimeInput3, "EffectiveDate");
            this.dateTimeInput3.Size = new System.Drawing.Size(104, 21);
            this.dateTimeInput3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput3.TabIndex = 32;
            this.superValidator.SetValidator1(this.dateTimeInput3, this.requiredFieldValidator4);
            // 
            // labelX13
            // 
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(323, 77);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(75, 21);
            this.labelX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX13.TabIndex = 31;
            this.labelX13.Text = "生效日期";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(602, 77);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 21);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 29;
            this.labelX4.Text = "年交保费";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(323, 52);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 21);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 25;
            this.labelX2.Text = "保险类别";
            // 
            // textBoxX12
            // 
            // 
            // 
            // 
            this.textBoxX12.Border.Class = "TextBoxBorder";
            this.textBoxX12.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingIP.SetFormatString(this.textBoxX12, null);
            this.textBoxX12.Location = new System.Drawing.Point(88, 35);
            this.textBoxX12.MaxLength = 2000;
            this.textBoxX12.Multiline = true;
            this.textBoxX12.Name = "textBoxX12";
            this.textBoxX12.PreventEnterBeep = true;
            this.dataBindingIP.SetPropertyName(this.textBoxX12, "PrimaryIPInfo");
            this.textBoxX12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX12.Size = new System.Drawing.Size(781, 145);
            this.textBoxX12.TabIndex = 40;
            // 
            // labelX18
            // 
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(3, 35);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(75, 21);
            this.labelX18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX18.TabIndex = 39;
            this.labelX18.Text = "主险描述";
            // 
            // textBoxX13
            // 
            // 
            // 
            // 
            this.textBoxX13.Border.Class = "TextBoxBorder";
            this.textBoxX13.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingIP.SetFormatString(this.textBoxX13, null);
            this.textBoxX13.Location = new System.Drawing.Point(88, 217);
            this.textBoxX13.MaxLength = 2000;
            this.textBoxX13.Multiline = true;
            this.textBoxX13.Name = "textBoxX13";
            this.textBoxX13.PreventEnterBeep = true;
            this.dataBindingIP.SetPropertyName(this.textBoxX13, "SecondaryIPInfo");
            this.textBoxX13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX13.Size = new System.Drawing.Size(781, 189);
            this.textBoxX13.TabIndex = 42;
            // 
            // labelX19
            // 
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Location = new System.Drawing.Point(3, 214);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(75, 21);
            this.labelX19.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX19.TabIndex = 41;
            this.labelX19.Text = "附加险描述";
            // 
            // tabIPInfo
            // 
            this.tabIPInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabIPInfo.CanReorderTabs = true;
            this.tabIPInfo.Controls.Add(this.tabControlPanel5);
            this.tabIPInfo.Controls.Add(this.tcpInsured);
            this.tabIPInfo.Controls.Add(this.tcpPolicyHolder);
            this.tabIPInfo.Controls.Add(this.tabControlPanel1);
            this.tabIPInfo.Controls.Add(this.tcpPolicyInfo);
            this.tabIPInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIPInfo.Location = new System.Drawing.Point(0, 0);
            this.tabIPInfo.Name = "tabIPInfo";
            this.tabIPInfo.SelectedTabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.tabIPInfo.SelectedTabIndex = 0;
            this.tabIPInfo.Size = new System.Drawing.Size(907, 448);
            this.tabIPInfo.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabIPInfo.TabIndex = 43;
            this.tabIPInfo.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabIPInfo.Tabs.Add(this.tiBaseInfo);
            this.tabIPInfo.Tabs.Add(this.tiPolicyHolder);
            this.tabIPInfo.Tabs.Add(this.tiInsured);
            this.tabIPInfo.Tabs.Add(this.tiPolicyDetailInfo);
            this.tabIPInfo.Tabs.Add(this.tiBeneficiary);
            this.tabIPInfo.Text = "tabControl1";
            this.tabIPInfo.SelectedTabChanged += new DevComponents.DotNetBar.TabStrip.SelectedTabChangedEventHandler(this.tabIPInfo_SelectedTabChanged);
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tabControlPanel5.Controls.Add(this.grdBeneficiary);
            this.tabControlPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(907, 423);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 5;
            this.tabControlPanel5.TabItem = this.tiBeneficiary;
            // 
            // grdBeneficiary
            // 
            this.grdBeneficiary.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBeneficiary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBeneficiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBeneficiary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.customerIdDataGridViewTextBoxColumn,
            this.colCustomerName,
            this.colRelationWithInsured,
            this.colIdType,
            this.colIdCardNo,
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
            this.grdBeneficiary.DataSource = this.customerBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdBeneficiary.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdBeneficiary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBeneficiary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdBeneficiary.EnableHeadersVisualStyles = false;
            this.grdBeneficiary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdBeneficiary.Location = new System.Drawing.Point(1, 1);
            this.grdBeneficiary.Name = "grdBeneficiary";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdBeneficiary.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdBeneficiary.RowTemplate.Height = 23;
            this.grdBeneficiary.Size = new System.Drawing.Size(905, 421);
            this.grdBeneficiary.TabIndex = 1;
            this.grdBeneficiary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBeneficiary_CellContentClick);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(SimpleCrm.Model.Customer);
            // 
            // tiBeneficiary
            // 
            this.tiBeneficiary.AttachedControl = this.tabControlPanel5;
            this.tiBeneficiary.Name = "tiBeneficiary";
            this.tiBeneficiary.Text = "受益人";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tabControlPanel1.Controls.Add(this.groupPanel1);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(907, 423);
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
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(4, 28);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1420, 23);
            this.line1.TabIndex = 47;
            this.line1.Text = "line1";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DisplayMember = "Text";
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingIP.SetFormatString(this.cmbStatus, null);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.ItemHeight = 15;
            this.cmbStatus.Location = new System.Drawing.Point(86, 105);
            this.cmbStatus.Name = "cmbStatus";
            this.dataBindingIP.SetPropertyName(this.cmbStatus, "Status");
            this.cmbStatus.Size = new System.Drawing.Size(119, 21);
            this.cmbStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbStatus.TabIndex = 46;
            this.superValidator.SetValidator1(this.cmbStatus, this.requiredFieldValidator5);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DisplayMember = "Text";
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingIP.SetFormatString(this.cmbCategory, null);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.ItemHeight = 15;
            this.cmbCategory.Location = new System.Drawing.Point(405, 52);
            this.cmbCategory.Name = "cmbCategory";
            this.dataBindingIP.SetPropertyName(this.cmbCategory, "Category");
            this.cmbCategory.Size = new System.Drawing.Size(104, 21);
            this.cmbCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCategory.TabIndex = 45;
            this.superValidator.SetValidator1(this.cmbCategory, this.requiredFieldValidator2);
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // integerInput1
            // 
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.dataBindingIP.SetFormatString(this.integerInput1, null);
            this.integerInput1.Location = new System.Drawing.Point(86, 77);
            this.integerInput1.MaxValue = 200;
            this.integerInput1.MinValue = 0;
            this.integerInput1.Name = "integerInput1";
            this.dataBindingIP.SetPropertyName(this.integerInput1, "InsuredYear");
            this.integerInput1.ShowUpDown = true;
            this.integerInput1.Size = new System.Drawing.Size(119, 21);
            this.integerInput1.TabIndex = 44;
            this.superValidator.SetValidator1(this.integerInput1, this.requiredFieldValidator3);
            // 
            // doubleInput1
            // 
            // 
            // 
            // 
            this.doubleInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.dataBindingIP.SetFormatString(this.doubleInput1, null);
            this.doubleInput1.Increment = 1D;
            this.doubleInput1.Location = new System.Drawing.Point(683, 77);
            this.doubleInput1.MaxValue = 1000000000D;
            this.doubleInput1.MinValue = 0D;
            this.doubleInput1.Name = "doubleInput1";
            this.dataBindingIP.SetPropertyName(this.doubleInput1, "Premium");
            this.doubleInput1.ShowUpDown = true;
            this.doubleInput1.Size = new System.Drawing.Size(104, 21);
            this.doubleInput1.TabIndex = 43;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(4, 134);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 21);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 42;
            this.labelX3.Text = "其它信息";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingIP.SetFormatString(this.textBoxX1, null);
            this.textBoxX1.Location = new System.Drawing.Point(85, 134);
            this.textBoxX1.MaxLength = 2000;
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.dataBindingIP.SetPropertyName(this.textBoxX1, "Remark");
            this.textBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX1.Size = new System.Drawing.Size(810, 273);
            this.textBoxX1.TabIndex = 41;
            // 
            // tiBaseInfo
            // 
            this.tiBaseInfo.AttachedControl = this.tabControlPanel1;
            this.tiBaseInfo.Name = "tiBaseInfo";
            this.tiBaseInfo.Text = "保单基本资料";
            // 
            // tcpPolicyHolder
            // 
            this.tcpPolicyHolder.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tcpPolicyHolder.Controls.Add(this.holderBaseInfo);
            this.tcpPolicyHolder.DisabledBackColor = System.Drawing.Color.Empty;
            this.tcpPolicyHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpPolicyHolder.Location = new System.Drawing.Point(0, 25);
            this.tcpPolicyHolder.Name = "tcpPolicyHolder";
            this.tcpPolicyHolder.Padding = new System.Windows.Forms.Padding(1);
            this.tcpPolicyHolder.Size = new System.Drawing.Size(907, 423);
            this.tcpPolicyHolder.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tcpPolicyHolder.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tcpPolicyHolder.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tcpPolicyHolder.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tcpPolicyHolder.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tcpPolicyHolder.Style.GradientAngle = 90;
            this.tcpPolicyHolder.TabIndex = 2;
            this.tcpPolicyHolder.TabItem = this.tiPolicyHolder;
            // 
            // holderBaseInfo
            // 
            this.holderBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holderBaseInfo.Location = new System.Drawing.Point(1, 1);
            this.holderBaseInfo.Name = "holderBaseInfo";
            this.holderBaseInfo.Size = new System.Drawing.Size(905, 421);
            this.holderBaseInfo.TabIndex = 0;
            // 
            // tiPolicyHolder
            // 
            this.tiPolicyHolder.AttachedControl = this.tcpPolicyHolder;
            this.tiPolicyHolder.Name = "tiPolicyHolder";
            this.tiPolicyHolder.Text = "投保人";
            // 
            // tcpInsured
            // 
            this.tcpInsured.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tcpInsured.Controls.Add(this.insuredBaseInfo);
            this.tcpInsured.Controls.Add(this.grpInsuredRelation);
            this.tcpInsured.DisabledBackColor = System.Drawing.Color.Empty;
            this.tcpInsured.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpInsured.Location = new System.Drawing.Point(0, 25);
            this.tcpInsured.Name = "tcpInsured";
            this.tcpInsured.Padding = new System.Windows.Forms.Padding(1);
            this.tcpInsured.Size = new System.Drawing.Size(907, 423);
            this.tcpInsured.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tcpInsured.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tcpInsured.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tcpInsured.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tcpInsured.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tcpInsured.Style.GradientAngle = 90;
            this.tcpInsured.TabIndex = 3;
            this.tcpInsured.TabItem = this.tiInsured;
            // 
            // insuredBaseInfo
            // 
            this.insuredBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insuredBaseInfo.Location = new System.Drawing.Point(1, 44);
            this.insuredBaseInfo.Name = "insuredBaseInfo";
            this.insuredBaseInfo.Size = new System.Drawing.Size(905, 378);
            this.insuredBaseInfo.TabIndex = 0;
            // 
            // tiInsured
            // 
            this.tiInsured.AttachedControl = this.tcpInsured;
            this.tiInsured.Name = "tiInsured";
            this.tiInsured.Text = "被保人";
            // 
            // tcpPolicyInfo
            // 
            this.tcpPolicyInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tcpPolicyInfo.Controls.Add(this.groupPanel2);
            this.tcpPolicyInfo.DisabledBackColor = System.Drawing.Color.Empty;
            this.tcpPolicyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpPolicyInfo.Location = new System.Drawing.Point(0, 25);
            this.tcpPolicyInfo.Name = "tcpPolicyInfo";
            this.tcpPolicyInfo.Padding = new System.Windows.Forms.Padding(1);
            this.tcpPolicyInfo.Size = new System.Drawing.Size(907, 423);
            this.tcpPolicyInfo.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tcpPolicyInfo.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tcpPolicyInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tcpPolicyInfo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tcpPolicyInfo.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tcpPolicyInfo.Style.GradientAngle = 90;
            this.tcpPolicyInfo.TabIndex = 4;
            this.tcpPolicyInfo.TabItem = this.tiPolicyDetailInfo;
            // 
            // textBoxX3
            // 
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingIP.SetFormatString(this.textBoxX3, null);
            this.textBoxX3.Location = new System.Drawing.Point(88, 186);
            this.textBoxX3.MaxLength = 100;
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.PreventEnterBeep = true;
            this.dataBindingIP.SetPropertyName(this.textBoxX3, "SecondaryIPName");
            this.textBoxX3.Size = new System.Drawing.Size(781, 21);
            this.textBoxX3.TabIndex = 46;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(3, 186);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 21);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 45;
            this.labelX6.Text = "附加险名称";
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingIP.SetFormatString(this.textBoxX2, null);
            this.textBoxX2.Location = new System.Drawing.Point(88, 3);
            this.textBoxX2.MaxLength = 100;
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.dataBindingIP.SetPropertyName(this.textBoxX2, "PrimaryIPName");
            this.textBoxX2.Size = new System.Drawing.Size(781, 21);
            this.textBoxX2.TabIndex = 44;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(3, 3);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 21);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 43;
            this.labelX5.Text = "主险名称";
            // 
            // tiPolicyDetailInfo
            // 
            this.tiPolicyDetailInfo.AttachedControl = this.tcpPolicyInfo;
            this.tiPolicyDetailInfo.Name = "tiPolicyDetailInfo";
            this.tiPolicyDetailInfo.Text = "险种资料";
            // 
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarMergeContainer1.Controls.Add(this.ribbonBar1);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(417, 3);
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
            this.ribbonBarMergeContainer1.TabIndex = 6;
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
            this.btnSave,
            this.icCustomerList,
            this.chkSameHolderAndInsured});
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
            // icCustomerList
            // 
            // 
            // 
            // 
            this.icCustomerList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.icCustomerList.BeginGroup = true;
            this.icCustomerList.Name = "icCustomerList";
            this.icCustomerList.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cmbCustomerList});
            // 
            // 
            // 
            this.icCustomerList.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.icCustomerList.TitleText = "相关客户";
            // 
            // cmbCustomerList
            // 
            this.cmbCustomerList.ComboWidth = 100;
            this.cmbCustomerList.DropDownHeight = 106;
            this.cmbCustomerList.ItemHeight = 16;
            this.cmbCustomerList.Name = "cmbCustomerList";
            this.cmbCustomerList.WatermarkText = "选择...";
            // 
            // chkSameHolderAndInsured
            // 
            this.chkSameHolderAndInsured.Name = "chkSameHolderAndInsured";
            this.chkSameHolderAndInsured.Text = "本人投保？";
            this.chkSameHolderAndInsured.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.chkSameHolderAndInsured_CheckedChanged);
            // 
            // dataBindingIP
            // 
            this.dataBindingIP.DateTimeFormat = "yyyy-MM-dd";
            // 
            // superValidator
            // 
            this.superValidator.ContainerControl = this;
            this.superValidator.ErrorProvider = this.errorProvider;
            this.superValidator.Highlighter = this.highlighter;
            this.superValidator.SteppedValidation = true;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "必填项";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ErrorMessage = "必填项";
            this.requiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator5
            // 
            this.requiredFieldValidator5.ErrorMessage = "必填项";
            this.requiredFieldValidator5.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "必填项";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "必填项";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // grpInsuredRelation
            // 
            this.grpInsuredRelation.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpInsuredRelation.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpInsuredRelation.Controls.Add(this.cmbRelation);
            this.grpInsuredRelation.Controls.Add(this.labelX7);
            this.grpInsuredRelation.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpInsuredRelation.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInsuredRelation.Location = new System.Drawing.Point(1, 1);
            this.grpInsuredRelation.Name = "grpInsuredRelation";
            this.grpInsuredRelation.Size = new System.Drawing.Size(905, 43);
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
            this.grpInsuredRelation.TabIndex = 1;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(12, 9);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(101, 21);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 36;
            this.labelX7.Text = "与投保人关系";
            // 
            // cmbRelation
            // 
            this.cmbRelation.DisplayMember = "Text";
            this.cmbRelation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRelation.FormattingEnabled = true;
            this.cmbRelation.ItemHeight = 15;
            this.cmbRelation.Location = new System.Drawing.Point(119, 9);
            this.cmbRelation.Name = "cmbRelation";
            this.cmbRelation.Size = new System.Drawing.Size(128, 21);
            this.cmbRelation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbRelation.TabIndex = 37;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.line1);
            this.groupPanel1.Controls.Add(this.labelX16);
            this.groupPanel1.Controls.Add(this.cmbStatus);
            this.groupPanel1.Controls.Add(this.textBoxX10);
            this.groupPanel1.Controls.Add(this.cmbCategory);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.integerInput1);
            this.groupPanel1.Controls.Add(this.labelX14);
            this.groupPanel1.Controls.Add(this.doubleInput1);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.dateTimeInput3);
            this.groupPanel1.Controls.Add(this.textBoxX1);
            this.groupPanel1.Controls.Add(this.labelX13);
            this.groupPanel1.Controls.Add(this.labelX15);
            this.groupPanel1.Controls.Add(this.txtCustomerName);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(1, 1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(905, 421);
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
            this.groupPanel1.TabIndex = 48;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.labelX5);
            this.groupPanel2.Controls.Add(this.textBoxX3);
            this.groupPanel2.Controls.Add(this.labelX18);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.Controls.Add(this.textBoxX12);
            this.groupPanel2.Controls.Add(this.textBoxX2);
            this.groupPanel2.Controls.Add(this.labelX19);
            this.groupPanel2.Controls.Add(this.textBoxX13);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(1, 1);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(905, 421);
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
            this.groupPanel2.TabIndex = 47;
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
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "CustomerName";
            this.colCustomerName.HeaderText = "姓名";
            this.colCustomerName.Name = "colCustomerName";
            // 
            // colRelationWithInsured
            // 
            this.colRelationWithInsured.DataPropertyName = "Relation";
            this.colRelationWithInsured.DisplayMember = "Text";
            this.colRelationWithInsured.DropDownHeight = 106;
            this.colRelationWithInsured.DropDownWidth = 121;
            this.colRelationWithInsured.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colRelationWithInsured.HeaderText = "与被保人关系";
            this.colRelationWithInsured.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colRelationWithInsured.IntegralHeight = false;
            this.colRelationWithInsured.ItemHeight = 16;
            this.colRelationWithInsured.Name = "colRelationWithInsured";
            this.colRelationWithInsured.RightToLeft = System.Windows.Forms.RightToLeft.No;
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
            // colIdCardNo
            // 
            this.colIdCardNo.DataPropertyName = "IdCardNo";
            this.colIdCardNo.HeaderText = "证件号码";
            this.colIdCardNo.MaxInputLength = 30;
            this.colIdCardNo.Name = "colIdCardNo";
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
            this.birthdayDataGridViewTextBoxColumn.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText;
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
            // InsurancePolicyDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 448);
            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Controls.Add(this.tabIPInfo);
            this.DoubleBuffered = true;
            this.Name = "InsurancePolicyDetailForm";
            this.Text = "保单详细信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsurancePolicyDetailForm_FormClosing);
            this.Load += new System.EventHandler(this.InsurancePolicyDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabIPInfo)).EndInit();
            this.tabIPInfo.ResumeLayout(false);
            this.tabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBeneficiary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput1)).EndInit();
            this.tcpPolicyHolder.ResumeLayout(false);
            this.tcpInsured.ResumeLayout(false);
            this.tcpPolicyInfo.ResumeLayout(false);
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.grpInsuredRelation.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.Controls.TextBoxX txtCustomerName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput3;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX15;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX10;
        private DevComponents.DotNetBar.LabelX labelX16;
        private DevComponents.DotNetBar.LabelX labelX14;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX13;
        private DevComponents.DotNetBar.LabelX labelX19;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX12;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.DotNetBar.TabControl tabIPInfo;
        private DevComponents.DotNetBar.TabControlPanel tcpPolicyInfo;
        private DevComponents.DotNetBar.TabItem tiPolicyDetailInfo;
        private DevComponents.DotNetBar.TabControlPanel tcpInsured;
        private CustomerForm.UserControls.CustomerBaseInfoUC insuredBaseInfo;
        private DevComponents.DotNetBar.TabItem tiInsured;
        private DevComponents.DotNetBar.TabControlPanel tcpPolicyHolder;
        private CustomerForm.UserControls.CustomerBaseInfoUC holderBaseInfo;
        private DevComponents.DotNetBar.TabItem tiPolicyHolder;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tiBaseInfo;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.TabItem tiBeneficiary;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdBeneficiary;
        private DevComponents.DotNetBar.LabelX labelX3;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbStatus;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCategory;
        private DevComponents.Editors.IntegerInput integerInput1;
        private DevComponents.Editors.DoubleInput doubleInput1;
        private Utils.DataBinding dataBindingIP;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ComboBoxItem cmbCustomerList;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private DevComponents.DotNetBar.LabelX labelX6;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ItemContainer icCustomerList;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator5;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.CheckBoxItem chkSameHolderAndInsured;
        private DevComponents.DotNetBar.Controls.GroupPanel grpInsuredRelation;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbRelation;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colRelationWithInsured;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colIdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCardNo;
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