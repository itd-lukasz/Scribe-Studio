using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class Job
    {
        public List<Worker> Steps { get; set; }

        public bool IsRunning { get; set; }

        public bool IsDone { get; set; }

        public string Name { get; set; }

        public Job()
        {
            Steps = new List<Worker>();
        }

        public void RunJob()
        {
            IsRunning = true;
            foreach (Worker step in Steps)
            {
                switch (step)
                {
                    case XmlFileWorker xml:
                        xml.Run();
                        break;
                }
            }
            IsRunning = false;
            IsDone = true;
        }
    }
}
