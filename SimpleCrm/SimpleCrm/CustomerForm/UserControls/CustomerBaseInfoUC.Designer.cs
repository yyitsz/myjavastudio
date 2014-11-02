namespace SimpleCrm.CustomerForm.UserControls
{
    partial class CustomerBaseInfoUC
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

        #region Component Designer generated code

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerBaseInfoUC));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtIdCardNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dtBirthday = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtUnit = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtPosition = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtCustomerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbGender = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbIdType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.grdContactInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colDel = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.contactInfoIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactType = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colContactMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.remarkDataGridViewTextBoxColumn = new DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewButtonXColumn1 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.dataBindingCustomer = new SimpleCrm.Utils.DataBinding(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthday)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContactInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 21);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "姓名";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(3, 35);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(34, 21);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "性别";
            // 
            // txtIdCardNo
            // 
            // 
            // 
            // 
            this.txtIdCardNo.Border.Class = "TextBoxBorder";
            this.txtIdCardNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingCustomer.SetFormatString(this.txtIdCardNo, null);
            this.highlighter.SetHighlightOnFocus(this.txtIdCardNo, true);
            this.txtIdCardNo.Location = new System.Drawing.Point(521, 5);
            this.txtIdCardNo.Name = "txtIdCardNo";
            this.txtIdCardNo.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.txtIdCardNo, "IdCardNo");
            this.txtIdCardNo.Size = new System.Drawing.Size(262, 21);
            this.txtIdCardNo.TabIndex = 2;
            this.txtIdCardNo.Leave += new System.EventHandler(this.txtIdCardNo_Leave);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(430, 5);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 21);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "证件号码";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(214, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 21);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 8;
            this.labelX4.Text = "出生日期";
            // 
            // dtBirthday
            // 
            // 
            // 
            // 
            this.dtBirthday.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtBirthday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBirthday.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtBirthday.ButtonDropDown.Visible = true;
            this.dtBirthday.CustomFormat = "yyyy-MM-dd";
            this.dtBirthday.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dataBindingCustomer.SetFormatString(this.dtBirthday, null);
            this.highlighter.SetHighlightOnFocus(this.dtBirthday, true);
            this.dtBirthday.IsPopupCalendarOpen = false;
            this.dtBirthday.Location = new System.Drawing.Point(295, 35);
            this.dtBirthday.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtBirthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtBirthday.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtBirthday.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBirthday.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtBirthday.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtBirthday.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtBirthday.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtBirthday.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtBirthday.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtBirthday.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtBirthday.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtBirthday.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBirthday.MonthCalendar.DisplayMonth = new System.DateTime(2014, 10, 1, 0, 0, 0, 0);
            this.dtBirthday.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtBirthday.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtBirthday.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtBirthday.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtBirthday.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtBirthday.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBirthday.MonthCalendar.TodayButtonVisible = true;
            this.dtBirthday.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtBirthday.Name = "dtBirthday";
            this.dataBindingCustomer.SetPropertyName(this.dtBirthday, "Birthday");
            this.dtBirthday.Size = new System.Drawing.Size(112, 21);
            this.dtBirthday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtBirthday.TabIndex = 4;
            // 
            // txtUnit
            // 
            // 
            // 
            // 
            this.txtUnit.Border.Class = "TextBoxBorder";
            this.txtUnit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingCustomer.SetFormatString(this.txtUnit, null);
            this.highlighter.SetHighlightOnFocus(this.txtUnit, true);
            this.txtUnit.Location = new System.Drawing.Point(84, 62);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.txtUnit, "Unit");
            this.txtUnit.Size = new System.Drawing.Size(279, 21);
            this.txtUnit.TabIndex = 5;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(3, 62);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 21);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 10;
            this.labelX5.Text = "单位";
            // 
            // txtPosition
            // 
            // 
            // 
            // 
            this.txtPosition.Border.Class = "TextBoxBorder";
            this.txtPosition.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingCustomer.SetFormatString(this.txtPosition, null);
            this.highlighter.SetHighlightOnFocus(this.txtPosition, true);
            this.txtPosition.Location = new System.Drawing.Point(481, 62);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.txtPosition, "Position");
            this.txtPosition.Size = new System.Drawing.Size(112, 21);
            this.txtPosition.TabIndex = 6;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(400, 62);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 21);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 12;
            this.labelX6.Text = "职位";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel1.Controls.Add(this.txtCustomerName);
            this.groupPanel1.Controls.Add(this.cmbGender);
            this.groupPanel1.Controls.Add(this.cmbIdType);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.txtPosition);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.txtUnit);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.dtBirthday);
            this.groupPanel1.Controls.Add(this.txtIdCardNo);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(814, 124);
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
            this.groupPanel1.TabIndex = 14;
            this.groupPanel1.Text = "基本信息";
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.Border.Class = "TextBoxBorder";
            this.txtCustomerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingCustomer.SetFormatString(this.txtCustomerName, null);
            this.highlighter.SetHighlightOnFocus(this.txtCustomerName, true);
            this.txtCustomerName.Location = new System.Drawing.Point(84, 3);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.txtCustomerName, "CustomerName");
            this.txtCustomerName.Size = new System.Drawing.Size(112, 21);
            this.txtCustomerName.TabIndex = 0;
            // 
            // cmbGender
            // 
            this.cmbGender.DisplayMember = "Text";
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingCustomer.SetFormatString(this.cmbGender, null);
            this.cmbGender.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.cmbGender, true);
            this.cmbGender.ItemHeight = 15;
            this.cmbGender.Location = new System.Drawing.Point(84, 35);
            this.cmbGender.Name = "cmbGender";
            this.dataBindingCustomer.SetPropertyName(this.cmbGender, "Gender");
            this.cmbGender.Size = new System.Drawing.Size(59, 21);
            this.cmbGender.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbGender.TabIndex = 3;
            // 
            // cmbIdType
            // 
            this.cmbIdType.DisplayMember = "Text";
            this.cmbIdType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingCustomer.SetFormatString(this.cmbIdType, null);
            this.cmbIdType.FormattingEnabled = true;
            this.highlighter.SetHighlightOnFocus(this.cmbIdType, true);
            this.cmbIdType.ItemHeight = 15;
            this.cmbIdType.Location = new System.Drawing.Point(295, 5);
            this.cmbIdType.Name = "cmbIdType";
            this.dataBindingCustomer.SetPropertyName(this.cmbIdType, "IdType");
            this.cmbIdType.Size = new System.Drawing.Size(112, 21);
            this.cmbIdType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbIdType.TabIndex = 1;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(214, 5);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 21);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 14;
            this.labelX7.Text = "证件类别";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel2.Controls.Add(this.grdContactInfo);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 124);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(814, 207);
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
            this.groupPanel2.TabIndex = 15;
            this.groupPanel2.Text = "联系方式";
            // 
            // grdContactInfo
            // 
            this.grdContactInfo.AutoGenerateColumns = false;
            this.grdContactInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdContactInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdContactInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContactInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDel,
            this.contactInfoIdDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.colContactType,
            this.colContactMethod,
            this.isActiveDataGridViewCheckBoxColumn,
            this.remarkDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.createTimeDataGridViewTextBoxColumn,
            this.updatedByDataGridViewTextBoxColumn,
            this.updateTimeDataGridViewTextBoxColumn,
            this.versionNoDataGridViewTextBoxColumn});
            this.grdContactInfo.DataSource = this.contactInfoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdContactInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdContactInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContactInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdContactInfo.EnableHeadersVisualStyles = false;
            this.grdContactInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdContactInfo.Location = new System.Drawing.Point(0, 0);
            this.grdContactInfo.Name = "grdContactInfo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdContactInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdContactInfo.RowTemplate.Height = 23;
            this.grdContactInfo.Size = new System.Drawing.Size(808, 183);
            this.grdContactInfo.TabIndex = 0;
            this.grdContactInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdContactInfo_CellContentClick);
            // 
            // colDel
            // 
            this.colDel.HeaderText = "";
            this.colDel.Image = ((System.Drawing.Image)(resources.GetObject("colDel.Image")));
            this.colDel.MinimumWidth = 20;
            this.colDel.Name = "colDel";
            this.colDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colDel.Text = null;
            this.colDel.ToolTipText = "Delete";
            this.colDel.Width = 22;
            // 
            // contactInfoIdDataGridViewTextBoxColumn
            // 
            this.contactInfoIdDataGridViewTextBoxColumn.DataPropertyName = "ContactInfoId";
            this.contactInfoIdDataGridViewTextBoxColumn.HeaderText = "ContactInfoId";
            this.contactInfoIdDataGridViewTextBoxColumn.Name = "contactInfoIdDataGridViewTextBoxColumn";
            this.contactInfoIdDataGridViewTextBoxColumn.Visible = false;
            this.contactInfoIdDataGridViewTextBoxColumn.Width = 108;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.Visible = false;
            this.customerIdDataGridViewTextBoxColumn.Width = 90;
            // 
            // colContactType
            // 
            this.colContactType.DataPropertyName = "ContactType";
            this.colContactType.DisplayMember = "Text";
            this.colContactType.DropDownHeight = 106;
            this.colContactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colContactType.DropDownWidth = 121;
            this.colContactType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colContactType.HeaderText = "联系方式类别";
            this.colContactType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colContactType.IntegralHeight = false;
            this.colContactType.ItemHeight = 16;
            this.colContactType.MinimumWidth = 150;
            this.colContactType.Name = "colContactType";
            this.colContactType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colContactType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colContactType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colContactType.Width = 150;
            // 
            // colContactMethod
            // 
            this.colContactMethod.DataPropertyName = "ContactMethod";
            this.colContactMethod.HeaderText = "联系方式";
            this.colContactMethod.MaxInputLength = 200;
            this.colContactMethod.MinimumWidth = 200;
            this.colContactMethod.Name = "colContactMethod";
            this.colContactMethod.Width = 200;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.Checked = true;
            this.isActiveDataGridViewCheckBoxColumn.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.isActiveDataGridViewCheckBoxColumn.CheckValue = null;
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "是否有效?";
            this.isActiveDataGridViewCheckBoxColumn.MinimumWidth = 70;
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            this.isActiveDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isActiveDataGridViewCheckBoxColumn.Width = 70;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.remarkDataGridViewTextBoxColumn.BackgroundStyle.Class = "DataGridViewIpAddressBorder";
            this.remarkDataGridViewTextBoxColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.remarkDataGridViewTextBoxColumn.MinimumWidth = 400;
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.PasswordChar = '\0';
            this.remarkDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.remarkDataGridViewTextBoxColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.remarkDataGridViewTextBoxColumn.Text = "";
            this.remarkDataGridViewTextBoxColumn.Width = 400;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.Visible = false;
            this.customerDataGridViewTextBoxColumn.Width = 78;
            // 
            // createTimeDataGridViewTextBoxColumn
            // 
            this.createTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.HeaderText = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.Name = "createTimeDataGridViewTextBoxColumn";
            this.createTimeDataGridViewTextBoxColumn.Visible = false;
            this.createTimeDataGridViewTextBoxColumn.Width = 90;
            // 
            // updatedByDataGridViewTextBoxColumn
            // 
            this.updatedByDataGridViewTextBoxColumn.DataPropertyName = "UpdatedBy";
            this.updatedByDataGridViewTextBoxColumn.HeaderText = "UpdatedBy";
            this.updatedByDataGridViewTextBoxColumn.Name = "updatedByDataGridViewTextBoxColumn";
            this.updatedByDataGridViewTextBoxColumn.Visible = false;
            this.updatedByDataGridViewTextBoxColumn.Width = 84;
            // 
            // updateTimeDataGridViewTextBoxColumn
            // 
            this.updateTimeDataGridViewTextBoxColumn.DataPropertyName = "UpdateTime";
            this.updateTimeDataGridViewTextBoxColumn.HeaderText = "UpdateTime";
            this.updateTimeDataGridViewTextBoxColumn.Name = "updateTimeDataGridViewTextBoxColumn";
            this.updateTimeDataGridViewTextBoxColumn.Visible = false;
            this.updateTimeDataGridViewTextBoxColumn.Width = 90;
            // 
            // versionNoDataGridViewTextBoxColumn
            // 
            this.versionNoDataGridViewTextBoxColumn.DataPropertyName = "VersionNo";
            this.versionNoDataGridViewTextBoxColumn.HeaderText = "VersionNo";
            this.versionNoDataGridViewTextBoxColumn.Name = "versionNoDataGridViewTextBoxColumn";
            this.versionNoDataGridViewTextBoxColumn.Visible = false;
            this.versionNoDataGridViewTextBoxColumn.Width = 84;
            // 
            // contactInfoBindingSource
            // 
            this.contactInfoBindingSource.DataSource = typeof(SimpleCrm.Model.ContactInfo);
            // 
            // dataGridViewButtonXColumn1
            // 
            this.dataGridViewButtonXColumn1.HeaderText = "";
            this.dataGridViewButtonXColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewButtonXColumn1.Image")));
            this.dataGridViewButtonXColumn1.MinimumWidth = 20;
            this.dataGridViewButtonXColumn1.Name = "dataGridViewButtonXColumn1";
            this.dataGridViewButtonXColumn1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dataGridViewButtonXColumn1.Text = null;
            this.dataGridViewButtonXColumn1.ToolTipText = "Delete";
            this.dataGridViewButtonXColumn1.Width = 22;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // dataBindingCustomer
            // 
            this.dataBindingCustomer.DateTimeFormat = "yyyy-MM-dd";
            // 
            // CustomerBaseInfoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "CustomerBaseInfoUC";
            this.Size = new System.Drawing.Size(814, 331);
            this.Load += new System.EventHandler(this.CustomerBaseInfoUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtBirthday)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContactInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdCardNo;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtBirthday;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUnit;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPosition;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdContactInfo;
        private System.Windows.Forms.BindingSource contactInfoBindingSource;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbIdType;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbGender;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn dataGridViewButtonXColumn1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactInfoIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colContactType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactMethod;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn isActiveDataGridViewCheckBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionNoDataGridViewTextBoxColumn;
        private Utils.DataBinding dataBindingCustomer;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerName;
    }
}
