using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrek.Messages
{
    public class QuadrantDetailMessage : IMessage
    {
        public MessageType MessageType { get; set; }
        public int QuadrantX { get; set; }
        public int QuadrantY { get; set; }
        public int Summary { get; set; }
        public List<Sector> Sectors { get; set; }
    }

    public class Sector
    {
        public int SectorX { get; set; }
        public int SectorY { get; set; }
        public char Content { get; set; }
    }
}
