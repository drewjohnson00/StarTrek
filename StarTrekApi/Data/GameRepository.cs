using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _dbContext;

        public GameRepository(GameContext gameContext)
        {
            _dbContext = gameContext;
        }

        public bool CreateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void Delete(Game entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> FindGamesByPlayerId(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetAsync(int id)
        {
            return _dbContext.Games.FindAsync(new object[] { id });
        }

        public void Save(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
