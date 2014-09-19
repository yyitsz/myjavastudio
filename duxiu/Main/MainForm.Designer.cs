using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
namespace Mouse.Main
{
	partial class MainForm
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mnuHelpMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mntExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mntSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetDefaultFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnParse = new System.Windows.Forms.Button();
            this.chkAuxPage = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBookPageInfo = new System.Windows.Forms.Label();
            this.cmbPicSize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblBookInfo = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtUrl = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.staBar = new System.Windows.Forms.StatusStrip();
            this.staBarStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.NumericUpDown();
            this.txtMax = new System.Windows.Forms.NumericUpDown();
            this.mnuMainMenu.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.staBar.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(395, 227);
            this.webBrowser.TabIndex = 3;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpMainMenu,
            this.mntSetting});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(951, 24);
            this.mnuMainMenu.TabIndex = 4;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mnuHelpMainMenu
            // 
            this.mnuHelpMainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntExit});
            this.mnuHelpMainMenu.Name = "mnuHelpMainMenu";
            this.mnuHelpMainMenu.Size = new System.Drawing.Size(41, 20);
            this.mnuHelpMainMenu.Text = "系统";
            // 
            // mntExit
            // 
            this.mntExit.Name = "mntExit";
            this.mntExit.Size = new System.Drawing.Size(94, 22);
            this.mntExit.Text = "退出";
            this.mntExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mntSetting
            // 
            this.mntSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetDefaultFolder});
            this.mntSetting.Name = "mntSetting";
            this.mntSetting.Size = new System.Drawing.Size(41, 20);
            this.mntSetting.Text = "设置";
            // 
            // mnuSetDefaultFolder
            // 
            this.mnuSetDefaultFolder.Name = "mnuSetDefaultFolder";
            this.mnuSetDefaultFolder.Size = new System.Drawing.Size(94, 22);
            this.mnuSetDefaultFolder.Text = "设置";
            this.mnuSetDefaultFolder.Click += new System.EventHandler(this.mnuSetting_Click);
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(76, 20);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(68, 33);
            this.btnParse.TabIndex = 7;
            this.btnParse.Text = "下载";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // chkAuxPage
            // 
            this.chkAuxPage.AutoSize = true;
            this.chkAuxPage.Location = new System.Drawing.Point(21, 40);
            this.chkAuxPage.Name = "chkAuxPage";
            this.chkAuxPage.Size = new System.Drawing.Size(108, 16);
            this.chkAuxPage.TabIndex = 9;
            this.chkAuxPage.Text = "自动下载辅助页";
            this.chkAuxPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "正文：";
            // 
            // lblBookPageInfo
            // 
            this.lblBookPageInfo.AutoSize = true;
            this.lblBookPageInfo.Location = new System.Drawing.Point(80, 47);
            this.lblBookPageInfo.Name = "lblBookPageInfo";
            this.lblBookPageInfo.Size = new System.Drawing.Size(35, 12);
            this.lblBookPageInfo.TabIndex = 11;
            this.lblBookPageInfo.Text = "0-0页";
            // 
            // cmbPicSize
            // 
            this.cmbPicSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPicSize.FormattingEnabled = true;
            this.cmbPicSize.Items.AddRange(new object[] {
            "小图",
            "中图",
            "大图"});
            this.cmbPicSize.Location = new System.Drawing.Point(93, 14);
            this.cmbPicSize.Name = "cmbPicSize";
            this.cmbPicSize.Size = new System.Drawing.Size(67, 20);
            this.cmbPicSize.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "图片大小：";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblBookInfo);
            this.groupBox8.Controls.Add(this.lblBookPageInfo);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Location = new System.Drawing.Point(3, 298);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(542, 71);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "图书信息";
            // 
            // lblBookInfo
            // 
            this.lblBookInfo.AutoSize = true;
            this.lblBookInfo.Location = new System.Drawing.Point(13, 17);
            this.lblBookInfo.Name = "lblBookInfo";
            this.lblBookInfo.Size = new System.Drawing.Size(89, 12);
            this.lblBookInfo.TabIndex = 16;
            this.lblBookInfo.Text = "图书信息暂无！";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.btnReset);
            this.groupBox5.Controls.Add(this.btnDownload);
            this.groupBox5.Controls.Add(this.btnParse);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 422);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(548, 152);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "操作";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 35);
            this.button1.TabIndex = 10;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(336, 18);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(68, 35);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(204, 18);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(68, 35);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "重新下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtUrl);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(542, 209);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "URL";
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.Location = new System.Drawing.Point(3, 17);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(536, 189);
            this.txtUrl.TabIndex = 21;
            this.txtUrl.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMax);
            this.groupBox3.Controls.Add(this.txtMin);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.chkAuxPage);
            this.groupBox3.Controls.Add(this.chkUseProxy);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtPort);
            this.groupBox3.Controls.Add(this.cmbPicSize);
            this.groupBox3.Controls.Add(this.txtHost);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(542, 72);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "下载设置";
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Location = new System.Drawing.Point(448, 17);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(84, 16);
            this.chkUseProxy.TabIndex = 22;
            this.chkUseProxy.Text = "Use Proxy?";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            this.chkUseProxy.CheckedChanged += new System.EventHandler(this.chkUseProxy_CheckedChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(387, 13);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(55, 21);
            this.txtPort.TabIndex = 21;
            this.txtPort.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(258, 13);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(123, 21);
            this.txtHost.TabIndex = 20;
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "Http Proxy:";
            // 
            // staBar
            // 
            this.staBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staBarStatus});
            this.staBar.Location = new System.Drawing.Point(0, 506);
            this.staBar.Name = "staBar";
            this.staBar.Size = new System.Drawing.Size(951, 22);
            this.staBar.TabIndex = 17;
            this.staBar.Text = "statusStrip1";
            // 
            // staBarStatus
            // 
            this.staBarStatus.Name = "staBarStatus";
            this.staBarStatus.Size = new System.Drawing.Size(41, 17);
            this.staBarStatus.Text = "Loaded";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(395, 249);
            this.txtLog.TabIndex = 20;
            this.txtLog.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox7);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(951, 482);
            this.splitContainer1.SplitterDistance = 548;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 21;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.groupBox3);
            this.groupBox7.Controls.Add(this.groupBox4);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(548, 422);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.webBrowser);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtLog);
            this.splitContainer2.Size = new System.Drawing.Size(395, 482);
            this.splitContainer2.SplitterDistance = 227;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "Sleeping:";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(258, 39);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(50, 21);
            this.txtMin.TabIndex = 26;
            this.txtMin.ValueChanged += new System.EventHandler(this.txtMin_ValueChanged);
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(331, 39);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(50, 21);
            this.txtMax.TabIndex = 27;
            this.txtMax.ValueChanged += new System.EventHandler(this.txtMax_ValueChanged);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(951, 528);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.staBar);
            this.Controls.Add(this.mnuMainMenu);
            this.MainMenuStrip = this.mnuMainMenu;
            this.Name = "MainForm";
            this.Text = "读秀下载器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.staBar.ResumeLayout(false);
            this.staBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private WebBrowser webBrowser;
        private MenuStrip mnuMainMenu;
        private ToolStripMenuItem mnuHelpMainMenu;
        private ToolStripMenuItem mntExit;
        private Button btnParse;
        private CheckBox chkAuxPage;
        private Label label2;
        private Label lblBookPageInfo;
        private ComboBox cmbPicSize;
        private Label label4;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private GroupBox groupBox8;
        private Label lblBookInfo;
        private ToolStripMenuItem mntSetting;
        private ToolStripMenuItem mnuSetDefaultFolder;
		#endregion
        private StatusStrip staBar;
        private Button btnDownload;
        private ToolStripStatusLabel staBarStatus;
        private RichTextBox txtLog;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private RichTextBox txtUrl;
        private GroupBox groupBox7;
        private Button btnReset;
        private TextBox txtPort;
        private TextBox txtHost;
        private Label label1;
        private CheckBox chkUseProxy;
        private Button button1;
        private NumericUpDown txtMax;
        private NumericUpDown txtMin;
        private Label label3;
	}
}