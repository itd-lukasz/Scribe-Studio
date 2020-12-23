using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class XmlFileJob : Job
    {
        public bool UseBatch { get; set; }

        public int BatchSize { get; set; }

        public bool WaitAfterBatch { get; set; }

        public int WaitSecondsAfterBatch { get; set; }

        public bool WaitUntilQueueWillBeEmpty { get; set; }

        public string Queue { get; set; }

        public new void RunJob()
        {
            IsRunning = true;
            if (UseBatch)
            {
                for (int batch = 0; batch <= Math.Ceiling((decimal) Steps.Count / BatchSize); batch++)
                {
                    for (int a = 0; a < BatchSize; a++)
                    {
                        if (((batch * BatchSize) + a) < Steps.Count)
                        {
                            ((XmlFileWorker)Steps[(batch * BatchSize) + a]).Run();
                        }
                    }
                    if (batch < Math.Ceiling((decimal)Steps.Count / BatchSize))
                    {
                        if (WaitAfterBatch)
                        {
                            Thread.Sleep(WaitSecondsAfterBatch * 1000);
                        }
                        if (WaitUntilQueueWillBeEmpty)
                        {
                            if (Logic.Queue.CountMessages(Queue) > 0)
                            {
                                Thread.Sleep(500);
                            }
                        }
                    }
                }
            }
            IsRunning = false;
            IsDone = true;
        }
    }
}
