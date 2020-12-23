using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class Worker
    {
        public bool IsDone { get; set; }

        public bool IsError { get; set; }

        public string Message { get; set; }

        public DateTime MessageTime { get; set; }

        public object Tag { get; set; }

        public delegate void WorkerIsDone(object sender);

        public event WorkerIsDone WorkerIsDoneEvent;

        protected void WorkIsDone()
        {
            if (WorkerIsDoneEvent != null)
            {
                WorkerIsDoneEvent(this);
            }
        }

        public void Run()
        {
        }
    }
}
