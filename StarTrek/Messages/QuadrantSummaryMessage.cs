using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.WPFclient.Messages
{
    public class QuadrantSummaryMessage : IMessage
    {
        public MessageType MessageType { get; set; }
        public List<QuadrantSummary> Summary { get; set; }
    }

    public class QuadrantSummary
    {
        public int QuadrantX { get; set; }
        public int QuadrantY { get; set; }
        public int NumberOfStars { get; set; }
        public int NumberOfBases { get; set; }
        public int NumberOfEnemies { get; set; }
    }
}
