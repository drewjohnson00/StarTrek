using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Models
{
    /// <summary>
    /// This class is the definitive source of what is going on in the galaxy for a given game.
    /// </summary>
    public sealed class Galaxy
    {
        private State[,,,] _galaxy = new State[10, 10, 10, 10]; // QuadX, QuadY, SectX, SectY

        public Galaxy(GameState initialGame)
        {

        }

        public GameState QuadrantContents(int quadrantX, int quadrantY)
        {
            throw new NotImplementedException(nameof(QuadrantContents));
        }

        public int[,] GalaxySummary()
        {
            throw new NotImplementedException(nameof(GalaxySummary));
        }

        public CollisionResult CollisionCheck(int quadrantX, int quadrantY, int sectorX1, int sectorY1, int sectorX2, int sectorY2)
        {
            throw new NotImplementedException(nameof(CollisionCheck));
        }
    }
}
