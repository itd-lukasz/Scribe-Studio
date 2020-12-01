
namespace Scribe.Studio
{
    partial class mainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.ribbonControl = new Syncfusion.Windows.Forms.Tools.RibbonControlAdv();
            this.applicationMenu = new Syncfusion.Windows.Forms.BackStageView(this.components);
            this.backstage = new Syncfusion.Windows.Forms.BackStage();
            this.environmentTab = new Syncfusion.Windows.Forms.BackStageTab();
            this.applicationMenuTabs = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.environmentsTab = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.environmentsGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.environmentsTabBottonPanel = new System.Windows.Forms.Panel();
            this.addEnvironmentBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.removeEnvironmentBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.queueTab = new Syncfusion.Windows.Forms.BackStageTab();
            this.queueList = new Syncfusion.WinForms.ListView.SfListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addQueueBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.removeQueueBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.saveConfigBtn = new Syncfusion.Windows.Forms.BackStageButton();
            this.mainTab = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.queueGroup = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.addMessageQueueFromFileBtn = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.ribbonControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backstage)).BeginInit();
            this.backstage.SuspendLayout();
            this.environmentTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenuTabs)).BeginInit();
            this.applicationMenuTabs.SuspendLayout();
            this.environmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.environmentsGrid)).BeginInit();
            this.environmentsTabBottonPanel.SuspendLayout();
            this.queueTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainTab.Panel.SuspendLayout();
            this.queueGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.BackStageView = this.applicationMenu;
            this.ribbonControl.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Top;
            this.ribbonControl.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ribbonControl.Header.AddMainItem(mainTab);
            this.ribbonControl.Location = new System.Drawing.Point(1, 0);
            this.ribbonControl.MenuButtonFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ribbonControl.MenuButtonText = "File";
            this.ribbonControl.MenuButtonWidth = 56;
            this.ribbonControl.MenuColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Managed;
            // 
            // ribbonControl.OfficeMenu
            // 
            this.ribbonControl.OfficeMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ribbonControl.OfficeMenu.Name = "OfficeMenu";
            this.ribbonControl.OfficeMenu.ShowItemToolTips = true;
            this.ribbonControl.OfficeMenu.Size = new System.Drawing.Size(12, 65);
            this.ribbonControl.QuickPanelImageLayout = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ribbonControl.QuickPanelVisible = false;
            this.ribbonControl.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.None;
            this.ribbonControl.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2016;
            this.ribbonControl.SelectedTab = null;
            this.ribbonControl.ShowRibbonDisplayOptionButton = true;
            this.ribbonControl.Size = new System.Drawing.Size(2053, 339);
            this.ribbonControl.SystemText.QuickAccessDialogDropDownName = "Start menu";
            this.ribbonControl.SystemText.RenameDisplayLabelText = "&Display Name:";
            this.ribbonControl.TabIndex = 0;
            this.ribbonControl.Text = "ribbonControlAdv1";
            this.ribbonControl.ThemeName = "Office2016";
            this.ribbonControl.MenuButtonClick += new System.EventHandler(this.ribbonControl_MenuButtonClick);
            // 
            // applicationMenu
            // 
            this.applicationMenu.BackStage = this.backstage;
            this.applicationMenu.HostControl = null;
            this.applicationMenu.HostForm = this;
            // 
            // backstage
            // 
            this.backstage.AllowDrop = true;
            this.backstage.BackStagePanelWidth = 190;
            this.backstage.BeforeTouchSize = new System.Drawing.Size(2053, 1443);
            this.backstage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.backstage.ChildItemSize = new System.Drawing.Size(80, 140);
            this.backstage.Controls.Add(this.environmentTab);
            this.backstage.Controls.Add(this.queueTab);
            this.backstage.Controls.Add(this.saveConfigBtn);
            this.backstage.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.backstage.ItemSize = new System.Drawing.Size(190, 40);
            this.backstage.Location = new System.Drawing.Point(0, 103);
            this.backstage.Name = "backstage";
            this.backstage.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Managed;
            this.backstage.Size = new System.Drawing.Size(2053, 1443);
            this.backstage.TabIndex = 1;
            this.backstage.ThemeName = "BackStage2016Renderer";
            // 
            // environmentTab
            // 
            this.environmentTab.Accelerator = "";
            this.environmentTab.BackColor = System.Drawing.Color.White;
            this.environmentTab.Controls.Add(this.applicationMenuTabs);
            this.environmentTab.Image = null;
            this.environmentTab.ImageSize = new System.Drawing.Size(24, 24);
            this.environmentTab.Location = new System.Drawing.Point(189, 0);
            this.environmentTab.Name = "environmentTab";
            this.environmentTab.Position = new System.Drawing.Point(11, 68);
            this.environmentTab.ShowCloseButton = true;
            this.environmentTab.Size = new System.Drawing.Size(1864, 1443);
            this.environmentTab.TabIndex = 3;
            this.environmentTab.Text = "Environments";
            this.environmentTab.ThemesEnabled = false;
            // 
            // applicationMenuTabs
            // 
            this.applicationMenuTabs.BeforeTouchSize = new System.Drawing.Size(1864, 1443);
            this.applicationMenuTabs.Controls.Add(this.environmentsTab);
            this.applicationMenuTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applicationMenuTabs.Location = new System.Drawing.Point(0, 0);
            this.applicationMenuTabs.Name = "applicationMenuTabs";
            this.applicationMenuTabs.Size = new System.Drawing.Size(1864, 1443);
            this.applicationMenuTabs.TabIndex = 0;
            this.applicationMenuTabs.ThemesEnabled = true;
            this.applicationMenuTabs.SelectedIndexChanged += new System.EventHandler(this.applicationMenuTabs_SelectedIndexChanged);
            // 
            // environmentsTab
            // 
            this.environmentsTab.Controls.Add(this.environmentsGrid);
            this.environmentsTab.Controls.Add(this.environmentsTabBottonPanel);
            this.environmentsTab.Image = null;
            this.environmentsTab.ImageSize = new System.Drawing.Size(24, 24);
            this.environmentsTab.Location = new System.Drawing.Point(3, 38);
            this.environmentsTab.Name = "environmentsTab";
            this.environmentsTab.ShowCloseButton = true;
            this.environmentsTab.Size = new System.Drawing.Size(1857, 1401);
            this.environmentsTab.TabIndex = 1;
            this.environmentsTab.Text = "Environments";
            this.environmentsTab.ThemesEnabled = true;
            // 
            // environmentsGrid
            // 
            this.environmentsGrid.AccessibleName = "Table";
            this.environmentsGrid.BackColor = System.Drawing.Color.LightGray;
            this.environmentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.environmentsGrid.Location = new System.Drawing.Point(0, 0);
            this.environmentsGrid.Name = "environmentsGrid";
            this.environmentsGrid.PreviewRowHeight = 42;
            this.environmentsGrid.Size = new System.Drawing.Size(1857, 1267);
            this.environmentsGrid.TabIndex = 1;
            this.environmentsGrid.QueryCellStyle += new Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventHandler(this.environmentsGrid_QueryCellStyle);
            this.environmentsGrid.CellDoubleClick += new Syncfusion.WinForms.DataGrid.Events.CellClickEventHandler(this.environmentsGrid_CellDoubleClick);
            // 
            // environmentsTabBottonPanel
            // 
            this.environmentsTabBottonPanel.Controls.Add(this.addEnvironmentBtn);
            this.environmentsTabBottonPanel.Controls.Add(this.removeEnvironmentBtn);
            this.environmentsTabBottonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.environmentsTabBottonPanel.Location = new System.Drawing.Point(0, 1267);
            this.environmentsTabBottonPanel.Name = "environmentsTabBottonPanel";
            this.environmentsTabBottonPanel.Size = new System.Drawing.Size(1857, 134);
            this.environmentsTabBottonPanel.TabIndex = 0;
            // 
            // addEnvironmentBtn
            // 
            this.addEnvironmentBtn.AccessibleName = "Button";
            this.addEnvironmentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addEnvironmentBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.addEnvironmentBtn.Location = new System.Drawing.Point(1682, 3);
            this.addEnvironmentBtn.Name = "addEnvironmentBtn";
            this.addEnvironmentBtn.Size = new System.Drawing.Size(172, 81);
            this.addEnvironmentBtn.TabIndex = 1;
            this.addEnvironmentBtn.Text = "Add";
            this.addEnvironmentBtn.Click += new System.EventHandler(this.addEnvironmentBtn_Click);
            // 
            // removeEnvironmentBtn
            // 
            this.removeEnvironmentBtn.AccessibleName = "Button";
            this.removeEnvironmentBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.removeEnvironmentBtn.Location = new System.Drawing.Point(3, 3);
            this.removeEnvironmentBtn.Name = "removeEnvironmentBtn";
            this.removeEnvironmentBtn.Size = new System.Drawing.Size(172, 81);
            this.removeEnvironmentBtn.TabIndex = 0;
            this.removeEnvironmentBtn.Text = "Remove";
            // 
            // queueTab
            // 
            this.queueTab.Accelerator = "";
            this.queueTab.BackColor = System.Drawing.Color.White;
            this.queueTab.Controls.Add(this.queueList);
            this.queueTab.Controls.Add(this.panel1);
            this.queueTab.Image = null;
            this.queueTab.ImageSize = new System.Drawing.Size(24, 24);
            this.queueTab.Location = new System.Drawing.Point(189, 0);
            this.queueTab.Name = "queueTab";
            this.queueTab.Position = new System.Drawing.Point(69, 126);
            this.queueTab.ShowCloseButton = true;
            this.queueTab.Size = new System.Drawing.Size(1864, 1443);
            this.queueTab.TabIndex = 5;
            this.queueTab.Text = "Queues";
            this.queueTab.ThemesEnabled = false;
            this.queueTab.VisibleChanged += new System.EventHandler(this.queueTab_VisibleChanged);
            // 
            // queueList
            // 
            this.queueList.AccessibleName = "ScrollControl";
            this.queueList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queueList.Location = new System.Drawing.Point(0, 0);
            this.queueList.Name = "queueList";
            this.queueList.Size = new System.Drawing.Size(1864, 1309);
            this.queueList.TabIndex = 2;
            this.queueList.Text = "sfListView1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addQueueBtn);
            this.panel1.Controls.Add(this.removeQueueBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 1309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1864, 134);
            this.panel1.TabIndex = 1;
            // 
            // addQueueBtn
            // 
            this.addQueueBtn.AccessibleName = "Button";
            this.addQueueBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addQueueBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.addQueueBtn.Location = new System.Drawing.Point(1689, 3);
            this.addQueueBtn.Name = "addQueueBtn";
            this.addQueueBtn.Size = new System.Drawing.Size(172, 81);
            this.addQueueBtn.TabIndex = 1;
            this.addQueueBtn.Text = "Add";
            this.addQueueBtn.Click += new System.EventHandler(this.addQueueBtn_Click);
            // 
            // removeQueueBtn
            // 
            this.removeQueueBtn.AccessibleName = "Button";
            this.removeQueueBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.removeQueueBtn.Location = new System.Drawing.Point(3, 3);
            this.removeQueueBtn.Name = "removeQueueBtn";
            this.removeQueueBtn.Size = new System.Drawing.Size(172, 81);
            this.removeQueueBtn.TabIndex = 0;
            this.removeQueueBtn.Text = "Remove";
            this.removeQueueBtn.Click += new System.EventHandler(this.removeQueueBtn_Click);
            // 
            // saveConfigBtn
            // 
            this.saveConfigBtn.Accelerator = "";
            this.saveConfigBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveConfigBtn.Location = new System.Drawing.Point(0, 104);
            this.saveConfigBtn.Name = "saveConfigBtn";
            this.saveConfigBtn.Size = new System.Drawing.Size(189, 45);
            this.saveConfigBtn.TabIndex = 4;
            this.saveConfigBtn.Text = "Save configuration";
            this.saveConfigBtn.Click += new System.EventHandler(this.saveConfigBtn_Click);
            // 
            // mainTab
            // 
            this.mainTab.Name = "mainTab";
            // 
            // ribbonControl.ribbonPanel1
            // 
            this.mainTab.Panel.Controls.Add(this.queueGroup);
            this.mainTab.Panel.Name = "ribbonPanel1";
            this.mainTab.Panel.ScrollPosition = 0;
            this.mainTab.Panel.TabIndex = 2;
            this.mainTab.Panel.Text = "Main Operations";
            this.mainTab.Position = 0;
            this.mainTab.Size = new System.Drawing.Size(161, 52);
            this.mainTab.Tag = "1";
            this.mainTab.Text = "Main Operations";
            // 
            // queueGroup
            // 
            this.queueGroup.Dock = System.Windows.Forms.DockStyle.None;
            this.queueGroup.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.queueGroup.ForeColor = System.Drawing.Color.MidnightBlue;
            this.queueGroup.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.queueGroup.Image = null;
            this.queueGroup.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.queueGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMessageQueueFromFileBtn});
            this.queueGroup.Location = new System.Drawing.Point(0, 1);
            this.queueGroup.Name = "queueGroup";
            this.queueGroup.Office12Mode = false;
            this.queueGroup.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.queueGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.queueGroup.Size = new System.Drawing.Size(203, 231);
            this.queueGroup.TabIndex = 0;
            this.queueGroup.Text = "Queue";
            // 
            // addMessageQueueFromFileBtn
            // 
            this.addMessageQueueFromFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("addMessageQueueFromFileBtn.Image")));
            this.addMessageQueueFromFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addMessageQueueFromFileBtn.Name = "addMessageQueueFromFileBtn";
            this.addMessageQueueFromFileBtn.Size = new System.Drawing.Size(194, 206);
            this.addMessageQueueFromFileBtn.Text = "Add Message To Queue";
            this.addMessageQueueFromFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addMessageQueueFromFileBtn.Click += new System.EventHandler(this.addMessageQueueFromFileBtn_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2055, 1495);
            this.Controls.Add(this.backstage);
            this.Controls.Add(this.ribbonControl);
            this.Name = "mainForm";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.ShowApplicationIcon = false;
            this.Text = "Scribe Studio";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ribbonControl.ResumeLayout(false);
            this.ribbonControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backstage)).EndInit();
            this.backstage.ResumeLayout(false);
            this.environmentTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenuTabs)).EndInit();
            this.applicationMenuTabs.ResumeLayout(false);
            this.environmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.environmentsGrid)).EndInit();
            this.environmentsTabBottonPanel.ResumeLayout(false);
            this.queueTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.mainTab.Panel.ResumeLayout(false);
            this.mainTab.Panel.PerformLayout();
            this.queueGroup.ResumeLayout(false);
            this.queueGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.RibbonControlAdv ribbonControl;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem mainTab;
        private Syncfusion.Windows.Forms.BackStageView applicationMenu;
        private Syncfusion.Windows.Forms.BackStage backstage;
        private Syncfusion.Windows.Forms.BackStageTab environmentTab;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv applicationMenuTabs;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv environmentsTab;
        private System.Windows.Forms.Panel environmentsTabBottonPanel;
        private Syncfusion.WinForms.Controls.SfButton removeEnvironmentBtn;
        private Syncfusion.WinForms.Controls.SfButton addEnvironmentBtn;
        private Syncfusion.WinForms.DataGrid.SfDataGrid environmentsGrid;
        private Syncfusion.Windows.Forms.BackStageButton saveConfigBtn;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx queueGroup;
        private System.Windows.Forms.ToolStripButton addMessageQueueFromFileBtn;
        private Syncfusion.Windows.Forms.BackStageTab queueTab;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.WinForms.Controls.SfButton addQueueBtn;
        private Syncfusion.WinForms.Controls.SfButton removeQueueBtn;
        private Syncfusion.WinForms.ListView.SfListView queueList;
    }
}

