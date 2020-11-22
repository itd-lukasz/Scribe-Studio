
namespace Scribe.Studio.Configuration_Forms
{
    partial class environmentForm
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
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.nameTextEdit = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.colorButton = new Syncfusion.WinForms.Controls.SfButton();
            this.connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordTextEdit = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.userGroupBox = new System.Windows.Forms.GroupBox();
            this.userTextEdit = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.databaseGroupBox = new System.Windows.Forms.GroupBox();
            this.databaseTextEdit = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.serverGroupBox = new System.Windows.Forms.GroupBox();
            this.windowsCheckBox = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.serverTextEdit = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.saveBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.nameGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit)).BeginInit();
            this.colorGroupBox.SuspendLayout();
            this.connectionGroupBox.SuspendLayout();
            this.passwordGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit)).BeginInit();
            this.userGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userTextEdit)).BeginInit();
            this.databaseGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseTextEdit)).BeginInit();
            this.serverGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowsCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.nameTextEdit);
            this.nameGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameGroupBox.Location = new System.Drawing.Point(2, 2);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(692, 62);
            this.nameGroupBox.TabIndex = 0;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name:";
            // 
            // nameTextEdit
            // 
            this.nameTextEdit.BeforeTouchSize = new System.Drawing.Size(668, 26);
            this.nameTextEdit.Location = new System.Drawing.Point(6, 25);
            this.nameTextEdit.Name = "nameTextEdit";
            this.nameTextEdit.Size = new System.Drawing.Size(668, 26);
            this.nameTextEdit.TabIndex = 0;
            this.nameTextEdit.TextChanged += new System.EventHandler(this.nameTextEdit_TextChanged);
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.colorButton);
            this.colorGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorGroupBox.Location = new System.Drawing.Point(2, 64);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(692, 62);
            this.colorGroupBox.TabIndex = 1;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Color:";
            // 
            // colorButton
            // 
            this.colorButton.AccessibleName = "Button";
            this.colorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.colorButton.Location = new System.Drawing.Point(6, 25);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(668, 28);
            this.colorButton.TabIndex = 0;
            this.colorButton.Text = "Click to pick color";
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // connectionGroupBox
            // 
            this.connectionGroupBox.Controls.Add(this.passwordGroupBox);
            this.connectionGroupBox.Controls.Add(this.userGroupBox);
            this.connectionGroupBox.Controls.Add(this.databaseGroupBox);
            this.connectionGroupBox.Controls.Add(this.serverGroupBox);
            this.connectionGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.connectionGroupBox.Location = new System.Drawing.Point(2, 126);
            this.connectionGroupBox.Name = "connectionGroupBox";
            this.connectionGroupBox.Size = new System.Drawing.Size(692, 297);
            this.connectionGroupBox.TabIndex = 2;
            this.connectionGroupBox.TabStop = false;
            this.connectionGroupBox.Text = "Database Connection:";
            // 
            // passwordGroupBox
            // 
            this.passwordGroupBox.Controls.Add(this.passwordTextEdit);
            this.passwordGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordGroupBox.Location = new System.Drawing.Point(3, 234);
            this.passwordGroupBox.Name = "passwordGroupBox";
            this.passwordGroupBox.Size = new System.Drawing.Size(686, 62);
            this.passwordGroupBox.TabIndex = 5;
            this.passwordGroupBox.TabStop = false;
            this.passwordGroupBox.Text = "Password:";
            // 
            // passwordTextEdit
            // 
            this.passwordTextEdit.BeforeTouchSize = new System.Drawing.Size(668, 26);
            this.passwordTextEdit.Location = new System.Drawing.Point(6, 25);
            this.passwordTextEdit.Name = "passwordTextEdit";
            this.passwordTextEdit.PasswordChar = '●';
            this.passwordTextEdit.Size = new System.Drawing.Size(668, 26);
            this.passwordTextEdit.TabIndex = 0;
            this.passwordTextEdit.UseSystemPasswordChar = true;
            this.passwordTextEdit.TextChanged += new System.EventHandler(this.passwordTextEdit_TextChanged);
            // 
            // userGroupBox
            // 
            this.userGroupBox.Controls.Add(this.userTextEdit);
            this.userGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.userGroupBox.Location = new System.Drawing.Point(3, 172);
            this.userGroupBox.Name = "userGroupBox";
            this.userGroupBox.Size = new System.Drawing.Size(686, 62);
            this.userGroupBox.TabIndex = 4;
            this.userGroupBox.TabStop = false;
            this.userGroupBox.Text = "User:";
            // 
            // userTextEdit
            // 
            this.userTextEdit.BeforeTouchSize = new System.Drawing.Size(668, 26);
            this.userTextEdit.Location = new System.Drawing.Point(6, 25);
            this.userTextEdit.Name = "userTextEdit";
            this.userTextEdit.Size = new System.Drawing.Size(668, 26);
            this.userTextEdit.TabIndex = 0;
            this.userTextEdit.TextChanged += new System.EventHandler(this.userTextEdit_TextChanged);
            // 
            // databaseGroupBox
            // 
            this.databaseGroupBox.Controls.Add(this.databaseTextEdit);
            this.databaseGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.databaseGroupBox.Location = new System.Drawing.Point(3, 110);
            this.databaseGroupBox.Name = "databaseGroupBox";
            this.databaseGroupBox.Size = new System.Drawing.Size(686, 62);
            this.databaseGroupBox.TabIndex = 2;
            this.databaseGroupBox.TabStop = false;
            this.databaseGroupBox.Text = "Database:";
            // 
            // databaseTextEdit
            // 
            this.databaseTextEdit.BeforeTouchSize = new System.Drawing.Size(668, 26);
            this.databaseTextEdit.Location = new System.Drawing.Point(6, 25);
            this.databaseTextEdit.Name = "databaseTextEdit";
            this.databaseTextEdit.Size = new System.Drawing.Size(668, 26);
            this.databaseTextEdit.TabIndex = 0;
            this.databaseTextEdit.TextChanged += new System.EventHandler(this.databaseTextEdit_TextChanged);
            // 
            // serverGroupBox
            // 
            this.serverGroupBox.Controls.Add(this.windowsCheckBox);
            this.serverGroupBox.Controls.Add(this.serverTextEdit);
            this.serverGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.serverGroupBox.Location = new System.Drawing.Point(3, 22);
            this.serverGroupBox.Name = "serverGroupBox";
            this.serverGroupBox.Size = new System.Drawing.Size(686, 88);
            this.serverGroupBox.TabIndex = 1;
            this.serverGroupBox.TabStop = false;
            this.serverGroupBox.Text = "Server:";
            // 
            // windowsCheckBox
            // 
            this.windowsCheckBox.BeforeTouchSize = new System.Drawing.Size(238, 25);
            this.windowsCheckBox.ImageCheckBoxSize = new System.Drawing.Size(19, 19);
            this.windowsCheckBox.Location = new System.Drawing.Point(6, 57);
            this.windowsCheckBox.Name = "windowsCheckBox";
            this.windowsCheckBox.Size = new System.Drawing.Size(238, 25);
            this.windowsCheckBox.TabIndex = 1;
            this.windowsCheckBox.Text = "Windows authentication";
            this.windowsCheckBox.CheckedChanged += new System.EventHandler(this.windowsCheckBox_CheckedChanged);
            // 
            // serverTextEdit
            // 
            this.serverTextEdit.BeforeTouchSize = new System.Drawing.Size(668, 26);
            this.serverTextEdit.Location = new System.Drawing.Point(6, 25);
            this.serverTextEdit.Name = "serverTextEdit";
            this.serverTextEdit.Size = new System.Drawing.Size(668, 26);
            this.serverTextEdit.TabIndex = 0;
            this.serverTextEdit.TextChanged += new System.EventHandler(this.serverTextEdit_TextChanged);
            // 
            // saveBtn
            // 
            this.saveBtn.AccessibleName = "Button";
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.saveBtn.Location = new System.Drawing.Point(5, 428);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(677, 78);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // environmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 552);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.connectionGroupBox);
            this.Controls.Add(this.colorGroupBox);
            this.Controls.Add(this.nameGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "environmentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "environmentForm";
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit)).EndInit();
            this.colorGroupBox.ResumeLayout(false);
            this.connectionGroupBox.ResumeLayout(false);
            this.passwordGroupBox.ResumeLayout(false);
            this.passwordGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTextEdit)).EndInit();
            this.userGroupBox.ResumeLayout(false);
            this.userGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userTextEdit)).EndInit();
            this.databaseGroupBox.ResumeLayout(false);
            this.databaseGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseTextEdit)).EndInit();
            this.serverGroupBox.ResumeLayout(false);
            this.serverGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowsCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox nameGroupBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt nameTextEdit;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox colorGroupBox;
        private Syncfusion.WinForms.Controls.SfButton colorButton;
        private System.Windows.Forms.GroupBox connectionGroupBox;
        private System.Windows.Forms.GroupBox passwordGroupBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt passwordTextEdit;
        private System.Windows.Forms.GroupBox userGroupBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt userTextEdit;
        private System.Windows.Forms.GroupBox databaseGroupBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt databaseTextEdit;
        private System.Windows.Forms.GroupBox serverGroupBox;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv windowsCheckBox;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt serverTextEdit;
        private Syncfusion.WinForms.Controls.SfButton saveBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}