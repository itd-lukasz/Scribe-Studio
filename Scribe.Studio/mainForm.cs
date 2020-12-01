using Scribe.Studio.Configuration_Forms;
using Scribe.Studio.Logic;
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
            importMessageForm.ShowDialog();
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
    }
}
