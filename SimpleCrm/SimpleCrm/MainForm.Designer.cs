namespace SimpleCrm
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
            this.components = new System.ComponentModel.Container();
            this.cmdCustomerMain = new DevComponents.DotNetBar.Command(this.components);
            this.cmdUserMain = new DevComponents.DotNetBar.Command(this.components);
            this.cmdLovMain = new DevComponents.DotNetBar.Command(this.components);
            this.cmbAddCustomer = new DevComponents.DotNetBar.Command(this.components);
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.btnUserMain = new DevComponents.DotNetBar.ButtonItem();
            this.btnChangePassword = new DevComponents.DotNetBar.ButtonItem();
            this.cmdChangePassword = new DevComponents.DotNetBar.Command(this.components);
            this.btnLovMain = new DevComponents.DotNetBar.ButtonItem();
            this.btnRegister = new DevComponents.DotNetBar.ButtonItem();
            this.cmdRegister = new DevComponents.DotNetBar.Command(this.components);
            this.btnAbount = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel3 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.btnSchedule = new DevComponents.DotNetBar.ButtonItem();
            this.cmdScheduleMain = new DevComponents.DotNetBar.Command(this.components);
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnBirthdayPendingItem = new DevComponents.DotNetBar.ButtonItem();
            this.btnRenewalPremium = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabSchedule = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem2 = new DevComponents.DotNetBar.RibbonTabItem();
            this.btnHome = new DevComponents.DotNetBar.ButtonItem();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
            this.tabStrip1 = new DevComponents.DotNetBar.TabStrip();
            this.btnImportCustomer = new DevComponents.DotNetBar.ButtonItem();
            this.cmdImportCustomer = new DevComponents.DotNetBar.Command(this.components);
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.ribbonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCustomerMain
            // 
            this.cmdCustomerMain.Name = "cmdCustomerMain";
            this.cmdCustomerMain.Executed += new System.EventHandler(this.cmdCustomerManagement_Executed);
            // 
            // cmdUserMain
            // 
            this.cmdUserMain.Name = "cmdUserMain";
            this.cmdUserMain.Executed += new System.EventHandler(this.cmdUserMain_Executed);
            // 
            // cmdLovMain
            // 
            this.cmdLovMain.Name = "cmdLovMain";
            this.cmdLovMain.Executed += new System.EventHandler(this.cmdLovMain_Executed);
            // 
            // cmbAddCustomer
            // 
            this.cmbAddCustomer.Name = "cmbAddCustomer";
            this.cmbAddCustomer.Executed += new System.EventHandler(this.cmbAddCustomer_Executed);
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Controls.Add(this.ribbonPanel2);
            this.ribbonControl1.Controls.Add(this.ribbonPanel3);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem1,
            this.ribbonTabSchedule,
            this.ribbonTabItem2});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.MdiSystemItemVisible = false;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnHome,
            this.qatCustomizeItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(803, 115);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 17;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(803, 59);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
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
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.btnImportCustomer});
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(195, 56);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
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
            // buttonItem1
            // 
            this.buttonItem1.BeginGroup = true;
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Command = this.cmdCustomerMain;
            this.buttonItem1.Image = global::SimpleCrm.Properties.Resources.user;
            this.buttonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SplitButton = true;
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "客户管理";
            // 
            // buttonItem2
            // 
            this.buttonItem2.BeginGroup = true;
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Command = this.cmbAddCustomer;
            this.buttonItem2.Image = global::SimpleCrm.Properties.Resources.user_add;
            this.buttonItem2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SplitButton = true;
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "新增客户";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel2.Controls.Add(this.ribbonBar2);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(803, 59);
            // 
            // 
            // 
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 2;
            this.ribbonPanel2.Visible = false;
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnUserMain,
            this.btnChangePassword,
            this.btnLovMain,
            this.btnRegister,
            this.btnAbount});
            this.ribbonBar2.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(341, 56);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.TitleVisible = false;
            // 
            // btnUserMain
            // 
            this.btnUserMain.BeginGroup = true;
            this.btnUserMain.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnUserMain.Command = this.cmdUserMain;
            this.btnUserMain.Image = global::SimpleCrm.Properties.Resources.group;
            this.btnUserMain.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnUserMain.Name = "btnUserMain";
            this.btnUserMain.SplitButton = true;
            this.btnUserMain.SubItemsExpandWidth = 14;
            this.btnUserMain.Text = "用户管理";
            this.btnUserMain.Visible = false;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BeginGroup = true;
            this.btnChangePassword.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnChangePassword.Command = this.cmdChangePassword;
            this.btnChangePassword.Image = global::SimpleCrm.Properties.Resources._lock;
            this.btnChangePassword.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.SubItemsExpandWidth = 14;
            this.btnChangePassword.Text = "修改密码";
            // 
            // cmdChangePassword
            // 
            this.cmdChangePassword.Name = "cmdChangePassword";
            this.cmdChangePassword.Executed += new System.EventHandler(this.cmdChangePassword_Executed);
            // 
            // btnLovMain
            // 
            this.btnLovMain.BeginGroup = true;
            this.btnLovMain.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnLovMain.Command = this.cmdLovMain;
            this.btnLovMain.Image = global::SimpleCrm.Properties.Resources.configuration_edit;
            this.btnLovMain.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLovMain.Name = "btnLovMain";
            this.btnLovMain.SplitButton = true;
            this.btnLovMain.SubItemsExpandWidth = 14;
            this.btnLovMain.Text = "基础数据管理";
            // 
            // btnRegister
            // 
            this.btnRegister.BeginGroup = true;
            this.btnRegister.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRegister.Command = this.cmdRegister;
            this.btnRegister.Image = global::SimpleCrm.Properties.Resources.upload;
            this.btnRegister.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.SubItemsExpandWidth = 14;
            this.btnRegister.Text = "注册";
            // 
            // cmdRegister
            // 
            this.cmdRegister.Name = "cmdRegister";
            this.cmdRegister.Executed += new System.EventHandler(this.cmdRegister_Executed);
            // 
            // btnAbount
            // 
            this.btnAbount.BeginGroup = true;
            this.btnAbount.Name = "btnAbount";
            this.btnAbount.SubItemsExpandWidth = 14;
            this.btnAbount.Text = "关于";
            this.btnAbount.Click += new System.EventHandler(this.btnAbount_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel3.Controls.Add(this.ribbonBar4);
            this.ribbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel3.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel3.Size = new System.Drawing.Size(803, 59);
            // 
            // 
            // 
            this.ribbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel3.TabIndex = 3;
            this.ribbonPanel3.Visible = false;
            // 
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.ContainerControlProcessDialogKey = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar4.DragDropSupport = true;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSchedule,
            this.buttonItem3});
            this.ribbonBar4.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(797, 56);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar4.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.TitleVisible = false;
            // 
            // btnSchedule
            // 
            this.btnSchedule.BeginGroup = true;
            this.btnSchedule.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSchedule.Command = this.cmdScheduleMain;
            this.btnSchedule.Image = global::SimpleCrm.Properties.Resources.schedule;
            this.btnSchedule.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.SplitButton = true;
            this.btnSchedule.SubItemsExpandWidth = 14;
            this.btnSchedule.Text = "日程安排";
            // 
            // cmdScheduleMain
            // 
            this.cmdScheduleMain.Name = "cmdScheduleMain";
            this.cmdScheduleMain.Executed += new System.EventHandler(this.cmdScheduleMain_Executed);
            // 
            // buttonItem3
            // 
            this.buttonItem3.BeginGroup = true;
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.Image = global::SimpleCrm.Properties.Resources.to_do_list;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnBirthdayPendingItem,
            this.btnRenewalPremium});
            this.buttonItem3.SubItemsExpandWidth = 14;
            this.buttonItem3.Text = "待办事项";
            // 
            // btnBirthdayPendingItem
            // 
            this.btnBirthdayPendingItem.Name = "btnBirthdayPendingItem";
            this.btnBirthdayPendingItem.Text = "生日提醒";
            this.btnBirthdayPendingItem.Click += new System.EventHandler(this.btnBirthdayPendingItem_Click);
            // 
            // btnRenewalPremium
            // 
            this.btnRenewalPremium.Name = "btnRenewalPremium";
            this.btnRenewalPremium.Text = "续期保费";
            this.btnRenewalPremium.Click += new System.EventHandler(this.btnRenewalPremium_Click);
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Checked = true;
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "客户";
            // 
            // ribbonTabSchedule
            // 
            this.ribbonTabSchedule.Name = "ribbonTabSchedule";
            this.ribbonTabSchedule.Panel = this.ribbonPanel3;
            this.ribbonTabSchedule.Text = "日程管理";
            // 
            // ribbonTabItem2
            // 
            this.ribbonTabItem2.Name = "ribbonTabItem2";
            this.ribbonTabItem2.Panel = this.ribbonPanel2;
            this.ribbonTabItem2.Text = "系统";
            // 
            // btnHome
            // 
            this.btnHome.Name = "btnHome";
            this.btnHome.Text = "主页";
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // styleManager
            // 
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // tabStrip1
            // 
            this.tabStrip1.AutoSelectAttachedControl = true;
            this.tabStrip1.CanReorderTabs = true;
            this.tabStrip1.CloseButtonVisible = true;
            this.tabStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabStrip1.Location = new System.Drawing.Point(5, 116);
            this.tabStrip1.MdiAutoHide = false;
            this.tabStrip1.MdiForm = this;
            this.tabStrip1.MdiTabbedDocuments = true;
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.SelectedTab = null;
            this.tabStrip1.SelectedTabFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold);
            this.tabStrip1.Size = new System.Drawing.Size(803, 23);
            this.tabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabStrip1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top;
            this.tabStrip1.TabIndex = 18;
            this.tabStrip1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabStrip1.Text = "tabStrip1";
            // 
            // btnImportCustomer
            // 
            this.btnImportCustomer.BeginGroup = true;
            this.btnImportCustomer.Command = this.cmdImportCustomer;
            this.btnImportCustomer.Image = global::SimpleCrm.Properties.Resources.download;
            this.btnImportCustomer.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnImportCustomer.Name = "btnImportCustomer";
            this.btnImportCustomer.SubItemsExpandWidth = 14;
            this.btnImportCustomer.Text = "导入客户";
            // 
            // cmdImportCustomer
            // 
            this.cmdImportCustomer.Name = "cmdImportCustomer";
            this.cmdImportCustomer.Executed += new System.EventHandler(this.cmdImportCustomer_Executed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 528);
            this.Controls.Add(this.tabStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户关系管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            this.ribbonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Command cmdCustomerMain;
        private DevComponents.DotNetBar.Command cmdUserMain;
        private DevComponents.DotNetBar.Command cmdLovMain;
        private DevComponents.DotNetBar.Command cmbAddCustomer;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.ButtonItem btnHome;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.StyleManager styleManager;
        private DevComponents.DotNetBar.TabStrip tabStrip1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.ButtonItem btnUserMain;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem2;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel3;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.ButtonItem btnSchedule;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabSchedule;
        private DevComponents.DotNetBar.Command cmdScheduleMain;
        private DevComponents.DotNetBar.ButtonItem btnLovMain;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem btnBirthdayPendingItem;
        private DevComponents.DotNetBar.ButtonItem btnRenewalPremium;
        private DevComponents.DotNetBar.ButtonItem btnRegister;
        private DevComponents.DotNetBar.Command cmdRegister;
        private DevComponents.DotNetBar.ButtonItem btnChangePassword;
        private DevComponents.DotNetBar.Command cmdChangePassword;
        private DevComponents.DotNetBar.ButtonItem btnAbount;
        private DevComponents.DotNetBar.ButtonItem btnImportCustomer;
        private DevComponents.DotNetBar.Command cmdImportCustomer;
    }
}

