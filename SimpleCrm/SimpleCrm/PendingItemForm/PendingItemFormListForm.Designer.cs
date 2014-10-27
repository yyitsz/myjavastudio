namespace SimpleCrm.PendingItemForm
{
    partial class PendingItemListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingItemListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.icHandleResult = new DevComponents.DotNetBar.ItemContainer();
            this.chkUnhandled = new DevComponents.DotNetBar.CheckBoxItem();
            this.chkHandled = new DevComponents.DotNetBar.CheckBoxItem();
            this.chkAll = new DevComponents.DotNetBar.CheckBoxItem();
            this.tabPending = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.grdTodayResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pendingItemDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tiToday = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.grdFutureResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colEdit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.pendingItemIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFutureCustomerName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colFutureInsurancePolicyNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFutureHandleResult = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.handleDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiFuture = new DevComponents.DotNetBar.TabItem(this.components);
            this.colTodayEdit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTodayCustomerName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTodayInsurancePolicyNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTodayHandleResult = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ribbonBarMergeContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPending)).BeginInit();
            this.tabPending.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTodayResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingItemDtoBindingSource)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFutureResult)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarMergeContainer1.Controls.Add(this.ribbonBar1);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(245, 158);
            this.ribbonBarMergeContainer1.Name = "ribbonBarMergeContainer1";
            this.ribbonBarMergeContainer1.RibbonTabText = "待办事项";
            this.ribbonBarMergeContainer1.Size = new System.Drawing.Size(415, 100);
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
            this.ribbonBarMergeContainer1.TabIndex = 1;
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
            this.btnRefresh,
            this.icHandleResult});
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(415, 100);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "ribbonBar1";
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
            // btnRefresh
            // 
            this.btnRefresh.BeginGroup = true;
            this.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefresh.Image = global::SimpleCrm.Properties.Resources.refresh;
            this.btnRefresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.SubItemsExpandWidth = 14;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // icHandleResult
            // 
            // 
            // 
            // 
            this.icHandleResult.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.icHandleResult.BeginGroup = true;
            this.icHandleResult.ItemSpacing = 2;
            this.icHandleResult.MultiLine = true;
            this.icHandleResult.Name = "icHandleResult";
            this.icHandleResult.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.chkUnhandled,
            this.chkHandled,
            this.chkAll});
            // 
            // 
            // 
            this.icHandleResult.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.icHandleResult.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // chkUnhandled
            // 
            this.chkUnhandled.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkUnhandled.Checked = true;
            this.chkUnhandled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnhandled.Name = "chkUnhandled";
            this.chkUnhandled.Text = "未处理";
            this.chkUnhandled.Click += new System.EventHandler(this.chkUnhandled_Click);
            // 
            // chkHandled
            // 
            this.chkHandled.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkHandled.Name = "chkHandled";
            this.chkHandled.Text = "已处理";
            this.chkHandled.Click += new System.EventHandler(this.chkUnhandled_Click);
            // 
            // chkAll
            // 
            this.chkAll.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkAll.Name = "chkAll";
            this.chkAll.Text = "所有";
            this.chkAll.Click += new System.EventHandler(this.chkUnhandled_Click);
            // 
            // tabPending
            // 
            this.tabPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabPending.CanReorderTabs = true;
            this.tabPending.Controls.Add(this.tabControlPanel2);
            this.tabPending.Controls.Add(this.tabControlPanel1);
            this.tabPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPending.Location = new System.Drawing.Point(0, 0);
            this.tabPending.Name = "tabPending";
            this.tabPending.SelectedTabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.tabPending.SelectedTabIndex = 1;
            this.tabPending.Size = new System.Drawing.Size(792, 405);
            this.tabPending.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabPending.TabIndex = 2;
            this.tabPending.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabPending.Tabs.Add(this.tiToday);
            this.tabPending.Tabs.Add(this.tiFuture);
            this.tabPending.Text = "tabControl1";
            this.tabPending.SelectedTabChanged += new DevComponents.DotNetBar.TabStrip.SelectedTabChangedEventHandler(this.tabPending_SelectedTabChanged);
            this.tabPending.SelectedTabChanging += new DevComponents.DotNetBar.TabStrip.SelectedTabChangingEventHandler(this.tabPending_SelectedTabChanging);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.grdTodayResult);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(792, 380);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tiToday;
            // 
            // grdTodayResult
            // 
            this.grdTodayResult.AllowUserToAddRows = false;
            this.grdTodayResult.AllowUserToDeleteRows = false;
            this.grdTodayResult.AutoGenerateColumns = false;
            this.grdTodayResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTodayResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTodayEdit,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.colTodayCustomerName,
            this.colTodayInsurancePolicyNo,
            this.dataGridViewTextBoxColumn6,
            this.colTodayHandleResult,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.grdTodayResult.DataSource = this.pendingItemDtoBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTodayResult.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdTodayResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTodayResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grdTodayResult.Location = new System.Drawing.Point(1, 1);
            this.grdTodayResult.Name = "grdTodayResult";
            this.grdTodayResult.ReadOnly = true;
            this.grdTodayResult.RowTemplate.Height = 23;
            this.grdTodayResult.Size = new System.Drawing.Size(790, 378);
            this.grdTodayResult.TabIndex = 2;
            this.grdTodayResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResult_CellContentClick);
            // 
            // pendingItemDtoBindingSource
            // 
            this.pendingItemDtoBindingSource.DataSource = typeof(SimpleCrm.DTO.PendingItemDto);
            // 
            // tiToday
            // 
            this.tiToday.AttachedControl = this.tabControlPanel1;
            this.tiToday.Name = "tiToday";
            this.tiToday.Text = "今天";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.grdFutureResult);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(792, 380);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tiFuture;
            // 
            // grdFutureResult
            // 
            this.grdFutureResult.AllowUserToAddRows = false;
            this.grdFutureResult.AllowUserToDeleteRows = false;
            this.grdFutureResult.AutoGenerateColumns = false;
            this.grdFutureResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFutureResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.pendingItemIdDataGridViewTextBoxColumn1,
            this.categoryDataGridViewTextBoxColumn1,
            this.refIdDataGridViewTextBoxColumn1,
            this.actionDateDataGridViewTextBoxColumn1,
            this.colFutureCustomerName,
            this.colFutureInsurancePolicyNo,
            this.contentDataGridViewTextBoxColumn1,
            this.colFutureHandleResult,
            this.handleDateDataGridViewTextBoxColumn1,
            this.remarkDataGridViewTextBoxColumn1,
            this.customerIdDataGridViewTextBoxColumn1});
            this.grdFutureResult.DataSource = this.pendingItemDtoBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFutureResult.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdFutureResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFutureResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grdFutureResult.Location = new System.Drawing.Point(1, 1);
            this.grdFutureResult.Name = "grdFutureResult";
            this.grdFutureResult.ReadOnly = true;
            this.grdFutureResult.RowTemplate.Height = 23;
            this.grdFutureResult.Size = new System.Drawing.Size(790, 378);
            this.grdFutureResult.TabIndex = 1;
            this.grdFutureResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResult_CellContentClick);
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEdit.HeaderText = "";
            this.colEdit.Image = ((System.Drawing.Image)(resources.GetObject("colEdit.Image")));
            this.colEdit.MinimumWidth = 20;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = null;
            this.colEdit.Width = 20;
            // 
            // pendingItemIdDataGridViewTextBoxColumn1
            // 
            this.pendingItemIdDataGridViewTextBoxColumn1.DataPropertyName = "PendingItemId";
            this.pendingItemIdDataGridViewTextBoxColumn1.HeaderText = "PendingItemId";
            this.pendingItemIdDataGridViewTextBoxColumn1.Name = "pendingItemIdDataGridViewTextBoxColumn1";
            this.pendingItemIdDataGridViewTextBoxColumn1.ReadOnly = true;
            this.pendingItemIdDataGridViewTextBoxColumn1.Visible = false;
            // 
            // categoryDataGridViewTextBoxColumn1
            // 
            this.categoryDataGridViewTextBoxColumn1.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn1.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn1.Name = "categoryDataGridViewTextBoxColumn1";
            this.categoryDataGridViewTextBoxColumn1.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn1.Visible = false;
            // 
            // refIdDataGridViewTextBoxColumn1
            // 
            this.refIdDataGridViewTextBoxColumn1.DataPropertyName = "RefId";
            this.refIdDataGridViewTextBoxColumn1.HeaderText = "RefId";
            this.refIdDataGridViewTextBoxColumn1.Name = "refIdDataGridViewTextBoxColumn1";
            this.refIdDataGridViewTextBoxColumn1.ReadOnly = true;
            this.refIdDataGridViewTextBoxColumn1.Visible = false;
            // 
            // actionDateDataGridViewTextBoxColumn1
            // 
            this.actionDateDataGridViewTextBoxColumn1.DataPropertyName = "ActionDate";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.actionDateDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.actionDateDataGridViewTextBoxColumn1.HeaderText = "发生日期";
            this.actionDateDataGridViewTextBoxColumn1.Name = "actionDateDataGridViewTextBoxColumn1";
            this.actionDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // colFutureCustomerName
            // 
            this.colFutureCustomerName.DataPropertyName = "CustomerName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Aquamarine;
            this.colFutureCustomerName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFutureCustomerName.HeaderText = "客户姓名";
            this.colFutureCustomerName.Name = "colFutureCustomerName";
            this.colFutureCustomerName.ReadOnly = true;
            this.colFutureCustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFutureCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colFutureInsurancePolicyNo
            // 
            this.colFutureInsurancePolicyNo.DataPropertyName = "InsurancePolicyNo";
            this.colFutureInsurancePolicyNo.HeaderText = "保单";
            this.colFutureInsurancePolicyNo.Name = "colFutureInsurancePolicyNo";
            this.colFutureInsurancePolicyNo.ReadOnly = true;
            // 
            // contentDataGridViewTextBoxColumn1
            // 
            this.contentDataGridViewTextBoxColumn1.DataPropertyName = "Content";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Aquamarine;
            this.contentDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.contentDataGridViewTextBoxColumn1.HeaderText = "提醒内容";
            this.contentDataGridViewTextBoxColumn1.Name = "contentDataGridViewTextBoxColumn1";
            this.contentDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // colFutureHandleResult
            // 
            this.colFutureHandleResult.DataPropertyName = "HandleResult";
            this.colFutureHandleResult.DropDownHeight = 106;
            this.colFutureHandleResult.DropDownWidth = 121;
            this.colFutureHandleResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colFutureHandleResult.HeaderText = "处理结果";
            this.colFutureHandleResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colFutureHandleResult.IntegralHeight = false;
            this.colFutureHandleResult.ItemHeight = 16;
            this.colFutureHandleResult.Name = "colFutureHandleResult";
            this.colFutureHandleResult.ReadOnly = true;
            this.colFutureHandleResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFutureHandleResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // handleDateDataGridViewTextBoxColumn1
            // 
            this.handleDateDataGridViewTextBoxColumn1.DataPropertyName = "HandleDate";
            dataGridViewCellStyle4.Format = "d";
            this.handleDateDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.handleDateDataGridViewTextBoxColumn1.HeaderText = "处理日期";
            this.handleDateDataGridViewTextBoxColumn1.Name = "handleDateDataGridViewTextBoxColumn1";
            this.handleDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn1
            // 
            this.remarkDataGridViewTextBoxColumn1.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn1.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn1.Name = "remarkDataGridViewTextBoxColumn1";
            this.remarkDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // customerIdDataGridViewTextBoxColumn1
            // 
            this.customerIdDataGridViewTextBoxColumn1.DataPropertyName = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn1.HeaderText = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn1.Name = "customerIdDataGridViewTextBoxColumn1";
            this.customerIdDataGridViewTextBoxColumn1.ReadOnly = true;
            this.customerIdDataGridViewTextBoxColumn1.Visible = false;
            // 
            // tiFuture
            // 
            this.tiFuture.AttachedControl = this.tabControlPanel2;
            this.tiFuture.Name = "tiFuture";
            this.tiFuture.Text = "未来1个月";
            // 
            // colTodayEdit
            // 
            this.colTodayEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTodayEdit.HeaderText = "";
            this.colTodayEdit.Image = ((System.Drawing.Image)(resources.GetObject("colTodayEdit.Image")));
            this.colTodayEdit.MinimumWidth = 20;
            this.colTodayEdit.Name = "colTodayEdit";
            this.colTodayEdit.ReadOnly = true;
            this.colTodayEdit.Text = null;
            this.colTodayEdit.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PendingItemId";
            this.dataGridViewTextBoxColumn1.HeaderText = "PendingItemId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Category";
            this.dataGridViewTextBoxColumn2.HeaderText = "Category";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RefId";
            this.dataGridViewTextBoxColumn3.HeaderText = "RefId";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ActionDate";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.HeaderText = "发生日期";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // colTodayCustomerName
            // 
            this.colTodayCustomerName.DataPropertyName = "CustomerName";
            this.colTodayCustomerName.HeaderText = "客户姓名";
            this.colTodayCustomerName.Name = "colTodayCustomerName";
            this.colTodayCustomerName.ReadOnly = true;
            // 
            // colTodayInsurancePolicyNo
            // 
            this.colTodayInsurancePolicyNo.DataPropertyName = "InsurancePolicyNo";
            this.colTodayInsurancePolicyNo.HeaderText = "保单";
            this.colTodayInsurancePolicyNo.Name = "colTodayInsurancePolicyNo";
            this.colTodayInsurancePolicyNo.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Content";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Aquamarine;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn6.HeaderText = "提醒内容";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // colTodayHandleResult
            // 
            this.colTodayHandleResult.DataPropertyName = "HandleResult";
            this.colTodayHandleResult.DropDownHeight = 106;
            this.colTodayHandleResult.DropDownWidth = 121;
            this.colTodayHandleResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colTodayHandleResult.HeaderText = "处理结果";
            this.colTodayHandleResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colTodayHandleResult.IntegralHeight = false;
            this.colTodayHandleResult.ItemHeight = 16;
            this.colTodayHandleResult.Name = "colTodayHandleResult";
            this.colTodayHandleResult.ReadOnly = true;
            this.colTodayHandleResult.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTodayHandleResult.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "HandleDate";
            dataGridViewCellStyle8.Format = "d";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn8.HeaderText = "处理日期";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn9.HeaderText = "备注";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "CustomerId";
            this.dataGridViewTextBoxColumn10.HeaderText = "CustomerId";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // PendingItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 405);
            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Controls.Add(this.tabPending);
            this.Name = "PendingItemListForm";
            this.Text = "提醒列表";
            this.Load += new System.EventHandler(this.CustomerMainForm_Load);
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPending)).EndInit();
            this.tabPending.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTodayResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingItemDtoBindingSource)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFutureResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.TabControl tabPending;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdFutureResult;
        private DevComponents.DotNetBar.TabItem tiFuture;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tiToday;
        private System.Windows.Forms.BindingSource pendingItemDtoBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdTodayResult;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendingItemIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn refIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn colFutureCustomerName;
        private System.Windows.Forms.DataGridViewLinkColumn colFutureInsurancePolicyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn1;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colFutureHandleResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn handleDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn1;
        private DevComponents.DotNetBar.ItemContainer icHandleResult;
        private DevComponents.DotNetBar.CheckBoxItem chkUnhandled;
        private DevComponents.DotNetBar.CheckBoxItem chkHandled;
        private DevComponents.DotNetBar.CheckBoxItem chkAll;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colTodayEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewLinkColumn colTodayCustomerName;
        private System.Windows.Forms.DataGridViewLinkColumn colTodayInsurancePolicyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colTodayHandleResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;


    }
}
