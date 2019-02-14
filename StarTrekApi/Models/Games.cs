using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Models
{
    public static class Games
    {
        private static Dictionary<int, Game> _games = new Dictionary<int, Game>();

        public static int CreateNewGame()
        {
            throw new NotImplementedException(nameof(CreateNewGame));
        }

    }
}
