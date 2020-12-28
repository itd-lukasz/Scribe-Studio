
namespace Scribe.Studio
{
    partial class selectEnvironmentForm
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
            this.environmentGroupBox = new System.Windows.Forms.GroupBox();
            this.environmentCombo = new Syncfusion.WinForms.ListView.SfComboBox();
            this.selectBtn = new Syncfusion.WinForms.Controls.SfButton();
            this.environmentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.environmentCombo)).BeginInit();
            this.SuspendLayout();
            // 
            // environmentGroupBox
            // 
            this.environmentGroupBox.Controls.Add(this.environmentCombo);
            this.environmentGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.environmentGroupBox.Location = new System.Drawing.Point(2, 2);
            this.environmentGroupBox.Name = "environmentGroupBox";
            this.environmentGroupBox.Size = new System.Drawing.Size(615, 65);
            this.environmentGroupBox.TabIndex = 3;
            this.environmentGroupBox.TabStop = false;
            this.environmentGroupBox.Text = "Select environment";
            // 
            // environmentCombo
            // 
            this.environmentCombo.Location = new System.Drawing.Point(6, 33);
            this.environmentCombo.Name = "environmentCombo";
            this.environmentCombo.Size = new System.Drawing.Size(609, 26);
            this.environmentCombo.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.environmentCombo.TabIndex = 2;
            // 
            // selectBtn
            // 
            this.selectBtn.AccessibleName = "Button";
            this.selectBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.selectBtn.Location = new System.Drawing.Point(5, 85);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(609, 78);
            this.selectBtn.TabIndex = 5;
            this.selectBtn.Text = "Select";
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // selectEnvironmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 181);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.environmentGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "selectEnvironmentForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style.MdiChild.IconHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            this.Text = "Select environment";
            this.environmentGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.environmentCombo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox environmentGroupBox;
        private Syncfusion.WinForms.ListView.SfComboBox environmentCombo;
        private Syncfusion.WinForms.Controls.SfButton selectBtn;
    }
}