
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
            this.selectFileGroup = new System.Windows.Forms.GroupBox();
            this.allFilesFromFolderCheck = new System.Windows.Forms.CheckBox();
            this.selectFileBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.messageSettings = new System.Windows.Forms.GroupBox();
            this.messageLabelTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.queueCombo = new Syncfusion.WinForms.ListView.SfComboBox();
            this.saveBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.selectFileGroup.SuspendLayout();
            this.messageSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queueCombo)).BeginInit();
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
            this.selectFileGroup.Size = new System.Drawing.Size(657, 93);
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
            this.messageSettings.Size = new System.Drawing.Size(657, 65);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.queueCombo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(2, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 3: Select queue";
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
            this.saveBtn.Location = new System.Drawing.Point(8, 231);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(609, 78);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save";
            // 
            // importMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 404);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queueCombo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox selectFileGroup;
        private Syncfusion.WinForms.Controls.SfButton selectFileBtn;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.CheckBox allFilesFromFolderCheck;
        private System.Windows.Forms.GroupBox messageSettings;
        private System.Windows.Forms.TextBox messageLabelTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.WinForms.Controls.SfButton saveBtn;
        private Syncfusion.WinForms.ListView.SfComboBox queueCombo;
    }
}