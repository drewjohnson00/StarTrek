using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Domain.Models
{
    public class EnterpriseState : State
    {
        public int FuelLevel { get; set; }
        public int ShieldLevel { get; set; }
        public int Torpedoes { get; set; }
    }
}
