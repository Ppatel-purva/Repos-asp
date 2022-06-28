using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookCRUD.Models;


namespace BookCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;
        public BookController(BookContext context)
        {

            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookItems>>> GetBook()
        {
            return Ok(await _context.BookItems.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult<BookItems>> PostBook(BookItems book)
        {
            _context.BookItems.Add(book);
            await _context.SaveChangesAsync();
            return Ok(await _context.BookItems.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<BookItems>> putBook(BookItems book)
        {
            var editBook = await _context.BookItems.FindAsync(book.Id);
            if (editBook == null)
            {
                return BadRequest("Book Not Found");
            }
            editBook.Name = book.Name;
            editBook.Author = book.Author;
            editBook.price = book.price;

            await _context.SaveChangesAsync();
            return Ok(await _context.BookItems.ToListAsync());

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var DelBook = await _context.BookItems.FindAsync(id);
            if (DelBook == null)
            {
                return BadRequest();
            }
            _context.BookItems.Remove(DelBook);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
