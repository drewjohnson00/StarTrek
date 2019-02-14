using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointRobertsSoftware.StarTrek.Api.Data;
using PointRobertsSoftware.StarTrek.Domain.Models;

namespace PointRobertsSoftware.StarTrek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GamesController(IGameRepository gameRepo)
        {
            _gameRepository = gameRepo;
        }

        // GET: api/Game
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Ok(_gameRepository.FindAll().ToList());
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            Game result = await _gameRepository.GetAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Game
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {
            throw new NotImplementedException(nameof(Post));
        }

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException(nameof(Put));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Game gameToDelete = await _gameRepository.GetAsync(id);
            if (gameToDelete == null)
            {
                return BadRequest();
            }

            _gameRepository.Delete(gameToDelete);
            return Ok();
        }
    }
}
