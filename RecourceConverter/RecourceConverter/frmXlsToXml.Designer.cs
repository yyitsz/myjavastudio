using System.Windows.Forms;
namespace RecourceConverter
{
    partial class frmXlsToXml
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXlsToXml));
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnBrown = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSheetName = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.txtFirstLineNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTemplate = new ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalColumns = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDeletedFlagColumn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbXml = new System.Windows.Forms.RadioButton();
            this.rdbSQL = new System.Windows.Forms.RadioButton();

            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHeader
            // 
            this.txtHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeader.Location = new System.Drawing.Point(12, 36);
            this.txtHeader.Multiline = true;
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHeader.Size = new System.Drawing.Size(825, 61);
            this.txtHeader.TabIndex = 0;
            this.txtHeader.Text = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<reports xmlns:xsi=\"http://www.w3.org/200" +
                "1/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <reportse" +
                "ttings>";
            // 
            // txtTemplate
            // 
            this.txtTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplate.Location = new System.Drawing.Point(12, 114);
            this.txtTemplate.Multiline = true;
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTemplate.Size = new System.Drawing.Size(825, 115);
            this.txtTemplate.TabIndex = 1;
            this.txtTemplate.Text = resources.GetString("txtTemplate.Text");
            // 
            // txtFooter
            // 
            this.txtFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFooter.Location = new System.Drawing.Point(12, 245);
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFooter.Size = new System.Drawing.Size(825, 70);
            this.txtFooter.TabIndex = 2;
            this.txtFooter.Text = "  </reportsettings>\r\n</reports>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Source Excel File";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(157, 321);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(379, 21);
            this.txtFilename.TabIndex = 8;
            this.txtFilename.Text = "D:\\Bak\\My Documents";
            // 
            // btnBrown
            // 
            this.btnBrown.Location = new System.Drawing.Point(542, 321);
            this.btnBrown.Name = "btnBrown";
            this.btnBrown.Size = new System.Drawing.Size(32, 23);
            this.btnBrown.TabIndex = 10;
            this.btnBrown.Text = "...";
            this.btnBrown.UseVisualStyleBackColor = true;
            this.btnBrown.Click += new System.EventHandler(this.btnBrown_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(754, 353);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(70, 23);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Sheet Name";
            // 
            // txtSheetName
            // 
            this.txtSheetName.Location = new System.Drawing.Point(102, 353);
            this.txtSheetName.Name = "txtSheetName";
            this.txtSheetName.Size = new System.Drawing.Size(182, 21);
            this.txtSheetName.TabIndex = 17;
            this.txtSheetName.Text = "MSS Report$";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 388);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(825, 203);
            this.txtResult.TabIndex = 18;
            this.txtResult.Text = "";
            // 
            // txtFirstLineNo
            // 
            this.txtFirstLineNo.Location = new System.Drawing.Point(376, 353);
            this.txtFirstLineNo.Name = "txtFirstLineNo";
            this.txtFirstLineNo.Size = new System.Drawing.Size(39, 21);
            this.txtFirstLineNo.TabIndex = 20;
            this.txtFirstLineNo.Text = "4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "First Line";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DisplayMember = "Name";

            this.cmbTemplate.Location = new System.Drawing.Point(86, 9);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(144, 21);
            this.cmbTemplate.TabIndex = 21;
            this.cmbTemplate.ValueMember = "Name";
            this.cmbTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbTemplate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Template:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(472, 353);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(33, 21);
            this.txtKey.TabIndex = 24;
            this.txtKey.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "Key";
            // 
            // txtTotalColumns
            // 
            this.txtTotalColumns.Location = new System.Drawing.Point(619, 355);
            this.txtTotalColumns.Name = "txtTotalColumns";
            this.txtTotalColumns.Size = new System.Drawing.Size(49, 21);
            this.txtTotalColumns.TabIndex = 25;
            this.txtTotalColumns.Text = "32";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(511, 357);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 26;
            this.label14.Text = "Total Columns";
            // 
            // txtDeletedFlagColumn
            // 
            this.txtDeletedFlagColumn.Location = new System.Drawing.Point(732, 324);
            this.txtDeletedFlagColumn.Name = "txtDeletedFlagColumn";
            this.txtDeletedFlagColumn.Size = new System.Drawing.Size(33, 21);
            this.txtDeletedFlagColumn.TabIndex = 28;
            this.txtDeletedFlagColumn.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(596, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "Deleted Flag Column";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSQL);
            this.groupBox1.Controls.Add(this.rdbXml);
            this.groupBox1.Location = new System.Drawing.Point(344, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 33);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // rdbXml
            // 
            this.rdbXml.AutoSize = true;
            this.rdbXml.Checked = true;
            this.rdbXml.Location = new System.Drawing.Point(20, 9);
            this.rdbXml.Name = "rdbXml";
            this.rdbXml.Size = new System.Drawing.Size(41, 16);
            this.rdbXml.TabIndex = 0;
            this.rdbXml.TabStop = true;
            this.rdbXml.Text = "XML";
            this.rdbXml.UseVisualStyleBackColor = true;
            // 
            // rdbSQL
            // 
            this.rdbSQL.AutoSize = true;
            this.rdbSQL.Location = new System.Drawing.Point(156, 8);
            this.rdbSQL.Name = "rdbSQL";
            this.rdbSQL.Size = new System.Drawing.Size(41, 16);
            this.rdbSQL.TabIndex = 1;
            this.rdbSQL.Text = "SQL";
            this.rdbSQL.UseVisualStyleBackColor = true;
            // 
            // frmXlsToXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDeletedFlagColumn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalColumns);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTemplate);
            this.Controls.Add(this.txtFirstLineNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtSheetName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnBrown);
            this.Controls.Add(this.txtFooter);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.txtHeader);
            this.Name = "frmXlsToXml";
            this.Text = "frmXlsToXml";
            this.Load += new System.EventHandler(this.frmXlsToXml_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnBrown;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSheetName;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.TextBox txtFirstLineNo;
        private System.Windows.Forms.Label label2;
        private ComboBox cmbTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalColumns;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDeletedFlagColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbSQL;
        private System.Windows.Forms.RadioButton rdbXml;
    }
}