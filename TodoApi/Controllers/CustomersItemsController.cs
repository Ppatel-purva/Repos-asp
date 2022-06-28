using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersItemsController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersItemsController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/CustomersItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersItems>>> GetCustomersItems()
        {
            return await _context.CustomersItems.ToListAsync();
        }

        // GET: api/CustomersItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomersItems>> GetCustomersItems(long id)
        {
            var customersItems = await _context.CustomersItems.FindAsync(id);

            if (customersItems == null)
            {
                return NotFound();
            }

            return customersItems;
        }

        // PUT: api/CustomersItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomersItems(long id, CustomersItems customersItems)
        {
            if (id != customersItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(customersItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersItemsExists(id))
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

        // POST: api/CustomersItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomersItems>> PostCustomersItems(CustomersItems customersItems)
        {
            _context.CustomersItems.Add(customersItems);
            await _context.SaveChangesAsync();
           
            return CreatedAtAction((nameof(GetCustomersItems)), new { id = customersItems.Id }, customersItems);
        }

        // DELETE: api/CustomersItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomersItems>> DeleteCustomersItems(long id)
        {
            var customersItems = await _context.CustomersItems.FindAsync(id);
            if (customersItems == null)
            {
                return NotFound();
            }

            _context.CustomersItems.Remove(customersItems);
            await _context.SaveChangesAsync();

            return customersItems;
        }

        private bool CustomersItemsExists(long id)
        {
            return _context.CustomersItems.Any(e => e.Id == id);
        }
    }
}
