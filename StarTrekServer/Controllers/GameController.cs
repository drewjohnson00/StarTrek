using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StarTrekServer.Models;

namespace StarTrekServer.Controllers
{
    public class GameController : ApiController
    {
        // Get a list of all game ids
        // GET: Game
        public IEnumerable<string> Get()
        {
            List<string> resultList = new List<string>();

            foreach(Game game in GameStatus.Instance.Games)
            {
                resultList.Add(game.GameId);
            }

            return resultList;
        }

        // Get a Game object (or null if id doesn't exist)
        // GET: Game/{GUID}
        public Game Get(string id)
        {
            return GameStatus.Instance.Games.FirstOrDefault(x => x.GameId == id);
        }

        // Start a game
        // POST: Game
        public void Post([FromBody]string id)
        {
            // TODO -- Going to need some error checking here...
            GameStatus.Instance.Games.Add(new Game(Guid.Parse(id)));
        }

        //// PUT: Game/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // PATCH: Game/{GUID}
        public void Patch(string id)
        {
            // make changes to game object
        }

        // Remove a game
        // DELETE: Game/{GUID}
        public void Delete(string id)
        {
            Game toDelete = GameStatus.Instance.Games.FirstOrDefault();
            GameStatus.Instance.Games.Remove(toDelete);
        }
    }
}
