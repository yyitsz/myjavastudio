using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Mouse.Main
{
	public class SettingForm : Form
	{
		private IContainer components = null;
        private GroupBox groupBox1;
		private Label label4;
		private TextBox txtPath;
		private Button btnBrowse;
		private Label label2;
		private Label label1;
		private Button btnSave;
		private Button btnCancel;
		private GroupBox groupBox2;
		private Label lblMsg;

        
		public SettingForm()
		{
			this.InitializeComponent();
		}
		private void SettingForm_Load(object sender, EventArgs e)
		{
            AppConfig config = Tools.Load();
            this.txtPath.Text = config.BooksPath ;

            if (this.txtPath.Text.Length > 0 && Directory.Exists(this.txtPath.Text) == false)
			{
				this.lblMsg.Text = "路径已经失效，请重新设置并保存！";
			}
		}
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "请选择图片所在文件夹";
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				this.txtPath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(this.txtPath.Text);
			if (!directoryInfo.Exists)
			{
				if (MessageBox.Show("路径不存在，是否创建？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					try
					{
						Directory.CreateDirectory(this.txtPath.Text);
					}
					catch (Exception ex)
					{
						MessageBox.Show("路径目录创建失败，请确认路径是否有效！Msg: " + ex.Message);
					}
				}
			}
			else
			{
                AppConfig config = Tools.Load();
                config.BooksPath = this.txtPath.Text;
                Tools.Save(config);
				base.Close();
			}
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "路径设置";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(26, 77);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "而是存储在默认路径下。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "开启默认路径后，下次下载时将不再提示选择存储位置，";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(312, 52);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "浏览...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(21, 52);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(275, 21);
            this.txtPath.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "设置下载路径";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(54, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(288, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(8, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 46);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作";
            // 
            // SettingForm
            // 
            this.ClientSize = new System.Drawing.Size(437, 220);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingForm";
            this.Text = "默认路径设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
