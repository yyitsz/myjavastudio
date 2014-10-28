namespace SimpleCrm.CustomerForm
{
    partial class CustomerPickListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.cmbCustomerSource = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cmbCustomerClass = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmbIntentPhase = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbCustomerStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.grdResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.idCardNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.birthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colCustomerClass = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colCustomerSource = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colIntentPhase = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.customerSearchResultDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataBindingParam = new SimpleCrm.Utils.DataBinding(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerSearchResultDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingParam)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelEx1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdResult);
            this.splitContainer1.Size = new System.Drawing.Size(792, 405);
            this.splitContainer1.SplitterDistance = 139;
            this.splitContainer1.TabIndex = 0;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.textBoxX1);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.btnReset);
            this.panelEx1.Controls.Add(this.btnSearch);
            this.panelEx1.Controls.Add(this.cmbCustomerSource);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.cmbCustomerClass);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.cmbIntentPhase);
            this.panelEx1.Controls.Add(this.cmbCustomerStatus);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.txtUserName);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(792, 139);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingParam.SetFormatString(this.textBoxX1, null);
            this.textBoxX1.Location = new System.Drawing.Point(115, 66);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.dataBindingParam.SetPropertyName(this.textBoxX1, "IdCardNo");
            this.textBoxX1.Size = new System.Drawing.Size(121, 21);
            this.textBoxX1.TabIndex = 40;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(12, 66);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 21);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 39;
            this.labelX6.Text = "证件号码";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(689, 92);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 38;
            this.btnReset.Text = "重置(&R)";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(596, 92);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = "查询(&S)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbCustomerSource
            // 
            this.cmbCustomerSource.DisplayMember = "Text";
            this.cmbCustomerSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingParam.SetFormatString(this.cmbCustomerSource, null);
            this.cmbCustomerSource.FormattingEnabled = true;
            this.cmbCustomerSource.ItemHeight = 15;
            this.cmbCustomerSource.Location = new System.Drawing.Point(387, 39);
            this.cmbCustomerSource.Name = "cmbCustomerSource";
            this.dataBindingParam.SetPropertyName(this.cmbCustomerSource, "CustomerSource");
            this.cmbCustomerSource.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomerSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerSource.TabIndex = 36;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(274, 39);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 21);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 35;
            this.labelX5.Text = "客户来源";
            // 
            // cmbCustomerClass
            // 
            this.cmbCustomerClass.DisplayMember = "Text";
            this.cmbCustomerClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingParam.SetFormatString(this.cmbCustomerClass, null);
            this.cmbCustomerClass.FormattingEnabled = true;
            this.cmbCustomerClass.ItemHeight = 15;
            this.cmbCustomerClass.Location = new System.Drawing.Point(115, 39);
            this.cmbCustomerClass.Name = "cmbCustomerClass";
            this.dataBindingParam.SetPropertyName(this.cmbCustomerClass, "CustomerClass");
            this.cmbCustomerClass.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomerClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerClass.TabIndex = 34;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(12, 39);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 21);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 33;
            this.labelX4.Text = "客户级别";
            // 
            // cmbIntentPhase
            // 
            this.cmbIntentPhase.DisplayMember = "Text";
            this.cmbIntentPhase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingParam.SetFormatString(this.cmbIntentPhase, null);
            this.cmbIntentPhase.FormattingEnabled = true;
            this.cmbIntentPhase.ItemHeight = 15;
            this.cmbIntentPhase.Location = new System.Drawing.Point(657, 12);
            this.cmbIntentPhase.Name = "cmbIntentPhase";
            this.dataBindingParam.SetPropertyName(this.cmbIntentPhase, "IntentPhase");
            this.cmbIntentPhase.Size = new System.Drawing.Size(121, 21);
            this.cmbIntentPhase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbIntentPhase.TabIndex = 32;
            // 
            // cmbCustomerStatus
            // 
            this.cmbCustomerStatus.DisplayMember = "Text";
            this.cmbCustomerStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingParam.SetFormatString(this.cmbCustomerStatus, null);
            this.cmbCustomerStatus.FormattingEnabled = true;
            this.cmbCustomerStatus.ItemHeight = 15;
            this.cmbCustomerStatus.Location = new System.Drawing.Point(387, 12);
            this.cmbCustomerStatus.Name = "cmbCustomerStatus";
            this.dataBindingParam.SetPropertyName(this.cmbCustomerStatus, "Status");
            this.cmbCustomerStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomerStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerStatus.TabIndex = 31;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(563, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 21);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 30;
            this.labelX3.Text = "跟进阶段";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(274, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 21);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 29;
            this.labelX2.Text = "客户状态";
            // 
            // txtUserName
            // 
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingParam.SetFormatString(this.txtUserName, null);
            this.txtUserName.Location = new System.Drawing.Point(115, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PreventEnterBeep = true;
            this.dataBindingParam.SetPropertyName(this.txtUserName, "CustomerName");
            this.txtUserName.Size = new System.Drawing.Size(121, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 21);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "客户姓名";
            // 
            // grdResult
            // 
            this.grdResult.AllowUserToAddRows = false;
            this.grdResult.AllowUserToDeleteRows = false;
            this.grdResult.AutoGenerateColumns = false;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIdDataGridViewTextBoxColumn,
            this.colCustomerName,
            this.idCardNoDataGridViewTextBoxColumn,
            this.colGender,
            this.birthdayDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.colStatus,
            this.colCustomerClass,
            this.colCustomerSource,
            this.colIntentPhase});
            this.grdResult.DataSource = this.customerSearchResultDtoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdResult.Location = new System.Drawing.Point(0, 0);
            this.grdResult.Name = "grdResult";
            this.grdResult.RowTemplate.Height = 23;
            this.grdResult.Size = new System.Drawing.Size(792, 262);
            this.grdResult.TabIndex = 0;
            this.grdResult.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdResult_RowHeaderMouseDoubleClick);
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
            this.colCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCustomerName.DataPropertyName = "CustomerName";
            this.colCustomerName.HeaderText = "客户姓名";
            this.colCustomerName.MinimumWidth = 50;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            this.colCustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCustomerName.Width = 61;
            // 
            // idCardNoDataGridViewTextBoxColumn
            // 
            this.idCardNoDataGridViewTextBoxColumn.DataPropertyName = "IdCardNo";
            this.idCardNoDataGridViewTextBoxColumn.HeaderText = "证件号码";
            this.idCardNoDataGridViewTextBoxColumn.Name = "idCardNoDataGridViewTextBoxColumn";
            this.idCardNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colGender
            // 
            this.colGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colGender.DataPropertyName = "Gender";
            this.colGender.DropDownHeight = 106;
            this.colGender.DropDownWidth = 121;
            this.colGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colGender.HeaderText = "性别 ";
            this.colGender.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colGender.IntegralHeight = false;
            this.colGender.ItemHeight = 16;
            this.colGender.MinimumWidth = 20;
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            this.colGender.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGender.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colGender.Width = 45;
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            this.birthdayDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            this.birthdayDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.birthdayDataGridViewTextBoxColumn.HeaderText = "出生日期";
            this.birthdayDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            this.birthdayDataGridViewTextBoxColumn.ReadOnly = true;
            this.birthdayDataGridViewTextBoxColumn.Width = 61;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "单位";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            this.unitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.DropDownHeight = 106;
            this.colStatus.DropDownWidth = 121;
            this.colStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colStatus.HeaderText = "客户状态";
            this.colStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colStatus.IntegralHeight = false;
            this.colStatus.ItemHeight = 16;
            this.colStatus.MinimumWidth = 30;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colStatus.Width = 61;
            // 
            // colCustomerClass
            // 
            this.colCustomerClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colCustomerClass.DataPropertyName = "CustomerClass";
            this.colCustomerClass.DropDownHeight = 106;
            this.colCustomerClass.DropDownWidth = 121;
            this.colCustomerClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCustomerClass.HeaderText = "客户级别";
            this.colCustomerClass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colCustomerClass.IntegralHeight = false;
            this.colCustomerClass.ItemHeight = 16;
            this.colCustomerClass.MinimumWidth = 30;
            this.colCustomerClass.Name = "colCustomerClass";
            this.colCustomerClass.ReadOnly = true;
            this.colCustomerClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCustomerClass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colCustomerClass.Width = 61;
            // 
            // colCustomerSource
            // 
            this.colCustomerSource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colCustomerSource.DataPropertyName = "CustomerSource";
            this.colCustomerSource.DropDownHeight = 106;
            this.colCustomerSource.DropDownWidth = 121;
            this.colCustomerSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCustomerSource.HeaderText = "客户来源";
            this.colCustomerSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colCustomerSource.IntegralHeight = false;
            this.colCustomerSource.ItemHeight = 16;
            this.colCustomerSource.MinimumWidth = 30;
            this.colCustomerSource.Name = "colCustomerSource";
            this.colCustomerSource.ReadOnly = true;
            this.colCustomerSource.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCustomerSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colCustomerSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colCustomerSource.Width = 61;
            // 
            // colIntentPhase
            // 
            this.colIntentPhase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIntentPhase.DataPropertyName = "IntentPhase";
            this.colIntentPhase.DropDownHeight = 106;
            this.colIntentPhase.DropDownWidth = 121;
            this.colIntentPhase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colIntentPhase.HeaderText = "当前跟进阶段";
            this.colIntentPhase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colIntentPhase.IntegralHeight = false;
            this.colIntentPhase.ItemHeight = 16;
            this.colIntentPhase.MinimumWidth = 30;
            this.colIntentPhase.Name = "colIntentPhase";
            this.colIntentPhase.ReadOnly = true;
            this.colIntentPhase.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIntentPhase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colIntentPhase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colIntentPhase.Width = 72;
            // 
            // customerSearchResultDtoBindingSource
            // 
            this.customerSearchResultDtoBindingSource.DataSource = typeof(SimpleCrm.DTO.CustomerSearchResultDto);
            // 
            // dataBindingParam
            // 
            this.dataBindingParam.DateTimeFormat = "yyyy-MM-dd";
            // 
            // CustomerPickListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 405);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "CustomerPickListForm";
            this.Text = "客户选择";
            this.Load += new System.EventHandler(this.CustomerMainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerSearchResultDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingParam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdResult;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
        private System.Windows.Forms.BindingSource customerSearchResultDtoBindingSource;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerSource;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerClass;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbIntentPhase;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerStatus;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private Utils.DataBinding dataBindingParam;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCardNoDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colStatus;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colCustomerClass;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colCustomerSource;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colIntentPhase;


    }
}
