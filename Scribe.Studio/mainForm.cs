using Scribe.Studio.Configuration_Forms;
using Scribe.Studio.Logic;
using Scribe.Studio.Progress_Forms;
using Scribe.Studio.Queue_Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scribe.Studio
{
    public partial class mainForm : RibbonForm
    {
        List<Job> jobs = new List<Job>();

        public mainForm()
        {
            InitializeComponent();
            MessageBoxAdv.Office2016Theme = Office2016Theme.Colorful;
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Office2016;
            try
            {
                Configuration.LoadConfiguration("configuration.json");
            }
            catch
            {
                MessageBoxAdv.Show("Error while reading configuration! Please click File and configure application!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (Job job in jobs)
            {
                if (!job.IsRunning)
                {
                    switch (job)
                    {
                        case XmlFileJob file:
                            file.RunJob();
                            break;
                    }
                }
            }
        }

        private void PopulateEnvironmentsGrid()
        {
            List<Logic.Environment> environments = new List<Logic.Environment>();
            environments.AddRange(Configuration.Parameters.Where(e => e.Key.StartsWith("ENV|")).Select(s => s.Value).ToList().Cast<Logic.Environment>());
            environmentsGrid.DataSource = environments;
            environmentsGrid.Columns.Remove(environmentsGrid.Columns.Where(c => c.MappingName == "Password").FirstOrDefault());
        }

        private void PopulateQueuesGrid()
        {
            List<string> queues = new List<string>();
            queues.AddRange(Configuration.Parameters.Where(e => e.Key.StartsWith("QUEUE|")).Select(s => s.Value).ToList().Cast<string>());
            queueList.DataSource = queues;
        }

        private void applicationMenuTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (applicationMenuTabs.SelectedIndex == 0)
            {
                PopulateEnvironmentsGrid();
            }
            if (applicationMenuTabs.SelectedIndex == 1)
            {
                PopulateQueuesGrid();
            }
        }

        private void ribbonControl_MenuButtonClick(object sender, EventArgs e)
        {
            PopulateEnvironmentsGrid();
        }

        private void addEnvironmentBtn_Click(object sender, EventArgs e)
        {
            environmentForm environment = new environmentForm();
            if (environment.ShowDialog() == DialogResult.OK)
            {
                Configuration.Parameters.Add(new KeyValuePair<string, object>(string.Format("ENV|{0}", environment.GetEnvironment().Name), environment.GetEnvironment()));
                PopulateEnvironmentsGrid();
            }
        }

        private void environmentsGrid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            e.Style.BackColor = ((Logic.Environment)e.DataRow.RowData).Color;
        }

        private void saveConfigBtn_Click(object sender, EventArgs e)
        {
            Configuration.SaveConfiguration("configuration.json");
        }

        private void environmentsGrid_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            environmentForm environment = new environmentForm((Logic.Environment)e.DataRow.RowData);
            if (environment.ShowDialog() == DialogResult.OK)
            {
                Configuration.Parameters.Remove(Configuration.Parameters.Where(p => p.Key == string.Format("ENV|{0}", ((Logic.Environment)e.DataRow.RowData).Name)).FirstOrDefault());
                Configuration.Parameters.Add(new KeyValuePair<string, object>(string.Format("ENV|{0}", environment.GetEnvironment().Name), environment.GetEnvironment()));
                PopulateEnvironmentsGrid();
            }
        }

        private void addMessageQueueFromFileBtn_Click(object sender, EventArgs e)
        {
            importMessageForm importMessageForm = new importMessageForm();
            if (importMessageForm.ShowDialog() == DialogResult.OK)
            {
                Job job = importMessageForm.ReturnJob();
                job.Name = string.Format("Job {0}", jobs.Count + 1);
                job.Steps.AddRange(importMessageForm.ReturnWorkers());
                foreach (Worker worker in job.Steps)
                {
                    worker.Tag = job;
                    worker.WorkerIsDoneEvent += Worker_WorkerIsDoneEvent;
                }
                jobs.Add(job);
                ToolStripMenuItem toolStripItem = new ToolStripMenuItem();
                toolStripItem.Tag = job;
                toolStripItem.Text = job.Name;
                toolStripItem.Click += ToolStripItem_Click;
                jobsDropDown.DropDownItems.Add(toolStripItem);
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void Worker_WorkerIsDoneEvent(object sender)
        {
            if (statusProgressBar.Tag == (XmlFileWorker)sender)
            {
                statusProgressBar.Maximum = 10;
                statusProgressBar.Value = 7;
            }
            //statusProgressBar.Minimum = 1;
            //statusProgressBar.Maximum = 100;
            //statusProgressBar.Step = ;
            //statusProgressBar.Value = 50;
        }

        private void ToolStripItem_Click(object sender, EventArgs e)
        {
            jobsDropDown.Text = ((ToolStripMenuItem)sender).Text;
            ((ToolStripMenuItem)sender).Checked = true;
            Job job = (Job)((ToolStripMenuItem)sender).Tag;
            statusProgressBar.Maximum = job.Steps.Count;
            statusProgressBar.Value = job.Steps.Where(s => s.IsDone).Count();
            if (job.Steps.Count == 0)
            {
                statusProgressBar.Maximum = 10;
                statusProgressBar.Value = 10;
            }
            statusProgressBar.Tag = job;

        }

        private void addQueueBtn_Click(object sender, EventArgs e)
        {
            queueForm queueForm = new queueForm();
            if (queueForm.ShowDialog() == DialogResult.OK)
            {
                Configuration.Parameters.Add(new KeyValuePair<string, object>(string.Format("QUEUE|{0}", queueForm.GetQueueName()), queueForm.GetQueueName()));
                PopulateQueuesGrid();
            }
        }

        private void removeQueueBtn_Click(object sender, EventArgs e)
        {
            if (queueList.SelectedItem != null)
            {
                queueList.View.Items.Remove(queueList.SelectedItem);
                Configuration.Parameters.Remove(Configuration.Parameters.Where(p => p.Key == string.Format("QUEUE|{0}", queueList.SelectedItem)).FirstOrDefault());
                PopulateQueuesGrid();
            }
        }

        private void queueTab_VisibleChanged(object sender, EventArgs e)
        {
            PopulateQueuesGrid();
        }

        private void statusProgressBar_DoubleClick(object sender, EventArgs e)
        {
            if (((ToolStripProgressBar)sender).Tag != null)
            {
                Job job = (Job)((ToolStripProgressBar)sender).Tag;
                progressForm progressForm = new progressForm(job);
            }
        }

        private void statusProgressBar_Click(object sender, EventArgs e)
        {
            if (((ToolStripProgressBar)sender).Tag != null)
            {
                Job job = (Job)((ToolStripProgressBar)sender).Tag;
                progressForm progressForm = new progressForm(job);
                progressForm.Show();
            }
        }
    }
}
