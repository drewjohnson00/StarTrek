using System.Collections.Generic;

namespace PointRobertsSoftware.StarTrek.Domain.Models
{
    public class GameState
    {
        public EnterpriseState Enterprise { get; set; }

        public KlingonState[] Klingons { get; set; }

        public BaseState[] Bases { get; set; }

        public StarState[] Stars { get; set; }
    }
}
