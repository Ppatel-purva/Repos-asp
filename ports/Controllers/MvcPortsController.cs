using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ports.Data;
using ports.Models;

namespace ports.Controllers
{
    public class MvcPortsController : Controller
    {
        private readonly portsContext _context;

        public MvcPortsController(portsContext context)
        {
            _context = context;
        }

        // GET: MvcPorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MvcPorts.ToListAsync());
        }

        // GET: MvcPorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcPorts = await _context.MvcPorts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mvcPorts == null)
            {
                return NotFound();
            }

            return View(mvcPorts);
        }

        // GET: MvcPorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MvcPorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("N9,Q2,SG,IEA")] MvcPorts mvcPorts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mvcPorts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mvcPorts);
        }

        // GET: MvcPorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcPorts = await _context.MvcPorts.FindAsync(id);
            if (mvcPorts == null)
            {
                return NotFound();
            }
            return View(mvcPorts);
        }

        // POST: MvcPorts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReachDate,Location,Fees")] MvcPorts mvcPorts)
        {
            if (id != mvcPorts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mvcPorts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MvcPortsExists(mvcPorts.Id))
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
            return View(mvcPorts);
        }

        // GET: MvcPorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mvcPorts = await _context.MvcPorts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mvcPorts == null)
            {
                return NotFound();
            }

            return View(mvcPorts);
        }

        // POST: MvcPorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mvcPorts = await _context.MvcPorts.FindAsync(id);
            _context.MvcPorts.Remove(mvcPorts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MvcPortsExists(int id)
        {
            return _context.MvcPorts.Any(e => e.Id == id);
        }
    }
}
