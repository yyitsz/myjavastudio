namespace SimpleCrm.CustomerForm
{
    partial class CustomerImportForm
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ribbonBarMergeContainer1 = new DevComponents.DotNetBar.RibbonBarMergeContainer();
            this.scheduleRibbonBar = new DevComponents.DotNetBar.RibbonBar();
            this.btnImport = new DevComponents.DotNetBar.ButtonItem();
            this.grdResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.customerImportDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMsg = new DevComponents.DotNetBar.LabelX();
            this.ImportStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seqNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.policyHolderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.policyHolderBirthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insuredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insuredBirthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePolicyNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPEffectiveDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryIPNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.premiumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isOrphanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1.SuspendLayout();
            this.ribbonBarMergeContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerImportDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;

            this.groupPanel1.Controls.Add(this.grdResult);
            this.groupPanel1.Controls.Add(this.lblMsg);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(638, 406);
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
            // ribbonBarMergeContainer1
            // 
            this.ribbonBarMergeContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBarMergeContainer1.Controls.Add(this.scheduleRibbonBar);
            this.ribbonBarMergeContainer1.Location = new System.Drawing.Point(78, 164);
            this.ribbonBarMergeContainer1.Name = "ribbonBarMergeContainer1";
            this.ribbonBarMergeContainer1.RibbonTabText = "客户导入";
            this.ribbonBarMergeContainer1.Size = new System.Drawing.Size(476, 73);
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
            // scheduleRibbonBar
            // 
            this.scheduleRibbonBar.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.scheduleRibbonBar.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.scheduleRibbonBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.scheduleRibbonBar.ContainerControlProcessDialogKey = true;
            this.scheduleRibbonBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleRibbonBar.DragDropSupport = true;
            this.scheduleRibbonBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnImport});
            this.scheduleRibbonBar.Location = new System.Drawing.Point(0, 0);
            this.scheduleRibbonBar.Name = "scheduleRibbonBar";
            this.scheduleRibbonBar.Size = new System.Drawing.Size(476, 73);
            this.scheduleRibbonBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.scheduleRibbonBar.TabIndex = 2;
            this.scheduleRibbonBar.Text = "Schedule";
            // 
            // 
            // 
            this.scheduleRibbonBar.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.scheduleRibbonBar.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.scheduleRibbonBar.TitleVisible = false;
            // 
            // btnImport
            // 
            this.btnImport.BeginGroup = true;
            this.btnImport.Image = global::SimpleCrm.Properties.Resources.download;
            this.btnImport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnImport.Name = "btnImport";
            this.btnImport.SubItemsExpandWidth = 14;
            this.btnImport.Text = "导入";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // grdResult
            // 
            this.grdResult.AllowUserToAddRows = false;
            this.grdResult.AllowUserToDeleteRows = false;
            this.grdResult.AutoGenerateColumns = false;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImportStatus,
            this.seqNoDataGridViewTextBoxColumn,
            this.policyHolderDataGridViewTextBoxColumn,
            this.policyHolderBirthdayDataGridViewTextBoxColumn,
            this.insuredDataGridViewTextBoxColumn,
            this.insuredBirthdayDataGridViewTextBoxColumn,
            this.insurancePolicyNoDataGridViewTextBoxColumn,
            this.iPEffectiveDateDataGridViewTextBoxColumn,
            this.primaryIPNameDataGridViewTextBoxColumn,
            this.premiumDataGridViewTextBoxColumn,
            this.telephoneDataGridViewTextBoxColumn,
            this.iPStatusDataGridViewTextBoxColumn,
            this.isOrphanDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn});
            this.grdResult.DataSource = this.customerImportDtoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grdResult.Location = new System.Drawing.Point(0, 23);
            this.grdResult.Name = "grdResult";
            this.grdResult.ReadOnly = true;
            this.grdResult.RowTemplate.Height = 23;
            this.grdResult.Size = new System.Drawing.Size(632, 377);
            this.grdResult.TabIndex = 0;
            // 
            // customerImportDtoBindingSource
            // 
            this.customerImportDtoBindingSource.DataSource = typeof(SimpleCrm.DTO.CustomerImportDto);
            // 
            // lblMsg
            // 
            // 
            // 
            // 
            this.lblMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(632, 23);
            this.lblMsg.TabIndex = 1;
            // 
            // ImportStatus
            // 
            this.ImportStatus.DataPropertyName = "ImportStatus";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            this.ImportStatus.DefaultCellStyle = dataGridViewCellStyle1;
            this.ImportStatus.HeaderText = "导入结果";
            this.ImportStatus.Name = "ImportStatus";
            this.ImportStatus.ReadOnly = true;
            // 
            // seqNoDataGridViewTextBoxColumn
            // 
            this.seqNoDataGridViewTextBoxColumn.DataPropertyName = "SeqNo";
            this.seqNoDataGridViewTextBoxColumn.HeaderText = "序号";
            this.seqNoDataGridViewTextBoxColumn.Name = "seqNoDataGridViewTextBoxColumn";
            this.seqNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // policyHolderDataGridViewTextBoxColumn
            // 
            this.policyHolderDataGridViewTextBoxColumn.DataPropertyName = "PolicyHolder";
            this.policyHolderDataGridViewTextBoxColumn.HeaderText = "保险人";
            this.policyHolderDataGridViewTextBoxColumn.Name = "policyHolderDataGridViewTextBoxColumn";
            this.policyHolderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // policyHolderBirthdayDataGridViewTextBoxColumn
            // 
            this.policyHolderBirthdayDataGridViewTextBoxColumn.DataPropertyName = "PolicyHolderBirthday";
            this.policyHolderBirthdayDataGridViewTextBoxColumn.HeaderText = "保险人生日";
            this.policyHolderBirthdayDataGridViewTextBoxColumn.Name = "policyHolderBirthdayDataGridViewTextBoxColumn";
            this.policyHolderBirthdayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insuredDataGridViewTextBoxColumn
            // 
            this.insuredDataGridViewTextBoxColumn.DataPropertyName = "Insured";
            this.insuredDataGridViewTextBoxColumn.HeaderText = "被保险人";
            this.insuredDataGridViewTextBoxColumn.Name = "insuredDataGridViewTextBoxColumn";
            this.insuredDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insuredBirthdayDataGridViewTextBoxColumn
            // 
            this.insuredBirthdayDataGridViewTextBoxColumn.DataPropertyName = "InsuredBirthday";
            this.insuredBirthdayDataGridViewTextBoxColumn.HeaderText = "被保险人生日";
            this.insuredBirthdayDataGridViewTextBoxColumn.Name = "insuredBirthdayDataGridViewTextBoxColumn";
            this.insuredBirthdayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insurancePolicyNoDataGridViewTextBoxColumn
            // 
            this.insurancePolicyNoDataGridViewTextBoxColumn.DataPropertyName = "InsurancePolicyNo";
            this.insurancePolicyNoDataGridViewTextBoxColumn.HeaderText = "保单号码";
            this.insurancePolicyNoDataGridViewTextBoxColumn.Name = "insurancePolicyNoDataGridViewTextBoxColumn";
            this.insurancePolicyNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iPEffectiveDateDataGridViewTextBoxColumn
            // 
            this.iPEffectiveDateDataGridViewTextBoxColumn.DataPropertyName = "IPEffectiveDate";
            this.iPEffectiveDateDataGridViewTextBoxColumn.HeaderText = "生效日期";
            this.iPEffectiveDateDataGridViewTextBoxColumn.Name = "iPEffectiveDateDataGridViewTextBoxColumn";
            this.iPEffectiveDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // primaryIPNameDataGridViewTextBoxColumn
            // 
            this.primaryIPNameDataGridViewTextBoxColumn.DataPropertyName = "PrimaryIPName";
            this.primaryIPNameDataGridViewTextBoxColumn.HeaderText = "主险名称";
            this.primaryIPNameDataGridViewTextBoxColumn.Name = "primaryIPNameDataGridViewTextBoxColumn";
            this.primaryIPNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // premiumDataGridViewTextBoxColumn
            // 
            this.premiumDataGridViewTextBoxColumn.DataPropertyName = "Premium";
            this.premiumDataGridViewTextBoxColumn.HeaderText = "年交保费";
            this.premiumDataGridViewTextBoxColumn.Name = "premiumDataGridViewTextBoxColumn";
            this.premiumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telephoneDataGridViewTextBoxColumn
            // 
            this.telephoneDataGridViewTextBoxColumn.DataPropertyName = "Telephone";
            this.telephoneDataGridViewTextBoxColumn.HeaderText = "联系电话";
            this.telephoneDataGridViewTextBoxColumn.Name = "telephoneDataGridViewTextBoxColumn";
            this.telephoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iPStatusDataGridViewTextBoxColumn
            // 
            this.iPStatusDataGridViewTextBoxColumn.DataPropertyName = "IPStatus";
            this.iPStatusDataGridViewTextBoxColumn.HeaderText = "保单状态";
            this.iPStatusDataGridViewTextBoxColumn.Name = "iPStatusDataGridViewTextBoxColumn";
            this.iPStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isOrphanDataGridViewTextBoxColumn
            // 
            this.isOrphanDataGridViewTextBoxColumn.DataPropertyName = "IsOrphan";
            this.isOrphanDataGridViewTextBoxColumn.HeaderText = "是否孤儿单";
            this.isOrphanDataGridViewTextBoxColumn.Name = "isOrphanDataGridViewTextBoxColumn";
            this.isOrphanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "联系地址";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CustomerImpotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 406);

            this.Controls.Add(this.ribbonBarMergeContainer1);
            this.Controls.Add(this.groupPanel1);
            this.DoubleBuffered = true;
            this.Name = "CustomerImpotForm";
            this.Text = "客户导入";
            this.groupPanel1.ResumeLayout(false);
            this.ribbonBarMergeContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerImportDtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdResult;
        private System.Windows.Forms.BindingSource customerImportDtoBindingSource;
        private DevComponents.DotNetBar.LabelX lblMsg;
        private DevComponents.DotNetBar.RibbonBarMergeContainer ribbonBarMergeContainer1;
        private DevComponents.DotNetBar.RibbonBar scheduleRibbonBar;
        private DevComponents.DotNetBar.ButtonItem btnImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn seqNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn policyHolderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn policyHolderBirthdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insuredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insuredBirthdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePolicyNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPEffectiveDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryIPNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn premiumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isOrphanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
    }
}