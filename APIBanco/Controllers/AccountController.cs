using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIBanco.Entities;
using APIBanco.Persistence;

namespace APIBanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public AccountController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Account
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Accounts);
        }

        // GET api/Account/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var account = _dbContext.Accounts.Find(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        // POST api/Account
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post(Account account)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == account.ClientId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _dbContext.Accounts.Add(account);

            return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
        }

        // PUT api/Account/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Put(int id, Account input)
        {
            var account = _dbContext.Accounts.Find(a => a.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/Account/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var account = _dbContext.Accounts.Find(a => a.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            _dbContext.Accounts.Remove(account);

            return NoContent();
        }
    }
}
