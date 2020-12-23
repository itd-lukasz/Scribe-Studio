using Scribe.Studio.Logic;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.ListView.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scribe.Studio.Progress_Forms
{
    public partial class progressForm : SfForm
    {
        Job job = null;

        public progressForm(Job job)
        {
            InitializeComponent();
            ThemeName = "Office2016Colorful";
            this.job = job;
            foreach (Worker worker in job.Steps)
            {
                worker.WorkerIsDoneEvent += Worker_WorkerIsDoneEvent;
            }
            detailsListView.DataSource = new List<Worker>();
            detailsListView.DisplayMember = "Message";
            detailsListView.DataSource = job.Steps.Where(s => s.IsDone).ToList();
            detailsListView.AutoFitMode = AutoFitMode.Height;
            progressBar.Maximum = job.Steps.Count;
            progressBar.Step = 1;
            progressBar.Value = job.Steps.Where(s => s.IsDone).Count();
        }

        private void Worker_WorkerIsDoneEvent(object sender)
        {
            //((List<Worker>)detailsListView.DataSource).Add((Worker)sender);
            detailsListView.DataSource = job.Steps.Where(s => s.IsDone).ToList();
            progressBar.Maximum = job.Steps.Count;
            progressBar.Step = 1;
            progressBar.Value = job.Steps.Where(s => s.IsDone).Count();
            Refresh();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
