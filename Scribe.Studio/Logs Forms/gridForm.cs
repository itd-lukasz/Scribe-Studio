using Scribe.Studio.Logic;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using Syncfusion.Windows.Forms;

namespace Scribe.Studio.Logs_Forms
{
    public partial class gridForm : SfForm
    {
        List<ExecutionLogRow> rows = new List<ExecutionLogRow>();
        Connection connection = null;

        public gridForm(Logic.Environment environment)
        {
            InitializeComponent();

            this.Style.TitleBar.Height = 26;
            this.Style.TitleBar.BackColor = Color.White;
            this.Style.TitleBar.IconBackColor = Color.FromArgb(15, 161, 212);
            this.BackColor = Color.White;
            this.Style.TitleBar.ForeColor = ColorTranslator.FromHtml("#343434");
            this.Style.TitleBar.CloseButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.HelpButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.IconHorizontalAlignment = HorizontalAlignment.Left;
            this.Style.TitleBar.Font = this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            connection = environment.Connection;
            ForeColor = environment.Color;
            BackColor = environment.Color;
            Text = environment.Name;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            rows = Database.GetExecutionLogRows((DateTime)startDateEdit.Value, (DateTime)endDateEdit.Value, connection);
            dataGrid.DataSource = rows;
            dataGrid.Columns["StartTime"].Format = "dd-MM-yyyy HH:mm:ss";
            dataGrid.Columns["EndTime"].Format = "dd-MM-yyyy HH:mm:ss";
            dataGrid.Columns["ID"].Visible = false;
        }

        private void exportMessagesButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (Syncfusion.Data.RecordEntry logRow in dataGrid.View.Records)
                {
                    string rowId = ((ExecutionLogRow)logRow.Data).ID;
                    StreamWriter sw = new StreamWriter(string.Format(@"{0}\{1}.xml", folderBrowserDialog.SelectedPath, rowId), false);
                    sw.Write(Database.GetMessage(rowId, connection));
                    sw.Close();
                }
                MessageBoxAdv.Show("Export is done!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
