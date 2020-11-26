using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;

namespace Scribe.Studio.Logic
{
    public static class Queue
    {
        public static void SendMessage(string path, string label, string content)
        {
            using (MessageQueue queue = new MessageQueue(path))
            {
                queue.MessageReadPropertyFilter.AppSpecific = true;
                queue.Formatter = new BinaryMessageFormatter();
                Message myMessage = new Message();
                myMessage.Label = label;
                myMessage.BodyStream = new MemoryStream(Encoding.ASCII.GetBytes(content));
                queue.Send(myMessage);
            }
        }
    }
}
