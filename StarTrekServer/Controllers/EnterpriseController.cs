using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StarTrekServer.Models;

namespace StarTrekServer.Controllers
{
    public class EnterpriseController : ApiController
    {
        public EnterpriseController()
        {
            // TODO -- This is only for testing...this should be done on game start only...
            GameStatus.Instance.Games.Add(new Game(Guid.NewGuid()));
        }

        // Return all star/base/enterprise entities
        // Return all enemy entities within a quadrant inhabitated by a base or the enterprise
        // Return a summary of all quadrants within one quadrant of the enterprise or a base
        // GET: /Enterprise
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: /Enterprise
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // Start a new game
        // POST: /Enterprise
        public void Post(Guid guid)
        {
            var game = new Game(guid);
            game.InitializeGame();
            GameStatus.Instance.Games.Add(game);

        }

        // PUT: /Enterprise
        public void Put([FromBody]string value)
        {
        }

        // Terminate a game
        // DELETE: /Enterprise
        public void Delete(Guid guid)
        {
            //_gameGuids.Remove(guid);

            // TODO -- Terminate a game...remove it from the database
        }
    }
}
