using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Data
{
    public interface IGameRepository : IRepository<Game, int>
    {
        IEnumerable<Game> FindAll();
        IEnumerable<Game> FindGamesByPlayerId(int playerId);
        bool CreateGame(Game game);
    }
}
