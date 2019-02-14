using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Domain.Models
{
    public class Location
    {
        public Location(int quadrantX, int quadrantY, int sectorX, int sectorY)
        {
            QuadrantX = quadrantX;
            QuadrantY = quadrantY;
            SectorX = sectorX;
            SectorY = sectorY;
        }

        int QuadrantX { get; set; }
        int QuadrantY { get; set; }
        int SectorX { get; set; }
        int SectorY { get; set; }
    }
}
