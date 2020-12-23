using Scribe.Studio.Logic;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            waitAfterBatchRadio.Checked = true;
            SetBatchSection();
        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            if (allFilesFromFolderCheck.Checked)
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (fileTextBox.Text.Length > 0)
                {
                    folderBrowserDialog.SelectedPath = fileTextBox.Text;
                }
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
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

        public XmlFileJob ReturnJob()
        {
            return new XmlFileJob()
            {
                BatchSize = (int)batchSizeNumeric.Value,
                UseBatch = batchCheckBox.Checked,
                WaitAfterBatch = waitAfterBatchRadio.Checked,
                WaitSecondsAfterBatch = (int)waitAfterBatchNumeric.Value,
                WaitUntilQueueWillBeEmpty = waitForQueueRadio.Checked
            };
        }

        public List<Worker> ReturnWorkers()
        {
            List<Worker> fileWorkers = new List<Worker>();
            if (allFilesFromFolderCheck.Checked)
            {
                List<string> files = Directory.GetFiles(fileTextBox.Text, "*.xml").ToList();
                foreach (string file in files)
                {
                    fileWorkers.Add(new XmlFileWorker()
                    {
                        File = file,
                        Queue = queueCombo.Text,
                        Label = messageLabelTextBox.Text
                    });
                }
            }
            else
            {
                fileWorkers.Add(new XmlFileWorker()
                {
                    File = fileTextBox.Text,
                    Queue = queueCombo.Text,
                    Label = messageLabelTextBox.Text
                });
            }
            return fileWorkers;
        }

        private void waitAfterBatchRadio_CheckChanged(object sender, EventArgs e)
        {
            if (waitAfterBatchRadio.Checked)
            {
                waitForQueueRadio.Checked = false;
                waitAfterBatchNumeric.Enabled = true;
            }
        }

        private void waitForQueueRadio_CheckChanged(object sender, EventArgs e)
        {
            if (waitForQueueRadio.Checked)
            {
                waitAfterBatchRadio.Checked = false;
                waitAfterBatchNumeric.Enabled = false;
            }
        }

        private void batchCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            SetBatchSection();
        }

        private void SetBatchSection()
        {
            if (batchCheckBox.Checked)
            {
                waitAfterBatchRadio.Enabled = true;
                waitAfterBatchNumeric.Enabled = true;
                waitForQueueRadio.Enabled = true;
                batchSizeNumeric.Enabled = true;
            }
            else
            {
                waitAfterBatchRadio.Enabled = false;
                waitAfterBatchNumeric.Enabled = false;
                waitForQueueRadio.Enabled = false;
                batchSizeNumeric.Enabled = false;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            ValidateForm();
            if ((bool)errorProvider.Tag)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void ValidateForm()
        {
            errorProvider.Tag = true;
            if (fileTextBox.TextLength == 0)
            {
                errorProvider.SetError(fileTextBox, "Please select file or folder!");
                errorProvider.Tag = false;
            }
            if (messageLabelTextBox.TextLength == 0)
            {
                errorProvider.SetError(messageLabelTextBox, "Please provide message label!");
                errorProvider.Tag = false;
            }
            if (queueCombo.Text.Length == 0)
            {
                errorProvider.SetError(queueCombo, "Please select queue!");
                errorProvider.Tag = false;
            }
        }
    }
}
