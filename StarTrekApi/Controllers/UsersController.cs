using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointRobertsSoftware.StarTrek.Domain.Models;
using PointRobertsSoftware.StarTrek.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace PointRobertsSoftware.StarTrek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        // GET: api/Users
        [HttpGet()]
        [ProducesResponseType(200)]
        public IEnumerable<User> Get()
        {
            return _userRepository.FindAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<User>> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            User result = await _userRepository.GetAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result; // TODO -- Verify this works... 
        }

        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(User))]  // Created
        [ProducesResponseType(400)]  // Bad Request (malformed/incomplete -- required values missing)
        public async Task<ActionResult<User>> PostAsync([FromBody] User user)
        {
            if (user.Id != 0)
            {
                return BadRequest("Id should be zero.");
            }

            if (String.IsNullOrWhiteSpace(user.FirstName))
            {
                return BadRequest("First name is required.");
            }

            if (String.IsNullOrWhiteSpace(user.UserId))
            {
                return BadRequest("UserId is required.");
            }

            User newUser = await _userRepository.InsertUserAsync(user);
            return CreatedAtAction(nameof(PostAsync), newUser);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
