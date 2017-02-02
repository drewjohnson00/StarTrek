using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTrek.Messages;

namespace StarTrek
{
    public class RealityQueue
    {
        private Queue<IMessage> _MessageQueue;
        public event EventHandler QueueActive;

        public RealityQueue()
        {
            _MessageQueue = new Queue<IMessage>();
        }

        public void Enqueue(IMessage message)
        {
            _MessageQueue.Enqueue(message);
            QueueActive?.Invoke(this, new EventArgs());
        }

        public IMessage Dequeue()
        {
            if(!_MessageQueue.Any())
            {
                return null;
            }

            return _MessageQueue.Dequeue();
        }
    }
}
