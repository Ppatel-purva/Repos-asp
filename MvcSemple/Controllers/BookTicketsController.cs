using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSemple.Data;
using MvcSemple.Models;

namespace MvcSemple.Controllers
{
    public class BookTicketsController : Controller
    {
        private readonly MvcSempleContext _context;

        public BookTicketsController(MvcSempleContext context)
        {
            _context = context;
        }

        // GET: BookTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookTicket.ToListAsync());
        }

        // GET: BookTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTicket = await _context.BookTicket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookTicket == null)
            {
                return NotFound();
            }

            return View(bookTicket);
        }

        // GET: BookTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieName,NumberOfSets,ShowTime")] BookTicket bookTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookTicket);
        }

        // GET: BookTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTicket = await _context.BookTicket.FindAsync(id);
            if (bookTicket == null)
            {
                return NotFound();
            }
            return View(bookTicket);
        }

        // POST: BookTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieName,NumberOfSets,ShowTime")] BookTicket bookTicket)
        {
            if (id != bookTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTicketExists(bookTicket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookTicket);
        }

        // GET: BookTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookTicket = await _context.BookTicket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookTicket == null)
            {
                return NotFound();
            }

            return View(bookTicket);
        }

        // POST: BookTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookTicket = await _context.BookTicket.FindAsync(id);
            _context.BookTicket.Remove(bookTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookTicketExists(int id)
        {
            return _context.BookTicket.Any(e => e.Id == id);
        }
    }
}
