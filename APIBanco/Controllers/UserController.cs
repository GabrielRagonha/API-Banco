using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIBanco.Entities;
using APIBanco.Persistence;

namespace APIBanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public UserController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/User
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Users);
        }

        // GET api/User/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var user = _dbContext.Users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/User
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(User user)
        {
            _dbContext.Users.Add(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, User input)
        {
            var user = _dbContext.Users.Find(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Update(input.Name, input.Email, input.DateOfBirth);

            return NoContent();
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var user = _dbContext.Users.Find(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(user);

            return NoContent();
        }
    }
}
