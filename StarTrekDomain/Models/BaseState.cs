using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Domain.Models
{
    public class BaseState : State
    {
        public int Energy { get; set; }
        public int Shields { get; set; }
    }
}
