using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Api.Data;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Tests.TestMocks
{
    public class TestGameRepository : IGameRepository
    {
        public List<Game> Games { get; set; }

        public bool CreateGame(Game game)
        {
            var foundGame = Games.FirstOrDefault(gm => gm.Id == game.Id);
            if (foundGame == null)
            {
                Games.Add(game);
                return true;
            }

            return false;
        }

        public void Delete(Game entity)
        {
            Games.Remove(entity);
        }

        public IEnumerable<Game> FindAll()
        {
            return Games;
        }

        public IEnumerable<Game> FindGamesByPlayerId(int playerId)
        {
            return Games.Where(u => u.PlayerIds.Contains(playerId));
        }

        public async Task<Game> GetAsync(int id)
        {
            return await Task.Run(() => Games.FirstOrDefault(x => x.Id == id));
        }

        public void Save(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
