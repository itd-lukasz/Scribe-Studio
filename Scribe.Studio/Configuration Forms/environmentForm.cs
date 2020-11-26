using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scribe.Studio.Configuration_Forms
{
    public partial class environmentForm : SfForm
    {
        public environmentForm()
        {
            InitializeComponent();
            ThemeName = "Office2016Colorful";
            Text = "New environment...";
            ValidateForm();
        }

        public environmentForm(Logic.Environment environment)
        {
            InitializeComponent();
            ThemeName = "Office2016Colorful";
            Text = string.Format("Edit {0} environment...", environment.Name);
            nameTextEdit.Text = environment.Name;
            colorButton.BackColor = environment.Color;
            serverTextEdit.Text = environment.Server;
            databaseTextEdit.Text = environment.Database;
            windowsCheckBox.Checked = Convert.ToBoolean(environment.WindowsAuthentication);
            userTextEdit.Text = environment.User;
            passwordTextEdit.Text = environment.Password;
            ValidateForm();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorDialog.Color;
            }
        }

        private void windowsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (windowsCheckBox.Checked)
            {
                userTextEdit.Enabled = false;
                passwordTextEdit.Enabled = false;
            }
            else
            {
                userTextEdit.Enabled = true;
                passwordTextEdit.Enabled = true;
            }
            ValidateForm();
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool validated = true;
            if (!windowsCheckBox.Checked)
            {
                if (passwordTextEdit.Text.Length == 0)
                {
                    errorProvider.SetError(passwordTextEdit, "This field must be filled!");
                    validated = false;
                }
                if (userTextEdit.Text.Length == 0)
                {
                    errorProvider.SetError(userTextEdit, "This field must be filled!");
                    validated = false;
                }
            }
            if (databaseTextEdit.Text.Length == 0)
            {
                errorProvider.SetError(databaseTextEdit, "This field must be filled!");
                validated = false;
            }
            if (serverTextEdit.Text.Length == 0)
            {
                errorProvider.SetError(serverTextEdit, "This field must be filled!");
                validated = false;
            }
            if (nameTextEdit.Text.Length == 0)
            {
                errorProvider.SetError(nameTextEdit, "This field must be filled!");
                validated = false;
            }
            return validated;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                DialogResult = DialogResult.OK;
            }
        }

        public Logic.Environment GetEnvironment()
        {
            return new Logic.Environment(nameTextEdit.Text,
                colorButton.BackColor,
                serverTextEdit.Text,
                databaseTextEdit.Text,
                windowsCheckBox.Checked,
                !windowsCheckBox.Checked ? userTextEdit.Text : null,
                !windowsCheckBox.Checked ? passwordTextEdit.Text : null);
        }

        private void nameTextEdit_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void serverTextEdit_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void databaseTextEdit_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void userTextEdit_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void passwordTextEdit_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }
    }
}
