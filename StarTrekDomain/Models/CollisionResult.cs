using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Domain.Models
{
    public class CollisionResult
    {
        bool Collision { get; set; }
        Location Obstacle { get; set; }
        int DeflectionAngle { get; set; }
        int ObstacleDeflectionAngle { get; set; }
        int PercentImpact { get; set; }
    }
}
