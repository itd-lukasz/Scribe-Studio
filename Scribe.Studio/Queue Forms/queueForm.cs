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

namespace Scribe.Studio.Queue_Forms
{
    public partial class queueForm : SfForm
    {
        public queueForm()
        {
            InitializeComponent();
            ThemeName = "Office2016Colorful";
            Text = "New queue...";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();
            bool validated = true;
            if (queueTextBox.Text.Length == 0)
            {
                errorProvider.SetError(queueTextBox, "This field must be filled!");
                validated = false;
            }
            return validated;
        }

        public string GetQueueName()
        {
            return queueTextBox.Text;
        }

    }
}
