using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarTrekServer.Models;

namespace StarTrekServer
{
    public class GameStatus
    {
        private static object _lockObject = new object();
        private static GameStatus _me;

        public List<Game> Games { get; private set; }

        private GameStatus()
        {
            Games = new List<Game>();
        }

        public static GameStatus Instance
        {
            get
            {
                lock (_lockObject)
                {
                    if (_me == null)
                    {
                        _me = new GameStatus();
                    }

                    return _me;
                }
            }
        }
    }
}