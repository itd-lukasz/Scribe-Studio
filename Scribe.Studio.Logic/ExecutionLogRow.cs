using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class ExecutionLogRow
    {
        public string ID { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }

        [DisplayName("Job Name")]
        public string JobSpecName { get; set; }

        [DisplayName("Source Name")]
        public string SourceName { get; set; }

        [DisplayName("Target Name")]
        public string TargetName { get; set; }

        [DisplayName("Source Rows")]
        public int SourceRows { get; set; }

        [DisplayName("Fatal Error Code")]
        public int FatalErrorCode { get; set; }

        [DisplayName("Fatal Error Message")]
        public string FatalErrorMessage { get; set; }

        [DisplayName("Legacy Source Name")]
        public string LegacySourceName { get; set; }

        [DisplayName("Legacy Target Name")]
        public string LegacyTargetName { get; set; }

        [DisplayName("Last Source Key")]
        public string LastSourceKey { get; set; }

        [DisplayName("Last Source Key Name")]
        public string LastSourceKeyName { get; set; }

        [DisplayName("Message Label")]
        public string MessageLabel { get; set; }
    }
}
