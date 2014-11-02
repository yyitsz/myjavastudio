namespace SimpleCrm.CustomerForm
{
    partial class FollowUpRecordForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FollowUpRecordForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbCustomerClass = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cmbIntentPhaseCustomer = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbCustomerStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtCustomerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtIdCardNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.grdResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colEdit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.followUpRecordIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIntentPhase = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.nextFollowUpDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputtedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.followUpRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtContent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dtNextFollowDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtFollowDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmbIntentPhase = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dataBindingFollow = new SimpleCrm.Utils.DataBinding(this.components);
            this.superValidator = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("必填项");
            this.customValidator1 = new DevComponents.DotNetBar.Validator.CustomValidator();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("必填项");
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.dataBindingCustomer = new SimpleCrm.Utils.DataBinding(this.components);
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.followUpRecordBindingSource)).BeginInit();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNextFollowDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFollowDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingFollow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel1.Controls.Add(this.cmbCustomerClass);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.Controls.Add(this.cmbIntentPhaseCustomer);
            this.groupPanel1.Controls.Add(this.cmbCustomerStatus);
            this.groupPanel1.Controls.Add(this.labelX8);
            this.groupPanel1.Controls.Add(this.labelX9);
            this.groupPanel1.Controls.Add(this.txtCustomerName);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.txtIdCardNo);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(956, 81);
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
            this.groupPanel1.Text = "客户信息";
            // 
            // cmbCustomerClass
            // 
            this.cmbCustomerClass.DisplayMember = "Text";
            this.cmbCustomerClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCustomerClass.Enabled = false;
            this.dataBindingCustomer.SetFormatString(this.cmbCustomerClass, null);
            this.cmbCustomerClass.FormattingEnabled = true;
            this.cmbCustomerClass.ItemHeight = 15;
            this.cmbCustomerClass.Location = new System.Drawing.Point(99, 31);
            this.cmbCustomerClass.Name = "cmbCustomerClass";
            this.dataBindingCustomer.SetPropertyName(this.cmbCustomerClass, "CustomerClass");
            this.cmbCustomerClass.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomerClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerClass.TabIndex = 32;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(9, 31);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 21);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 31;
            this.labelX7.Text = "客户级别";
            // 
            // cmbIntentPhaseCustomer
            // 
            this.cmbIntentPhaseCustomer.DisplayMember = "Text";
            this.cmbIntentPhaseCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbIntentPhaseCustomer.Enabled = false;
            this.dataBindingCustomer.SetFormatString(this.cmbIntentPhaseCustomer, null);
            this.cmbIntentPhaseCustomer.FormattingEnabled = true;
            this.cmbIntentPhaseCustomer.ItemHeight = 15;
            this.cmbIntentPhaseCustomer.Location = new System.Drawing.Point(708, 4);
            this.cmbIntentPhaseCustomer.Name = "cmbIntentPhaseCustomer";
            this.dataBindingCustomer.SetPropertyName(this.cmbIntentPhaseCustomer, "IntentPhase");
            this.cmbIntentPhaseCustomer.Size = new System.Drawing.Size(121, 21);
            this.cmbIntentPhaseCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbIntentPhaseCustomer.TabIndex = 30;
            // 
            // cmbCustomerStatus
            // 
            this.cmbCustomerStatus.DisplayMember = "Text";
            this.cmbCustomerStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCustomerStatus.Enabled = false;
            this.dataBindingCustomer.SetFormatString(this.cmbCustomerStatus, null);
            this.cmbCustomerStatus.FormattingEnabled = true;
            this.cmbCustomerStatus.ItemHeight = 15;
            this.cmbCustomerStatus.Location = new System.Drawing.Point(315, 31);
            this.cmbCustomerStatus.Name = "cmbCustomerStatus";
            this.dataBindingCustomer.SetPropertyName(this.cmbCustomerStatus, "Status");
            this.cmbCustomerStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbCustomerStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCustomerStatus.TabIndex = 29;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(614, 4);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 21);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX8.TabIndex = 28;
            this.labelX8.Text = "跟进阶段";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(237, 31);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(64, 21);
            this.labelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX9.TabIndex = 27;
            this.labelX9.Text = "客户状态";
            // 
            // txtCustomerName
            // 
            // 
            // 
            // 
            this.txtCustomerName.Border.Class = "TextBoxBorder";
            this.txtCustomerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingCustomer.SetFormatString(this.txtCustomerName, null);
            this.txtCustomerName.Location = new System.Drawing.Point(99, 3);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.txtCustomerName, "CustomerName");
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(120, 21);
            this.txtCustomerName.TabIndex = 20;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(9, 3);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 21);
            this.labelX5.TabIndex = 17;
            this.labelX5.Text = "客户姓名";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(237, 3);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(64, 21);
            this.labelX6.TabIndex = 18;
            this.labelX6.Text = "证件号码";
            // 
            // txtIdCardNo
            // 
            // 
            // 
            // 
            this.txtIdCardNo.Border.Class = "TextBoxBorder";
            this.txtIdCardNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingCustomer.SetFormatString(this.txtIdCardNo, null);
            this.txtIdCardNo.Location = new System.Drawing.Point(315, 3);
            this.txtIdCardNo.Name = "txtIdCardNo";
            this.txtIdCardNo.PreventEnterBeep = true;
            this.dataBindingCustomer.SetPropertyName(this.txtIdCardNo, "IdCardNo");
            this.txtIdCardNo.ReadOnly = true;
            this.txtIdCardNo.Size = new System.Drawing.Size(249, 21);
            this.txtIdCardNo.TabIndex = 19;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel2.Controls.Add(this.grdResult);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 81);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(956, 239);
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
            this.groupPanel2.Text = "跟进记录";
            // 
            // grdResult
            // 
            this.grdResult.AllowUserToAddRows = false;
            this.grdResult.AllowUserToDeleteRows = false;
            this.grdResult.AutoGenerateColumns = false;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colDelete,
            this.followUpRecordIdDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.followDateDataGridViewTextBoxColumn,
            this.contentDataGridViewTextBoxColumn,
            this.colIntentPhase,
            this.nextFollowUpDateDataGridViewTextBoxColumn,
            this.inputDateDataGridViewTextBoxColumn,
            this.inputtedByDataGridViewTextBoxColumn,
            this.followedByDataGridViewTextBoxColumn,
            this.createTimeDataGridViewTextBoxColumn,
            this.updatedByDataGridViewTextBoxColumn,
            this.updateTimeDataGridViewTextBoxColumn,
            this.versionNoDataGridViewTextBoxColumn});
            this.grdResult.DataSource = this.followUpRecordBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdResult.Location = new System.Drawing.Point(0, 0);
            this.grdResult.Name = "grdResult";
            this.grdResult.RowTemplate.Height = 23;
            this.grdResult.Size = new System.Drawing.Size(950, 215);
            this.grdResult.TabIndex = 0;
            this.grdResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResult_CellContentClick);
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "";
            this.colEdit.Image = ((System.Drawing.Image)(resources.GetObject("colEdit.Image")));
            this.colEdit.MinimumWidth = 20;
            this.colEdit.Name = "colEdit";
            this.colEdit.Text = null;
            this.colEdit.Width = 20;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = ((System.Drawing.Image)(resources.GetObject("colDelete.Image")));
            this.colDelete.MinimumWidth = 20;
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = null;
            this.colDelete.Width = 20;
            // 
            // followUpRecordIdDataGridViewTextBoxColumn
            // 
            this.followUpRecordIdDataGridViewTextBoxColumn.DataPropertyName = "FollowUpRecordId";
            this.followUpRecordIdDataGridViewTextBoxColumn.HeaderText = "FollowUpRecordId";
            this.followUpRecordIdDataGridViewTextBoxColumn.Name = "followUpRecordIdDataGridViewTextBoxColumn";
            this.followUpRecordIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // followDateDataGridViewTextBoxColumn
            // 
            this.followDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.followDateDataGridViewTextBoxColumn.DataPropertyName = "FollowDate";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            this.followDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.followDateDataGridViewTextBoxColumn.HeaderText = "跟进日期";
            this.followDateDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.followDateDataGridViewTextBoxColumn.Name = "followDateDataGridViewTextBoxColumn";
            this.followDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "Content";
            this.contentDataGridViewTextBoxColumn.HeaderText = "跟进内容";
            this.contentDataGridViewTextBoxColumn.MinimumWidth = 500;
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            this.contentDataGridViewTextBoxColumn.ReadOnly = true;
            this.contentDataGridViewTextBoxColumn.Width = 500;
            // 
            // colIntentPhase
            // 
            this.colIntentPhase.DataPropertyName = "IntentPhase";
            this.colIntentPhase.DropDownHeight = 106;
            this.colIntentPhase.DropDownWidth = 121;
            this.colIntentPhase.Enabled = false;
            this.colIntentPhase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colIntentPhase.HeaderText = "跟进阶段";
            this.colIntentPhase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colIntentPhase.IntegralHeight = false;
            this.colIntentPhase.ItemHeight = 16;
            this.colIntentPhase.Name = "colIntentPhase";
            this.colIntentPhase.ReadOnly = true;
            this.colIntentPhase.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIntentPhase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // nextFollowUpDateDataGridViewTextBoxColumn
            // 
            this.nextFollowUpDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nextFollowUpDateDataGridViewTextBoxColumn.DataPropertyName = "NextFollowUpDate";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            this.nextFollowUpDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nextFollowUpDateDataGridViewTextBoxColumn.HeaderText = "下次跟进日期";
            this.nextFollowUpDateDataGridViewTextBoxColumn.MinimumWidth = 120;
            this.nextFollowUpDateDataGridViewTextBoxColumn.Name = "nextFollowUpDateDataGridViewTextBoxColumn";
            this.nextFollowUpDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.nextFollowUpDateDataGridViewTextBoxColumn.Width = 120;
            // 
            // inputDateDataGridViewTextBoxColumn
            // 
            this.inputDateDataGridViewTextBoxColumn.DataPropertyName = "InputDate";
            this.inputDateDataGridViewTextBoxColumn.HeaderText = "InputDate";
            this.inputDateDataGridViewTextBoxColumn.Name = "inputDateDataGridViewTextBoxColumn";
            this.inputDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // inputtedByDataGridViewTextBoxColumn
            // 
            this.inputtedByDataGridViewTextBoxColumn.DataPropertyName = "InputtedBy";
            this.inputtedByDataGridViewTextBoxColumn.HeaderText = "InputtedBy";
            this.inputtedByDataGridViewTextBoxColumn.Name = "inputtedByDataGridViewTextBoxColumn";
            this.inputtedByDataGridViewTextBoxColumn.Visible = false;
            // 
            // followedByDataGridViewTextBoxColumn
            // 
            this.followedByDataGridViewTextBoxColumn.DataPropertyName = "FollowedBy";
            this.followedByDataGridViewTextBoxColumn.HeaderText = "FollowedBy";
            this.followedByDataGridViewTextBoxColumn.Name = "followedByDataGridViewTextBoxColumn";
            this.followedByDataGridViewTextBoxColumn.Visible = false;
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
            // followUpRecordBindingSource
            // 
            this.followUpRecordBindingSource.DataSource = typeof(SimpleCrm.Model.FollowUpRecord);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.groupPanel3.Controls.Add(this.btnReset);
            this.groupPanel3.Controls.Add(this.btnClose);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.Controls.Add(this.txtContent);
            this.groupPanel3.Controls.Add(this.labelX2);
            this.groupPanel3.Controls.Add(this.dtNextFollowDate);
            this.groupPanel3.Controls.Add(this.labelX1);
            this.groupPanel3.Controls.Add(this.dtFollowDate);
            this.groupPanel3.Controls.Add(this.labelX4);
            this.groupPanel3.Controls.Add(this.cmbIntentPhase);
            this.groupPanel3.Controls.Add(this.labelX3);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(0, 320);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(956, 170);
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
            this.groupPanel3.Text = "跟进";
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(704, 116);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReset.TabIndex = 35;
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(785, 116);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(614, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtContent
            // 
            // 
            // 
            // 
            this.txtContent.Border.Class = "TextBoxBorder";
            this.txtContent.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dataBindingFollow.SetFormatString(this.txtContent, null);
            this.txtContent.Location = new System.Drawing.Point(99, 30);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.PreventEnterBeep = true;
            this.dataBindingFollow.SetPropertyName(this.txtContent, "Content");
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(761, 76);
            this.txtContent.TabIndex = 32;
            this.superValidator.SetValidator1(this.txtContent, this.requiredFieldValidator3);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(18, 30);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 21);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 31;
            this.labelX2.Text = "跟进内容";
            // 
            // dtNextFollowDate
            // 
            // 
            // 
            // 
            this.dtNextFollowDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtNextFollowDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNextFollowDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtNextFollowDate.ButtonDropDown.Visible = true;
            this.dtNextFollowDate.CustomFormat = "yyyy-MM-dd";
            this.dtNextFollowDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dataBindingFollow.SetFormatString(this.dtNextFollowDate, null);
            this.dtNextFollowDate.IsPopupCalendarOpen = false;
            this.dtNextFollowDate.Location = new System.Drawing.Point(585, 3);
            this.dtNextFollowDate.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtNextFollowDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtNextFollowDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtNextFollowDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNextFollowDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtNextFollowDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtNextFollowDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtNextFollowDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNextFollowDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtNextFollowDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtNextFollowDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtNextFollowDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtNextFollowDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNextFollowDate.MonthCalendar.DisplayMonth = new System.DateTime(2014, 10, 1, 0, 0, 0, 0);
            this.dtNextFollowDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtNextFollowDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtNextFollowDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtNextFollowDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNextFollowDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtNextFollowDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNextFollowDate.MonthCalendar.TodayButtonVisible = true;
            this.dtNextFollowDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtNextFollowDate.Name = "dtNextFollowDate";
            this.dataBindingFollow.SetPropertyName(this.dtNextFollowDate, "NextFollowUpDate");
            this.dtNextFollowDate.Size = new System.Drawing.Size(114, 21);
            this.dtNextFollowDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtNextFollowDate.TabIndex = 30;
            this.superValidator.SetValidator1(this.dtNextFollowDate, this.customValidator1);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(484, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(95, 21);
            this.labelX1.TabIndex = 29;
            this.labelX1.Text = "下次跟进日期";
            // 
            // dtFollowDate
            // 
            // 
            // 
            // 
            this.dtFollowDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtFollowDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFollowDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtFollowDate.ButtonDropDown.Visible = true;
            this.dtFollowDate.CustomFormat = "yyyy-MM-dd";
            this.dtFollowDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dataBindingFollow.SetFormatString(this.dtFollowDate, null);
            this.dtFollowDate.IsPopupCalendarOpen = false;
            this.dtFollowDate.Location = new System.Drawing.Point(99, 3);
            this.dtFollowDate.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtFollowDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtFollowDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtFollowDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFollowDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtFollowDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtFollowDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtFollowDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtFollowDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtFollowDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtFollowDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtFollowDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtFollowDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFollowDate.MonthCalendar.DisplayMonth = new System.DateTime(2014, 10, 1, 0, 0, 0, 0);
            this.dtFollowDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtFollowDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtFollowDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtFollowDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtFollowDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtFollowDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtFollowDate.MonthCalendar.TodayButtonVisible = true;
            this.dtFollowDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtFollowDate.Name = "dtFollowDate";
            this.dataBindingFollow.SetPropertyName(this.dtFollowDate, "FollowDate");
            this.dtFollowDate.Size = new System.Drawing.Size(111, 21);
            this.dtFollowDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtFollowDate.TabIndex = 28;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(18, 3);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 21);
            this.labelX4.TabIndex = 27;
            this.labelX4.Text = "跟进日期";
            // 
            // cmbIntentPhase
            // 
            this.cmbIntentPhase.DisplayMember = "Text";
            this.cmbIntentPhase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dataBindingFollow.SetFormatString(this.cmbIntentPhase, null);
            this.cmbIntentPhase.FormattingEnabled = true;
            this.cmbIntentPhase.ItemHeight = 15;
            this.cmbIntentPhase.Location = new System.Drawing.Point(331, 3);
            this.cmbIntentPhase.Name = "cmbIntentPhase";
            this.dataBindingFollow.SetPropertyName(this.cmbIntentPhase, "IntentPhase");
            this.cmbIntentPhase.Size = new System.Drawing.Size(121, 21);
            this.cmbIntentPhase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbIntentPhase.TabIndex = 26;
            this.superValidator.SetValidator1(this.cmbIntentPhase, this.requiredFieldValidator2);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(237, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 21);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 25;
            this.labelX3.Text = "跟进阶段";
            // 
            // dataBindingFollow
            // 
            this.dataBindingFollow.DateTimeFormat = "yyyy-MM-dd";
            // 
            // superValidator
            // 
            this.superValidator.ContainerControl = this;
            this.superValidator.ErrorProvider = this.errorProvider;
            this.superValidator.Highlighter = this.highlighter;
            this.superValidator.CustomValidatorValidateValue += new DevComponents.DotNetBar.Validator.ValidateValueEventHandler(this.superValidator_CustomValidatorValidateValue);
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "必填项";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // customValidator1
            // 
            this.customValidator1.ErrorMessage = "下次跟进日期必须大于跟进日期";
            this.customValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "必填项";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // dataBindingCustomer
            // 
            this.dataBindingCustomer.DateTimeFormat = "yyyy-MM-dd";
            // 
            // FollowUpRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 490);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.Name = "FollowUpRecordForm";
            this.Text = "跟进记录";
            this.Load += new System.EventHandler(this.FollowUpRecordForm_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.followUpRecordBindingSource)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtNextFollowDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFollowDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingFollow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdResult;
        private System.Windows.Forms.BindingSource followUpRecordBindingSource;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbIntentPhase;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtNextFollowDate;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtFollowDate;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtContent;
        private Utils.DataBinding dataBindingFollow;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCustomerName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIdCardNo;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerClass;
        private Utils.DataBinding dataBindingCustomer;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbIntentPhaseCustomer;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCustomerStatus;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colEdit;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn followUpRecordIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn followDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colIntentPhase;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextFollowUpDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputtedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn followedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionNoDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.Validator.CustomValidator customValidator1;

    }
}