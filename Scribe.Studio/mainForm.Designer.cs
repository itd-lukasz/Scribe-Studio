
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
            this.ribbonControl = new Syncfusion.Windows.Forms.Tools.RibbonControlAdv();
            this.applicationMenu = new Syncfusion.Windows.Forms.BackStageView(this.components);
            this.backstage = new Syncfusion.Windows.Forms.BackStage();
            this.mainBackstageTab = new Syncfusion.Windows.Forms.BackStageTab();
            this.applicationMenuTabs = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.environmentsTab = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.environmentsGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.environmentsTabBottonPanel = new System.Windows.Forms.Panel();
            this.addEnvironmentBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.removeEnvironmentBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.saveConfigBtn = new Syncfusion.Windows.Forms.BackStageButton();
            this.mainTab = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.ribbonControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backstage)).BeginInit();
            this.backstage.SuspendLayout();
            this.mainBackstageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenuTabs)).BeginInit();
            this.applicationMenuTabs.SuspendLayout();
            this.environmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.environmentsGrid)).BeginInit();
            this.environmentsTabBottonPanel.SuspendLayout();
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
            this.backstage.Controls.Add(this.mainBackstageTab);
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
            // mainBackstageTab
            // 
            this.mainBackstageTab.Accelerator = "";
            this.mainBackstageTab.BackColor = System.Drawing.Color.White;
            this.mainBackstageTab.Controls.Add(this.applicationMenuTabs);
            this.mainBackstageTab.Image = null;
            this.mainBackstageTab.ImageSize = new System.Drawing.Size(24, 24);
            this.mainBackstageTab.Location = new System.Drawing.Point(189, 0);
            this.mainBackstageTab.Name = "mainBackstageTab";
            this.mainBackstageTab.Position = new System.Drawing.Point(11, 68);
            this.mainBackstageTab.ShowCloseButton = true;
            this.mainBackstageTab.Size = new System.Drawing.Size(1864, 1443);
            this.mainBackstageTab.TabIndex = 3;
            this.mainBackstageTab.Text = "Settings";
            this.mainBackstageTab.ThemesEnabled = false;
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
            // saveConfigBtn
            // 
            this.saveConfigBtn.Accelerator = "";
            this.saveConfigBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveConfigBtn.Location = new System.Drawing.Point(0, 57);
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
            this.mainTab.Panel.Name = "ribbonPanel1";
            this.mainTab.Panel.ScrollPosition = 0;
            this.mainTab.Panel.TabIndex = 2;
            this.mainTab.Panel.Text = "toolStripTabItem1";
            this.mainTab.Position = 0;
            this.mainTab.Size = new System.Drawing.Size(168, 52);
            this.mainTab.Tag = "1";
            this.mainTab.Text = "toolStripTabItem1";
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
            this.mainBackstageTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenuTabs)).EndInit();
            this.applicationMenuTabs.ResumeLayout(false);
            this.environmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.environmentsGrid)).EndInit();
            this.environmentsTabBottonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.RibbonControlAdv ribbonControl;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem mainTab;
        private Syncfusion.Windows.Forms.BackStageView applicationMenu;
        private Syncfusion.Windows.Forms.BackStage backstage;
        private Syncfusion.Windows.Forms.BackStageTab mainBackstageTab;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv applicationMenuTabs;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv environmentsTab;
        private System.Windows.Forms.Panel environmentsTabBottonPanel;
        private Syncfusion.WinForms.Controls.SfButton removeEnvironmentBtn;
        private Syncfusion.WinForms.Controls.SfButton addEnvironmentBtn;
        private Syncfusion.WinForms.DataGrid.SfDataGrid environmentsGrid;
        private Syncfusion.Windows.Forms.BackStageButton saveConfigBtn;
    }
}

