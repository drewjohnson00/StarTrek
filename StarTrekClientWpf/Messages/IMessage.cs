using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.WPFclient.Messages
{
    public interface IMessage
    {
        MessageType MessageType { get; }
    }

    public enum MessageType { QuadrantDetailMessage, QuadrantSummaryMessage }
}
