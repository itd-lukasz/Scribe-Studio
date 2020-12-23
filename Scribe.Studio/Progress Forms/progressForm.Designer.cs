
namespace Scribe.Studio.Progress_Forms
{
    partial class progressForm
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
            this.operationGroup = new System.Windows.Forms.GroupBox();
            this.progressBar = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.detailsListView = new Syncfusion.WinForms.ListView.SfListView();
            this.closeBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.operationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            this.detailsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationGroup
            // 
            this.operationGroup.Controls.Add(this.progressBar);
            this.operationGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.operationGroup.Location = new System.Drawing.Point(2, 2);
            this.operationGroup.Name = "operationGroup";
            this.operationGroup.Size = new System.Drawing.Size(828, 78);
            this.operationGroup.TabIndex = 1;
            this.operationGroup.TabStop = false;
            this.operationGroup.Text = "Operation";
            // 
            // progressBar
            // 
            this.progressBar.BackMultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressBar.BackSegments = false;
            this.progressBar.CustomText = null;
            this.progressBar.CustomWaitingRender = false;
            this.progressBar.ForegroundImage = null;
            this.progressBar.Location = new System.Drawing.Point(12, 25);
            this.progressBar.MultipleColors = new System.Drawing.Color[] {
        System.Drawing.Color.Empty};
            this.progressBar.Name = "progressBar";
            this.progressBar.SegmentWidth = 12;
            this.progressBar.Size = new System.Drawing.Size(782, 41);
            this.progressBar.TabIndex = 0;
            this.progressBar.Text = "progressBar";
            this.progressBar.WaitingGradientWidth = 400;
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Controls.Add(this.detailsListView);
            this.detailsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.detailsGroupBox.Location = new System.Drawing.Point(2, 80);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(828, 271);
            this.detailsGroupBox.TabIndex = 2;
            this.detailsGroupBox.TabStop = false;
            this.detailsGroupBox.Text = "Details";
            // 
            // detailsListView
            // 
            this.detailsListView.AccessibleName = "ScrollControl";
            this.detailsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsListView.Location = new System.Drawing.Point(3, 22);
            this.detailsListView.Name = "detailsListView";
            this.detailsListView.Size = new System.Drawing.Size(822, 246);
            this.detailsListView.TabIndex = 0;
            // 
            // closeBtn
            // 
            this.closeBtn.AccessibleName = "Button";
            this.closeBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.closeBtn.Location = new System.Drawing.Point(2, 367);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(804, 78);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.Text = "Close";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // progressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 518);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.detailsGroupBox);
            this.Controls.Add(this.operationGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "progressForm";
            this.ShowIcon = false;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Progress....";
            this.operationGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            this.detailsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox operationGroup;
        private Syncfusion.Windows.Forms.Tools.ProgressBarAdv progressBar;
        private System.Windows.Forms.GroupBox detailsGroupBox;
        private Syncfusion.WinForms.ListView.SfListView detailsListView;
        private Syncfusion.WinForms.Controls.SfButton closeBtn;
    }
}