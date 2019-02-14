using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public bool IsRunning { get; set; }

        public int[] PlayerIds { get; set; }

        public GameState GameState { get; set; }
    }
}
