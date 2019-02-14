using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Domain.Models
{
    public class State
    {
        public int QuadrantX { get; set; }
        public int QuadrantY { get; set; }
        public int SectorX { get; set; }
        public int SectorY { get; set; }
        public bool Alive { get; set; }
        public SectorContent EntityType { get; set; }
    }
}
