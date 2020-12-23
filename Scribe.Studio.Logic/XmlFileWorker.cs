using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribe.Studio.Logic
{
    public class XmlFileWorker : Worker
    {
        public string File { get; set; }

        public string Queue { get; set; }

        public string Label { get; set; }

        public XmlFileWorker()
        {
            IsDone = false;
            IsError = false;
        }

        public new void Run()
        {
            StreamReader sr = new StreamReader(File);
            string content = sr.ReadToEnd();
            sr.Close();
            try
            {
                Logic.Queue.SendMessage(Queue, Label, content);
                Message = string.Format("Message from file: {0} was sent to queue: {1}", File, Queue);
                MessageTime = DateTime.Now;
            }
            catch (Exception exc)
            {
                Message = string.Format("Error when trying to send message from file: {0} to queue: {1}! Error details: {2}", File, Queue, exc.Message);
                IsError = true;
                MessageTime = DateTime.Now;
            }
            IsDone = true;
            WorkIsDone();
        }
    }
}
