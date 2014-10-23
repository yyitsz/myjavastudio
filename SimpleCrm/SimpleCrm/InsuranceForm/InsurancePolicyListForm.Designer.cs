namespace SimpleCrm.InsuranceForm
{
    partial class InsurancePolicyListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsurancePolicyListForm));
            this.grdResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.insurancePolicyResultDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.colEdit = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.insurancePolicyIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsurancePolicyNo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPolicyHolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsuredName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effectiveDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insuredYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.premiumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colStatus = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insurancePolicyResultDtoBindingSource)).BeginInit();
            this.ribbonBarMergeContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.insurancePolicyIdDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.colInsurancePolicyNo,
            this.colCustomerName,
            this.colPolicyHolderName,
            this.colInsuredName,
            this.effectiveDateDataGridViewTextBoxColumn,
            this.insuredYearDataGridViewTextBoxColumn,
            this.premiumDataGridViewTextBoxColumn,
            this.colCategory,
            this.colStatus});
            this.grdResult.DataSource = this.insurancePolicyResultDtoBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdResult.Location = new System.Drawing.Point(0, 0);
            this.grdResult.Name = "grdResult";
            this.grdResult.RowTemplate.Height = 23;
            this.grdResult.Size = new System.Drawing.Size(792, 405);
            this.grdResult.TabIndex = 0;
            this.grdResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResult_CellContentClick);
            // 
            // insurancePolicyResultDtoBindingSource
            // 
            this.insurancePolicyResultDtoBindingSource.DataSource = typeof(SimpleCrm.DTO.InsurancePolicyResultDto);
            // 
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonBarMergeContainer1.Controls.Add(this.ribbonBar1);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(245, 158);
            this.ribbonBarMergeContainer1.Name = "ribbonBarMergeContainer1";
            this.ribbonBarMergeContainer1.RibbonTabText = "保单列表";
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
            this.btnAdd,
            this.btnRefresh});
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
            // btnAdd
            // 
            this.btnAdd.BeginGroup = true;
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.Image = global::SimpleCrm.Properties.Resources.new_page;
            this.btnAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.SubItemsExpandWidth = 14;
            this.btnAdd.Text = "新增保单";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEdit.HeaderText = "";
            this.colEdit.Image = ((System.Drawing.Image)(resources.GetObject("colEdit.Image")));
            this.colEdit.MinimumWidth = 20;
            this.colEdit.Name = "colEdit";
            this.colEdit.Text = null;
            this.colEdit.Width = 20;
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDelete.HeaderText = "";
            this.colDelete.Image = ((System.Drawing.Image)(resources.GetObject("colDelete.Image")));
            this.colDelete.MinimumWidth = 20;
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = null;
            this.colDelete.Width = 20;
            // 
            // insurancePolicyIdDataGridViewTextBoxColumn
            // 
            this.insurancePolicyIdDataGridViewTextBoxColumn.DataPropertyName = "InsurancePolicyId";
            this.insurancePolicyIdDataGridViewTextBoxColumn.HeaderText = "InsurancePolicyId";
            this.insurancePolicyIdDataGridViewTextBoxColumn.Name = "insurancePolicyIdDataGridViewTextBoxColumn";
            this.insurancePolicyIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // colInsurancePolicyNo
            // 
            this.colInsurancePolicyNo.DataPropertyName = "InsurancePolicyNo";
            this.colInsurancePolicyNo.HeaderText = "保单编号";
            this.colInsurancePolicyNo.Name = "colInsurancePolicyNo";
            this.colInsurancePolicyNo.ReadOnly = true;
            this.colInsurancePolicyNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInsurancePolicyNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "CustomerName";
            this.colCustomerName.HeaderText = "客户姓名";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            // 
            // colPolicyHolderName
            // 
            this.colPolicyHolderName.DataPropertyName = "PolicyHolderName";
            this.colPolicyHolderName.HeaderText = "投保人";
            this.colPolicyHolderName.Name = "colPolicyHolderName";
            this.colPolicyHolderName.ReadOnly = true;
            // 
            // colInsuredName
            // 
            this.colInsuredName.DataPropertyName = "InsuredName";
            this.colInsuredName.HeaderText = "被保人";
            this.colInsuredName.Name = "colInsuredName";
            this.colInsuredName.ReadOnly = true;
            // 
            // effectiveDateDataGridViewTextBoxColumn
            // 
            this.effectiveDateDataGridViewTextBoxColumn.DataPropertyName = "EffectiveDate";
            this.effectiveDateDataGridViewTextBoxColumn.HeaderText = "生效日期";
            this.effectiveDateDataGridViewTextBoxColumn.Name = "effectiveDateDataGridViewTextBoxColumn";
            this.effectiveDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insuredYearDataGridViewTextBoxColumn
            // 
            this.insuredYearDataGridViewTextBoxColumn.DataPropertyName = "InsuredYear";
            this.insuredYearDataGridViewTextBoxColumn.HeaderText = "投保年限";
            this.insuredYearDataGridViewTextBoxColumn.Name = "insuredYearDataGridViewTextBoxColumn";
            this.insuredYearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // premiumDataGridViewTextBoxColumn
            // 
            this.premiumDataGridViewTextBoxColumn.DataPropertyName = "Premium";
            this.premiumDataGridViewTextBoxColumn.HeaderText = "年交保费";
            this.premiumDataGridViewTextBoxColumn.Name = "premiumDataGridViewTextBoxColumn";
            this.premiumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.DropDownHeight = 106;
            this.colCategory.DropDownWidth = 121;
            this.colCategory.Enabled = false;
            this.colCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCategory.HeaderText = "保险类别";
            this.colCategory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colCategory.IntegralHeight = false;
            this.colCategory.ItemHeight = 16;
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.DropDownHeight = 106;
            this.colStatus.DropDownWidth = 121;
            this.colStatus.Enabled = false;
            this.colStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colStatus.HeaderText = "保单状态 ";
            this.colStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colStatus.IntegralHeight = false;
            this.colStatus.ItemHeight = 16;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // InsurancePolicyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(792, 405);
            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Controls.Add(this.grdResult);
            this.DoubleBuffered = true;
            this.Name = "InsurancePolicyListForm";
            this.Text = "保单列表";
            this.Load += new System.EventHandler(this.CustomerMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insurancePolicyResultDtoBindingSource)).EndInit();
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX grdResult;
        private System.Windows.Forms.BindingSource insurancePolicyResultDtoBindingSource;
        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnRefresh;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colEdit;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePolicyIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn colInsurancePolicyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPolicyHolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsuredName;
        private System.Windows.Forms.DataGridViewTextBoxColumn effectiveDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insuredYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn premiumDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colCategory;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colStatus;


    }
}
