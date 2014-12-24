namespace RecourceConverter
{
    partial class frmResourceConverter
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
            this.txtRowStart = new System.Windows.Forms.TextBox();
            this.txtLabelType = new System.Windows.Forms.TextBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeyIndex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValueIndex = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnBrown = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSheetName = new System.Windows.Forms.TextBox();
            this.btnBrownResourceFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResoucrFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnBrown2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFieldFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalColumns = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblLabelType = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.txtDeleted = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalCoumnsForLen = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAllowNonEng = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFieldIdNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLengthColumnNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFieldSheetName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbApp = new System.Windows.Forms.ComboBox();
            this.btnCheckLov = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRowStart
            // 
            this.txtRowStart.Location = new System.Drawing.Point(420, 132);
            this.txtRowStart.Name = "txtRowStart";
            this.txtRowStart.Size = new System.Drawing.Size(118, 21);
            this.txtRowStart.TabIndex = 19;
            this.txtRowStart.Text = "5";
            // 
            // txtLabelType
            // 
            this.txtLabelType.Location = new System.Drawing.Point(420, 158);
            this.txtLabelType.Name = "txtLabelType";
            this.txtLabelType.Size = new System.Drawing.Size(118, 21);
            this.txtLabelType.TabIndex = 21;
            this.txtLabelType.Text = "M";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(139, 58);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(379, 21);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.Text = "\\\\10.100.1.124\\test\\20080428HKFS\\Field";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Excel File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key Column";
            // 
            // txtKeyIndex
            // 
            this.txtKeyIndex.Location = new System.Drawing.Point(139, 161);
            this.txtKeyIndex.Name = "txtKeyIndex";
            this.txtKeyIndex.Size = new System.Drawing.Size(118, 21);
            this.txtKeyIndex.TabIndex = 2;
            this.txtKeyIndex.Text = "P";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Value Column";
            // 
            // txtValueIndex
            // 
            this.txtValueIndex.Location = new System.Drawing.Point(420, 185);
            this.txtValueIndex.Name = "txtValueIndex";
            this.txtValueIndex.Size = new System.Drawing.Size(118, 21);
            this.txtValueIndex.TabIndex = 4;
            this.txtValueIndex.Text = "Q";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(421, 213);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(121, 23);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBrown
            // 
            this.btnBrown.Location = new System.Drawing.Point(524, 58);
            this.btnBrown.Name = "btnBrown";
            this.btnBrown.Size = new System.Drawing.Size(33, 23);
            this.btnBrown.TabIndex = 7;
            this.btnBrown.Text = "...";
            this.btnBrown.UseVisualStyleBackColor = true;
            this.btnBrown.Click += new System.EventHandler(this.btnBrown_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sheet Name";
            // 
            // txtSheetName
            // 
            this.txtSheetName.Location = new System.Drawing.Point(139, 129);
            this.txtSheetName.Name = "txtSheetName";
            this.txtSheetName.Size = new System.Drawing.Size(118, 21);
            this.txtSheetName.TabIndex = 8;
            this.txtSheetName.Text = "Field$";
            // 
            // btnBrownResourceFile
            // 
            this.btnBrownResourceFile.Location = new System.Drawing.Point(524, 94);
            this.btnBrownResourceFile.Name = "btnBrownResourceFile";
            this.btnBrownResourceFile.Size = new System.Drawing.Size(33, 23);
            this.btnBrownResourceFile.TabIndex = 12;
            this.btnBrownResourceFile.Text = "...";
            this.btnBrownResourceFile.UseVisualStyleBackColor = true;
            this.btnBrownResourceFile.Click += new System.EventHandler(this.btnBrownResourceFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Resource File";
            // 
            // txtResoucrFile
            // 
            this.txtResoucrFile.Location = new System.Drawing.Point(139, 94);
            this.txtResoucrFile.Name = "txtResoucrFile";
            this.txtResoucrFile.ReadOnly = true;
            this.txtResoucrFile.Size = new System.Drawing.Size(379, 21);
            this.txtResoucrFile.TabIndex = 10;
            this.txtResoucrFile.Text = "D:\\MyWorkspace\\MSS-D\\MSS-D Client\\Taifook.MSS.Resources\\Properties\\Resources.resx" +
                "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "File Type";
            // 
            // cmbFileType
            // 
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Items.AddRange(new object[] {
            "Field",
            "Message"});
            this.cmbFileType.Location = new System.Drawing.Point(139, 14);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(121, 20);
            this.cmbFileType.TabIndex = 14;
            this.cmbFileType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(424, 120);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(121, 23);
            this.btnGen.TabIndex = 15;
            this.btnGen.Text = "Field Length Gen";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnBrown2
            // 
            this.btnBrown2.Location = new System.Drawing.Point(524, 14);
            this.btnBrown2.Name = "btnBrown2";
            this.btnBrown2.Size = new System.Drawing.Size(33, 23);
            this.btnBrown2.TabIndex = 18;
            this.btnBrown2.Text = "...";
            this.btnBrown2.UseVisualStyleBackColor = true;
            this.btnBrown2.Click += new System.EventHandler(this.btnBrown2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Source Excel File";
            // 
            // txtFieldFilePath
            // 
            this.txtFieldFilePath.Location = new System.Drawing.Point(139, 14);
            this.txtFieldFilePath.Name = "txtFieldFilePath";
            this.txtFieldFilePath.Size = new System.Drawing.Size(379, 21);
            this.txtFieldFilePath.TabIndex = 16;
            this.txtFieldFilePath.Text = "\\\\10.100.1.124\\test\\20080428HKFS\\Field";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheckLov);
            this.groupBox1.Controls.Add(this.txtTotalColumns);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtLabelType);
            this.groupBox1.Controls.Add(this.lblLabelType);
            this.groupBox1.Controls.Add(this.txtRowStart);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cmbLanguage);
            this.groupBox1.Controls.Add(this.txtDeleted);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFilename);
            this.groupBox1.Controls.Add(this.txtKeyIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtValueIndex);
            this.groupBox1.Controls.Add(this.cmbFileType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnConvert);
            this.groupBox1.Controls.Add(this.btnBrownResourceFile);
            this.groupBox1.Controls.Add(this.btnBrown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSheetName);
            this.groupBox1.Controls.Add(this.txtResoucrFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 281);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txtTotalColumns
            // 
            this.txtTotalColumns.Location = new System.Drawing.Point(139, 215);
            this.txtTotalColumns.Name = "txtTotalColumns";
            this.txtTotalColumns.Size = new System.Drawing.Size(118, 21);
            this.txtTotalColumns.TabIndex = 23;
            this.txtTotalColumns.Text = "32";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 218);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 24;
            this.label14.Text = "Total Columns";
            // 
            // lblLabelType
            // 
            this.lblLabelType.AutoSize = true;
            this.lblLabelType.Location = new System.Drawing.Point(309, 161);
            this.lblLabelType.Name = "lblLabelType";
            this.lblLabelType.Size = new System.Drawing.Size(65, 12);
            this.lblLabelType.TabIndex = 22;
            this.lblLabelType.Text = "Label Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(309, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "Row Start";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(294, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save Configuration";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "",
            "zh-cn",
            "zh-tw"});
            this.cmbLanguage.Location = new System.Drawing.Point(279, 14);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 20);
            this.cmbLanguage.TabIndex = 17;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtDeleted
            // 
            this.txtDeleted.Location = new System.Drawing.Point(139, 188);
            this.txtDeleted.Name = "txtDeleted";
            this.txtDeleted.Size = new System.Drawing.Size(118, 21);
            this.txtDeleted.TabIndex = 15;
            this.txtDeleted.Text = "D";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "Deleted?";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTotalCoumnsForLen);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtAllowNonEng);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtFieldIdNo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtLengthColumnNo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtFieldSheetName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnGen);
            this.groupBox2.Controls.Add(this.btnBrown2);
            this.groupBox2.Controls.Add(this.txtFieldFilePath);
            this.groupBox2.Location = new System.Drawing.Point(6, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 161);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // txtTotalCoumnsForLen
            // 
            this.txtTotalCoumnsForLen.Location = new System.Drawing.Point(424, 41);
            this.txtTotalCoumnsForLen.Name = "txtTotalCoumnsForLen";
            this.txtTotalCoumnsForLen.Size = new System.Drawing.Size(118, 21);
            this.txtTotalCoumnsForLen.TabIndex = 27;
            this.txtTotalCoumnsForLen.Text = "32";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(291, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "Total Columns";
            // 
            // txtAllowNonEng
            // 
            this.txtAllowNonEng.Location = new System.Drawing.Point(148, 128);
            this.txtAllowNonEng.Name = "txtAllowNonEng";
            this.txtAllowNonEng.Size = new System.Drawing.Size(118, 21);
            this.txtAllowNonEng.TabIndex = 25;
            this.txtAllowNonEng.Text = "V";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "Allow Non_Eng Column";
            // 
            // txtFieldIdNo
            // 
            this.txtFieldIdNo.Location = new System.Drawing.Point(148, 73);
            this.txtFieldIdNo.Name = "txtFieldIdNo";
            this.txtFieldIdNo.Size = new System.Drawing.Size(118, 21);
            this.txtFieldIdNo.TabIndex = 19;
            this.txtFieldIdNo.Text = "P";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "Field Id Column";
            // 
            // txtLengthColumnNo
            // 
            this.txtLengthColumnNo.Location = new System.Drawing.Point(148, 101);
            this.txtLengthColumnNo.Name = "txtLengthColumnNo";
            this.txtLengthColumnNo.Size = new System.Drawing.Size(118, 21);
            this.txtLengthColumnNo.TabIndex = 21;
            this.txtLengthColumnNo.Text = "W";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "Length Column";
            // 
            // txtFieldSheetName
            // 
            this.txtFieldSheetName.Location = new System.Drawing.Point(148, 41);
            this.txtFieldSheetName.Name = "txtFieldSheetName";
            this.txtFieldSheetName.Size = new System.Drawing.Size(118, 21);
            this.txtFieldSheetName.TabIndex = 23;
            this.txtFieldSheetName.Text = "Field$";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "Sheet Name";
            // 
            // cmbApp
            // 
            this.cmbApp.FormattingEnabled = true;
            this.cmbApp.Location = new System.Drawing.Point(12, 12);
            this.cmbApp.Name = "cmbApp";
            this.cmbApp.Size = new System.Drawing.Size(221, 20);
            this.cmbApp.TabIndex = 21;
            this.cmbApp.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnCheckLov
            // 
            this.btnCheckLov.Location = new System.Drawing.Point(294, 252);
            this.btnCheckLov.Name = "btnCheckLov";
            this.btnCheckLov.Size = new System.Drawing.Size(92, 23);
            this.btnCheckLov.TabIndex = 25;
            this.btnCheckLov.Text = "Check LOV";
            this.btnCheckLov.UseVisualStyleBackColor = true;
            this.btnCheckLov.Click += new System.EventHandler(this.btnCheckLov_Click);
            // 
            // frmResourceConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 554);
            this.Controls.Add(this.cmbApp);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmResourceConverter";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKeyIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValueIndex;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnBrown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSheetName;
        private System.Windows.Forms.Button btnBrownResourceFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResoucrFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnBrown2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFieldFilePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAllowNonEng;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFieldIdNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLengthColumnNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFieldSheetName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDeleted;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbApp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLabelType;
        private System.Windows.Forms.TextBox txtRowStart;
        private System.Windows.Forms.TextBox txtLabelType;
        private System.Windows.Forms.TextBox txtTotalColumns;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalCoumnsForLen;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCheckLov;
    }
}

