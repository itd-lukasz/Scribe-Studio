
namespace Scribe.Studio.Logs_Forms
{
    partial class gridForm
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
            this.configurationGroupBox = new System.Windows.Forms.GroupBox();
            this.datesGroup = new System.Windows.Forms.GroupBox();
            this.endDateEdit = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.startDateEdit = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            this.gridGroup = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.runButton = new Syncfusion.WinForms.Controls.SfButton();
            this.dataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.exportMessagesButton = new Syncfusion.WinForms.Controls.SfButton();
            this.configurationGroupBox.SuspendLayout();
            this.datesGroup.SuspendLayout();
            this.gridGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // configurationGroupBox
            // 
            this.configurationGroupBox.Controls.Add(this.exportMessagesButton);
            this.configurationGroupBox.Controls.Add(this.runButton);
            this.configurationGroupBox.Controls.Add(this.groupBox1);
            this.configurationGroupBox.Controls.Add(this.datesGroup);
            this.configurationGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.configurationGroupBox.Location = new System.Drawing.Point(2, 2);
            this.configurationGroupBox.Name = "configurationGroupBox";
            this.configurationGroupBox.Size = new System.Drawing.Size(1611, 340);
            this.configurationGroupBox.TabIndex = 0;
            this.configurationGroupBox.TabStop = false;
            this.configurationGroupBox.Text = "Configuration:";
            // 
            // datesGroup
            // 
            this.datesGroup.Controls.Add(this.endDateEdit);
            this.datesGroup.Controls.Add(this.startDateEdit);
            this.datesGroup.Location = new System.Drawing.Point(6, 25);
            this.datesGroup.Name = "datesGroup";
            this.datesGroup.Size = new System.Drawing.Size(200, 129);
            this.datesGroup.TabIndex = 0;
            this.datesGroup.TabStop = false;
            this.datesGroup.Text = "Dates range:";
            // 
            // endDateEdit
            // 
            this.endDateEdit.Location = new System.Drawing.Point(10, 79);
            this.endDateEdit.Name = "endDateEdit";
            this.endDateEdit.Size = new System.Drawing.Size(180, 38);
            this.endDateEdit.TabIndex = 1;
            // 
            // startDateEdit
            // 
            this.startDateEdit.Location = new System.Drawing.Point(10, 35);
            this.startDateEdit.Name = "startDateEdit";
            this.startDateEdit.Size = new System.Drawing.Size(180, 38);
            this.startDateEdit.TabIndex = 0;
            // 
            // gridGroup
            // 
            this.gridGroup.Controls.Add(this.dataGrid);
            this.gridGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGroup.Location = new System.Drawing.Point(2, 342);
            this.gridGroup.Name = "gridGroup";
            this.gridGroup.Size = new System.Drawing.Size(1611, 1108);
            this.gridGroup.TabIndex = 1;
            this.gridGroup.TabStop = false;
            this.gridGroup.Text = "Grid:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(212, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // runButton
            // 
            this.runButton.AccessibleName = "Button";
            this.runButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.runButton.Location = new System.Drawing.Point(947, 70);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(96, 28);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Show logs";
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleName = "Table";
            this.dataGrid.AllowEditing = false;
            this.dataGrid.AllowFiltering = true;
            this.dataGrid.AllowResizingColumns = true;
            this.dataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(3, 22);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.PreviewRowHeight = 42;
            this.dataGrid.ShowRowHeader = true;
            this.dataGrid.Size = new System.Drawing.Size(1605, 1083);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.Text = "sfDataGrid1";
            // 
            // exportMessagesButton
            // 
            this.exportMessagesButton.AccessibleName = "Button";
            this.exportMessagesButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.exportMessagesButton.Location = new System.Drawing.Point(924, 104);
            this.exportMessagesButton.Name = "exportMessagesButton";
            this.exportMessagesButton.Size = new System.Drawing.Size(167, 28);
            this.exportMessagesButton.TabIndex = 3;
            this.exportMessagesButton.Text = "Export messages";
            this.exportMessagesButton.Click += new System.EventHandler(this.exportMessagesButton_Click);
            // 
            // gridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1615, 1452);
            this.Controls.Add(this.gridGroup);
            this.Controls.Add(this.configurationGroupBox);
            this.Name = "gridForm";
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "ccccc";
            this.configurationGroupBox.ResumeLayout(false);
            this.datesGroup.ResumeLayout(false);
            this.gridGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox configurationGroupBox;
        private System.Windows.Forms.GroupBox gridGroup;
        private System.Windows.Forms.GroupBox datesGroup;
        private Syncfusion.WinForms.Input.SfDateTimeEdit endDateEdit;
        private Syncfusion.WinForms.Input.SfDateTimeEdit startDateEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.WinForms.Controls.SfButton runButton;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dataGrid;
        private Syncfusion.WinForms.Controls.SfButton exportMessagesButton;
    }
}