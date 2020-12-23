
namespace Scribe.Studio.Queue_Forms
{
    partial class importMessageForm
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
            this.selectFileGroup = new System.Windows.Forms.GroupBox();
            this.allFilesFromFolderCheck = new System.Windows.Forms.CheckBox();
            this.selectFileBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.messageSettings = new System.Windows.Forms.GroupBox();
            this.messageLabelTextBox = new System.Windows.Forms.TextBox();
            this.queueGroupBox = new System.Windows.Forms.GroupBox();
            this.queueCombo = new Syncfusion.WinForms.ListView.SfComboBox();
            this.saveBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.additionalSettingsGroup = new System.Windows.Forms.GroupBox();
            this.waitForQueueRadio = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.waitAfterBatchNumeric = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.waitAfterBatchRadio = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.batchSizeNumeric = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.batchSizeLabel = new System.Windows.Forms.Label();
            this.batchCheckBox = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.selectFileGroup.SuspendLayout();
            this.messageSettings.SuspendLayout();
            this.queueGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queueCombo)).BeginInit();
            this.additionalSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitForQueueRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitAfterBatchNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitAfterBatchRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchSizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // selectFileGroup
            // 
            this.selectFileGroup.Controls.Add(this.allFilesFromFolderCheck);
            this.selectFileGroup.Controls.Add(this.selectFileBtn);
            this.selectFileGroup.Controls.Add(this.fileTextBox);
            this.selectFileGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectFileGroup.Location = new System.Drawing.Point(2, 2);
            this.selectFileGroup.Name = "selectFileGroup";
            this.selectFileGroup.Size = new System.Drawing.Size(643, 93);
            this.selectFileGroup.TabIndex = 0;
            this.selectFileGroup.TabStop = false;
            this.selectFileGroup.Text = "Step 1: Select file";
            // 
            // allFilesFromFolderCheck
            // 
            this.allFilesFromFolderCheck.AutoSize = true;
            this.allFilesFromFolderCheck.Location = new System.Drawing.Point(6, 59);
            this.allFilesFromFolderCheck.Name = "allFilesFromFolderCheck";
            this.allFilesFromFolderCheck.Size = new System.Drawing.Size(205, 24);
            this.allFilesFromFolderCheck.TabIndex = 1;
            this.allFilesFromFolderCheck.Text = "Read all files from folder";
            this.allFilesFromFolderCheck.UseVisualStyleBackColor = true;
            this.allFilesFromFolderCheck.CheckedChanged += new System.EventHandler(this.allFilesFromFolderCheck_CheckedChanged);
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.AccessibleName = "Button";
            this.selectFileBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.selectFileBtn.Location = new System.Drawing.Point(519, 27);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(96, 26);
            this.selectFileBtn.TabIndex = 1;
            this.selectFileBtn.Text = "Select";
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(6, 27);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(507, 26);
            this.fileTextBox.TabIndex = 0;
            // 
            // messageSettings
            // 
            this.messageSettings.Controls.Add(this.messageLabelTextBox);
            this.messageSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageSettings.Location = new System.Drawing.Point(2, 95);
            this.messageSettings.Name = "messageSettings";
            this.messageSettings.Size = new System.Drawing.Size(643, 65);
            this.messageSettings.TabIndex = 1;
            this.messageSettings.TabStop = false;
            this.messageSettings.Text = "Step 2: Message label";
            // 
            // messageLabelTextBox
            // 
            this.messageLabelTextBox.Location = new System.Drawing.Point(6, 27);
            this.messageLabelTextBox.Name = "messageLabelTextBox";
            this.messageLabelTextBox.Size = new System.Drawing.Size(609, 26);
            this.messageLabelTextBox.TabIndex = 1;
            // 
            // queueGroupBox
            // 
            this.queueGroupBox.Controls.Add(this.queueCombo);
            this.queueGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.queueGroupBox.Location = new System.Drawing.Point(2, 160);
            this.queueGroupBox.Name = "queueGroupBox";
            this.queueGroupBox.Size = new System.Drawing.Size(643, 65);
            this.queueGroupBox.TabIndex = 2;
            this.queueGroupBox.TabStop = false;
            this.queueGroupBox.Text = "Step 3: Select queue";
            // 
            // queueCombo
            // 
            this.queueCombo.Location = new System.Drawing.Point(6, 33);
            this.queueCombo.Name = "queueCombo";
            this.queueCombo.Size = new System.Drawing.Size(609, 26);
            this.queueCombo.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.queueCombo.TabIndex = 2;
            // 
            // saveBtn
            // 
            this.saveBtn.AccessibleName = "Button";
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.saveBtn.Location = new System.Drawing.Point(8, 377);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(609, 78);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // additionalSettingsGroup
            // 
            this.additionalSettingsGroup.Controls.Add(this.waitForQueueRadio);
            this.additionalSettingsGroup.Controls.Add(this.waitAfterBatchNumeric);
            this.additionalSettingsGroup.Controls.Add(this.waitAfterBatchRadio);
            this.additionalSettingsGroup.Controls.Add(this.batchSizeNumeric);
            this.additionalSettingsGroup.Controls.Add(this.batchSizeLabel);
            this.additionalSettingsGroup.Controls.Add(this.batchCheckBox);
            this.additionalSettingsGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.additionalSettingsGroup.Location = new System.Drawing.Point(2, 225);
            this.additionalSettingsGroup.Name = "additionalSettingsGroup";
            this.additionalSettingsGroup.Size = new System.Drawing.Size(643, 146);
            this.additionalSettingsGroup.TabIndex = 5;
            this.additionalSettingsGroup.TabStop = false;
            this.additionalSettingsGroup.Text = "Step 4: Additional settings";
            // 
            // waitForQueueRadio
            // 
            this.waitForQueueRadio.BeforeTouchSize = new System.Drawing.Size(427, 36);
            this.waitForQueueRadio.ImageCheckBoxSize = new System.Drawing.Size(19, 19);
            this.waitForQueueRadio.Location = new System.Drawing.Point(6, 104);
            this.waitForQueueRadio.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.waitForQueueRadio.Name = "waitForQueueRadio";
            this.waitForQueueRadio.Size = new System.Drawing.Size(427, 36);
            this.waitForQueueRadio.TabIndex = 5;
            this.waitForQueueRadio.Text = "Wait until target queue will be empty";
            this.waitForQueueRadio.ThemesEnabled = true;
            this.waitForQueueRadio.CheckChanged += new System.EventHandler(this.waitForQueueRadio_CheckChanged);
            // 
            // waitAfterBatchNumeric
            // 
            this.waitAfterBatchNumeric.BeforeTouchSize = new System.Drawing.Size(120, 26);
            this.waitAfterBatchNumeric.Location = new System.Drawing.Point(439, 67);
            this.waitAfterBatchNumeric.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.waitAfterBatchNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.waitAfterBatchNumeric.Name = "waitAfterBatchNumeric";
            this.waitAfterBatchNumeric.Size = new System.Drawing.Size(120, 26);
            this.waitAfterBatchNumeric.TabIndex = 4;
            this.waitAfterBatchNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // waitAfterBatchRadio
            // 
            this.waitAfterBatchRadio.BeforeTouchSize = new System.Drawing.Size(427, 36);
            this.waitAfterBatchRadio.ImageCheckBoxSize = new System.Drawing.Size(19, 19);
            this.waitAfterBatchRadio.Location = new System.Drawing.Point(6, 62);
            this.waitAfterBatchRadio.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.waitAfterBatchRadio.Name = "waitAfterBatchRadio";
            this.waitAfterBatchRadio.Size = new System.Drawing.Size(427, 36);
            this.waitAfterBatchRadio.TabIndex = 3;
            this.waitAfterBatchRadio.Text = "Wait after each batch (seconds)";
            this.waitAfterBatchRadio.ThemesEnabled = true;
            this.waitAfterBatchRadio.CheckChanged += new System.EventHandler(this.waitAfterBatchRadio_CheckChanged);
            // 
            // batchSizeNumeric
            // 
            this.batchSizeNumeric.BeforeTouchSize = new System.Drawing.Size(120, 26);
            this.batchSizeNumeric.Location = new System.Drawing.Point(439, 28);
            this.batchSizeNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.batchSizeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.batchSizeNumeric.Name = "batchSizeNumeric";
            this.batchSizeNumeric.Size = new System.Drawing.Size(120, 26);
            this.batchSizeNumeric.TabIndex = 2;
            this.batchSizeNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // batchSizeLabel
            // 
            this.batchSizeLabel.AutoSize = true;
            this.batchSizeLabel.Location = new System.Drawing.Point(346, 30);
            this.batchSizeLabel.Name = "batchSizeLabel";
            this.batchSizeLabel.Size = new System.Drawing.Size(87, 20);
            this.batchSizeLabel.TabIndex = 1;
            this.batchSizeLabel.Text = "Batch size:";
            // 
            // batchCheckBox
            // 
            this.batchCheckBox.BeforeTouchSize = new System.Drawing.Size(343, 31);
            this.batchCheckBox.ImageCheckBoxSize = new System.Drawing.Size(19, 19);
            this.batchCheckBox.Location = new System.Drawing.Point(6, 25);
            this.batchCheckBox.Name = "batchCheckBox";
            this.batchCheckBox.Size = new System.Drawing.Size(343, 31);
            this.batchCheckBox.TabIndex = 0;
            this.batchCheckBox.Text = "Import messages in batches";
            this.batchCheckBox.CheckStateChanged += new System.EventHandler(this.batchCheckBox_CheckStateChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // importMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 534);
            this.Controls.Add(this.additionalSettingsGroup);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.queueGroupBox);
            this.Controls.Add(this.messageSettings);
            this.Controls.Add(this.selectFileGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "importMessageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "importMessageForm";
            this.selectFileGroup.ResumeLayout(false);
            this.selectFileGroup.PerformLayout();
            this.messageSettings.ResumeLayout(false);
            this.messageSettings.PerformLayout();
            this.queueGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queueCombo)).EndInit();
            this.additionalSettingsGroup.ResumeLayout(false);
            this.additionalSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitForQueueRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitAfterBatchNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitAfterBatchRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchSizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox selectFileGroup;
        private Syncfusion.WinForms.Controls.SfButton selectFileBtn;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.CheckBox allFilesFromFolderCheck;
        private System.Windows.Forms.GroupBox messageSettings;
        private System.Windows.Forms.TextBox messageLabelTextBox;
        private System.Windows.Forms.GroupBox queueGroupBox;
        private Syncfusion.WinForms.Controls.SfButton saveBtn;
        private Syncfusion.WinForms.ListView.SfComboBox queueCombo;
        private System.Windows.Forms.GroupBox additionalSettingsGroup;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv batchCheckBox;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv waitAfterBatchRadio;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt batchSizeNumeric;
        private System.Windows.Forms.Label batchSizeLabel;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt waitAfterBatchNumeric;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv waitForQueueRadio;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}