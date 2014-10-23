using DevComponents.DotNetBar.Controls;
namespace SimpleCrm.MasterForm
{
    partial class LovMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LovMainForm));
            this.groupBox3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.grdResult = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lovBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbLovType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblLovType = new System.Windows.Forms.Label();
            this.colDelete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.lovIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLovType = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeq = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.parentIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attribute1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attribute2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attribute3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attribute4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdResult);
            this.groupBox3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(963, 497);
            // 
            // 
            // 
            this.groupBox3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupBox3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupBox3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupBox3.TabIndex = 2;
            // 
            // grdResult
            // 
            this.grdResult.AutoGenerateColumns = false;
            this.grdResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete,
            this.lovIdDataGridViewTextBoxColumn,
            this.colLovType,
            this.colCode,
            this.colName,
            this.colSeq,
            this.parentIdDataGridViewTextBoxColumn,
            this.attribute1DataGridViewTextBoxColumn,
            this.attribute2DataGridViewTextBoxColumn,
            this.attribute3DataGridViewTextBoxColumn,
            this.attribute4DataGridViewTextBoxColumn,
            this.createTimeDataGridViewTextBoxColumn,
            this.updatedByDataGridViewTextBoxColumn,
            this.updateTimeDataGridViewTextBoxColumn,
            this.versionNoDataGridViewTextBoxColumn});
            this.grdResult.DataSource = this.lovBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdResult.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.grdResult.Location = new System.Drawing.Point(0, 0);
            this.grdResult.Name = "grdResult";
            this.grdResult.RowHeadersWidth = 30;
            this.grdResult.RowTemplate.Height = 23;
            this.grdResult.Size = new System.Drawing.Size(963, 497);
            this.grdResult.TabIndex = 0;
            this.grdResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResult_CellContentClick);
            this.grdResult.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdResult_UserAddedRow);
            // 
            // lovBindingSource
            // 
            this.lovBindingSource.DataSource = typeof(SimpleCrm.Model.Lov);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLovType);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblLovType);
            this.groupBox1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(963, 61);
            // 
            // 
            // 
            this.groupBox1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupBox1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupBox1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupBox1.TabIndex = 0;
            // 
            // cmbLovType
            // 
            this.cmbLovType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLovType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLovType.DisplayMember = "Item1";
            this.cmbLovType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLovType.FormattingEnabled = true;
            this.cmbLovType.ItemHeight = 14;
            this.cmbLovType.Location = new System.Drawing.Point(118, 21);
            this.cmbLovType.Name = "cmbLovType";
            this.cmbLovType.Size = new System.Drawing.Size(121, 20);
            this.cmbLovType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbLovType.TabIndex = 14;
            this.cmbLovType.ValueMember = "Item2";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(696, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存(&v)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(777, 20);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清除(&C)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(604, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询(&S)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblLovType
            // 
            this.lblLovType.AutoSize = true;
            this.lblLovType.Location = new System.Drawing.Point(19, 25);
            this.lblLovType.Name = "lblLovType";
            this.lblLovType.Size = new System.Drawing.Size(77, 12);
            this.lblLovType.TabIndex = 0;
            this.lblLovType.Text = "基础数据类别";
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDelete.HeaderText = "";
            this.colDelete.Image = ((System.Drawing.Image)(resources.GetObject("colDelete.Image")));
            this.colDelete.MinimumWidth = 10;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colDelete.Text = null;
            this.colDelete.Width = 22;
            // 
            // lovIdDataGridViewTextBoxColumn
            // 
            this.lovIdDataGridViewTextBoxColumn.DataPropertyName = "LovId";
            this.lovIdDataGridViewTextBoxColumn.HeaderText = "LovId";
            this.lovIdDataGridViewTextBoxColumn.Name = "lovIdDataGridViewTextBoxColumn";
            this.lovIdDataGridViewTextBoxColumn.Visible = false;
            this.lovIdDataGridViewTextBoxColumn.Width = 21;
            // 
            // colLovType
            // 
            this.colLovType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLovType.DataPropertyName = "LovType";
            this.colLovType.DisplayMember = "Text";
            this.colLovType.DropDownHeight = 106;
            this.colLovType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colLovType.DropDownWidth = 121;
            this.colLovType.Enabled = false;
            this.colLovType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colLovType.HeaderText = "基础数据类别";
            this.colLovType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colLovType.IntegralHeight = false;
            this.colLovType.MinimumWidth = 150;
            this.colLovType.Name = "colLovType";
            this.colLovType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLovType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colLovType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.colLovType.Width = 150;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "编码";
            this.colCode.MaxInputLength = 50;
            this.colCode.MinimumWidth = 150;
            this.colCode.Name = "colCode";
            this.colCode.Width = 150;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 150;
            this.colName.Name = "colName";
            this.colName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colName.Width = 150;
            // 
            // colSeq
            // 
            // 
            // 
            // 
            this.colSeq.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.colSeq.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.colSeq.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.colSeq.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.colSeq.DataPropertyName = "Seq";
            this.colSeq.HeaderText = "序号";
            this.colSeq.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.colSeq.MaxInputLength = 10;
            this.colSeq.MaxValue = 100;
            this.colSeq.MinimumWidth = 70;
            this.colSeq.MinValue = 0;
            this.colSeq.Name = "colSeq";
            this.colSeq.Width = 70;
            // 
            // parentIdDataGridViewTextBoxColumn
            // 
            this.parentIdDataGridViewTextBoxColumn.DataPropertyName = "ParentId";
            this.parentIdDataGridViewTextBoxColumn.HeaderText = "ParentId";
            this.parentIdDataGridViewTextBoxColumn.Name = "parentIdDataGridViewTextBoxColumn";
            this.parentIdDataGridViewTextBoxColumn.Visible = false;
            this.parentIdDataGridViewTextBoxColumn.Width = 21;
            // 
            // attribute1DataGridViewTextBoxColumn
            // 
            this.attribute1DataGridViewTextBoxColumn.DataPropertyName = "Attribute1";
            this.attribute1DataGridViewTextBoxColumn.HeaderText = "属性1";
            this.attribute1DataGridViewTextBoxColumn.MaxInputLength = 50;
            this.attribute1DataGridViewTextBoxColumn.MinimumWidth = 150;
            this.attribute1DataGridViewTextBoxColumn.Name = "attribute1DataGridViewTextBoxColumn";
            this.attribute1DataGridViewTextBoxColumn.Width = 150;
            // 
            // attribute2DataGridViewTextBoxColumn
            // 
            this.attribute2DataGridViewTextBoxColumn.DataPropertyName = "Attribute2";
            this.attribute2DataGridViewTextBoxColumn.HeaderText = "属性2";
            this.attribute2DataGridViewTextBoxColumn.MaxInputLength = 50;
            this.attribute2DataGridViewTextBoxColumn.MinimumWidth = 150;
            this.attribute2DataGridViewTextBoxColumn.Name = "attribute2DataGridViewTextBoxColumn";
            this.attribute2DataGridViewTextBoxColumn.Width = 150;
            // 
            // attribute3DataGridViewTextBoxColumn
            // 
            this.attribute3DataGridViewTextBoxColumn.DataPropertyName = "Attribute3";
            this.attribute3DataGridViewTextBoxColumn.HeaderText = "属性3";
            this.attribute3DataGridViewTextBoxColumn.MaxInputLength = 50;
            this.attribute3DataGridViewTextBoxColumn.MinimumWidth = 150;
            this.attribute3DataGridViewTextBoxColumn.Name = "attribute3DataGridViewTextBoxColumn";
            this.attribute3DataGridViewTextBoxColumn.Width = 150;
            // 
            // attribute4DataGridViewTextBoxColumn
            // 
            this.attribute4DataGridViewTextBoxColumn.DataPropertyName = "Attribute4";
            this.attribute4DataGridViewTextBoxColumn.HeaderText = "属性4";
            this.attribute4DataGridViewTextBoxColumn.MaxInputLength = 50;
            this.attribute4DataGridViewTextBoxColumn.MinimumWidth = 150;
            this.attribute4DataGridViewTextBoxColumn.Name = "attribute4DataGridViewTextBoxColumn";
            this.attribute4DataGridViewTextBoxColumn.Width = 150;
            // 
            // createTimeDataGridViewTextBoxColumn
            // 
            this.createTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.HeaderText = "CreateTime";
            this.createTimeDataGridViewTextBoxColumn.Name = "createTimeDataGridViewTextBoxColumn";
            this.createTimeDataGridViewTextBoxColumn.Visible = false;
            this.createTimeDataGridViewTextBoxColumn.Width = 21;
            // 
            // updatedByDataGridViewTextBoxColumn
            // 
            this.updatedByDataGridViewTextBoxColumn.DataPropertyName = "UpdatedBy";
            this.updatedByDataGridViewTextBoxColumn.HeaderText = "UpdatedBy";
            this.updatedByDataGridViewTextBoxColumn.Name = "updatedByDataGridViewTextBoxColumn";
            this.updatedByDataGridViewTextBoxColumn.Visible = false;
            this.updatedByDataGridViewTextBoxColumn.Width = 21;
            // 
            // updateTimeDataGridViewTextBoxColumn
            // 
            this.updateTimeDataGridViewTextBoxColumn.DataPropertyName = "UpdateTime";
            this.updateTimeDataGridViewTextBoxColumn.HeaderText = "UpdateTime";
            this.updateTimeDataGridViewTextBoxColumn.Name = "updateTimeDataGridViewTextBoxColumn";
            this.updateTimeDataGridViewTextBoxColumn.Visible = false;
            this.updateTimeDataGridViewTextBoxColumn.Width = 21;
            // 
            // versionNoDataGridViewTextBoxColumn
            // 
            this.versionNoDataGridViewTextBoxColumn.DataPropertyName = "VersionNo";
            this.versionNoDataGridViewTextBoxColumn.HeaderText = "VersionNo";
            this.versionNoDataGridViewTextBoxColumn.Name = "versionNoDataGridViewTextBoxColumn";
            this.versionNoDataGridViewTextBoxColumn.Visible = false;
            this.versionNoDataGridViewTextBoxColumn.Width = 21;
            // 
            // LovMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(963, 558);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "LovMainForm";
            this.Text = "基础数据管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LovMainForm_FormClosing);
            this.Load += new System.EventHandler(this.LovMainForm_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lovBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupPanel groupBox1;
        private System.Windows.Forms.Label lblLovType;
        private GroupPanel groupBox3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private DataGridViewX grdResult;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbLovType;
        private System.Windows.Forms.BindingSource lovBindingSource;
        private DataGridViewButtonXColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn lovIdDataGridViewTextBoxColumn;
        private DataGridViewComboBoxExColumn colLovType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private DataGridViewIntegerInputColumn colSeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionNoDataGridViewTextBoxColumn;
    }
}
