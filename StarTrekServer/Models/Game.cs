using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarTrekServer.Models
{
    public class Game
    {
        private Guid _gameId;
        private List<IEntities> _entities;
        private int _elapsedTime = 2;
        private int _kills = 1;


        public Game(Guid gameId)
        {
            _gameId = gameId;
        }

        public string GameId => _gameId.ToString();

        public void InitializeGame()
        {
            _entities.Add(new Star(1, 1, 2, 2));
            _entities.Add(new Star(1, 1, 4, 4));
            _entities.Add(new Enterprise(1, 1, 6, 6));
        }

        public void RemoveGame()
        {

        }


    }
}