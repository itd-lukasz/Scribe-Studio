
namespace Scribe.Studio.Queue_Forms
{
    partial class queueForm
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
            this.nameGroup = new System.Windows.Forms.GroupBox();
            this.queueTextBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.nameGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameGroup
            // 
            this.nameGroup.Controls.Add(this.queueTextBox);
            this.nameGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameGroup.Location = new System.Drawing.Point(2, 2);
            this.nameGroup.Name = "nameGroup";
            this.nameGroup.Size = new System.Drawing.Size(635, 61);
            this.nameGroup.TabIndex = 0;
            this.nameGroup.TabStop = false;
            this.nameGroup.Text = "Queue name:";
            // 
            // queueTextBox
            // 
            this.queueTextBox.Location = new System.Drawing.Point(6, 25);
            this.queueTextBox.Name = "queueTextBox";
            this.queueTextBox.Size = new System.Drawing.Size(609, 26);
            this.queueTextBox.TabIndex = 6;
            // 
            // saveBtn
            // 
            this.saveBtn.AccessibleName = "Button";
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.saveBtn.Location = new System.Drawing.Point(8, 69);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(609, 78);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // queueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 192);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.nameGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "queueForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "addQueueForm";
            this.nameGroup.ResumeLayout(false);
            this.nameGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox nameGroup;
        private System.Windows.Forms.TextBox queueTextBox;
        private Syncfusion.WinForms.Controls.SfButton saveBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}