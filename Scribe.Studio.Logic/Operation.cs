using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class Operation
    {
        public enum OperationType
        {
            ReadXmlFileToQueue
        }

        public bool IsError { get; set; }

        public string Message { get; set; }

        public OperationType Type { get; set; }
    }
}
