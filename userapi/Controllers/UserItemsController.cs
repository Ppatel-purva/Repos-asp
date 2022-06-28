using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using userapi.Data;
using userapi.Models;

namespace userapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserItemsController : ControllerBase
    {
        private readonly userapiContext _context;

        public UserItemsController(userapiContext context)
        {
            _context = context;
        }

        // GET: api/UserItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserItems>>> GetUserItems()
        {
            return await _context.UserItems.ToListAsync();
        }

        // GET: api/UserItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserItems>> GetUserItems(int id)
        {
            var userItems = await _context.UserItems.FindAsync(id);

            if (userItems == null)
            {
                return NotFound();
            }

            return userItems;
        }

        // PUT: api/UserItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserItems(int id, UserItems userItems)
        {
            if (id != userItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(userItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserItems>> PostUserItems(UserItems userItems)
        {
            _context.UserItems.Add(userItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserItems", new { id = userItems.Id }, userItems);
        }

        // DELETE: api/UserItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserItems>> DeleteUserItems(int id)
        {
            var userItems = await _context.UserItems.FindAsync(id);
            if (userItems == null)
            {
                return NotFound();
            }

            _context.UserItems.Remove(userItems);
            await _context.SaveChangesAsync();

            return userItems;
        }

        private bool UserItemsExists(int id)
        {
            return _context.UserItems.Any(e => e.Id == id);
        }
    }
}
