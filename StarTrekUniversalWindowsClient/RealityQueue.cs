using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Messages;

namespace StarTrek
{
    public sealed class RealityQueue
    {
        private static Queue<IMessage> SendQueue;
        private static Queue<IMessage> ReceiveQueue;
        public event EventHandler SendMessageInQueue;
        public event EventHandler ReceiveMessageInQueue;
        private static object SendLock;
        private static object ReceiveLock;

        public RealityQueue()
        {
            SendLock = new object();
            ReceiveLock = new object();
            SendQueue = new Queue<IMessage>();
            ReceiveQueue = new Queue<IMessage>();
        }

        public void EnqueueSendQueue(IMessage message)
        {
            lock (SendLock)
            {
                SendQueue.Enqueue(message);
            }
            SendMessageInQueue?.Invoke(this, new EventArgs());
        }

        public void EnqueueReceiveQueue(IMessage message)
        {
            lock (ReceiveLock)
            {
                ReceiveQueue.Enqueue(message);
            }
            ReceiveMessageInQueue?.Invoke(this, new EventArgs());
        }

        public IMessage DequeueSendQueue()
        {
            lock(SendLock)
            {
                return SendQueue.Dequeue();
            }
        }

        public IMessage DequeueReceiveQueue()
        {
            lock(ReceiveLock)
            {
                if (!ReceiveQueue.Any())
                {
                    return null;
                }
                return ReceiveQueue.Dequeue();
            }
        }
    }


    public class EnterpriseRealityQueue
    {
        private RealityQueue _realityQueue;

        public EnterpriseRealityQueue(RealityQueue r)
        {
            _realityQueue = r;
        }

        public void Send(IMessage message)
        {
            _realityQueue.EnqueueSendQueue(message);
        }

        public IMessage GetMessage()
        {
            return _realityQueue.DequeueReceiveQueue();
        }
    }


    public class CommunicationRealityQueue
    {
        private RealityQueue _realityQueue;

        public CommunicationRealityQueue(RealityQueue r)
        {
            _realityQueue = r;
        }

        public void EnqueueSend(IMessage message)
        {
            _realityQueue.EnqueueSendQueue(message);
        }

        public IMessage DequeueSend()
        {
            return _realityQueue.DequeueSendQueue();
        }

        public void EnqueueReceive(IMessage message)
        {
            _realityQueue.EnqueueReceiveQueue(message);
        }
    }
}
