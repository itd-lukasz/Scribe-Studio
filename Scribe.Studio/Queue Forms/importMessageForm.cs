using Scribe.Studio.Logic;
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
    public partial class importMessageForm : SfForm
    {
        public importMessageForm()
        {
            InitializeComponent();
            ThemeName = "Office2016Colorful";
            Text = "Import message to queue...";
            List<string> queues = new List<string>();
            queues.AddRange(Configuration.Parameters.Where(e => e.Key.StartsWith("QUEUE|")).Select(s => s.Value).ToList().Cast<string>());
            queueCombo.DataSource = queues;
        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            if (allFilesFromFolderCheck.Checked)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog()==DialogResult.OK)
                {
                    fileTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML files|*.xml";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileTextBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void allFilesFromFolderCheck_CheckedChanged(object sender, EventArgs e)
        {
            fileTextBox.Text = "";
        }
    }
}
