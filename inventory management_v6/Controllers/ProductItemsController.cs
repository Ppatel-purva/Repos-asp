#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using inventory_management_v6.Data;
using inventory_management_v6.Models;

namespace inventory_management_v6.Controllers
{
    public class ProductItemsController : Controller
    {
        private readonly inventory_management_v6Context _context;

        public ProductItemsController(inventory_management_v6Context context)
        {
            _context = context;
        }

        // GET: ProductItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductItems.ToListAsync());
        }

        // GET: ProductItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productItems = await _context.ProductItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productItems == null)
            {
                return NotFound();
            }

            return View(productItems);
        }

        // GET: ProductItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Price,Category,ManufacturerName,DistributerName,Address,DateTime")] ProductItems productItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productItems);
        }

        // GET: ProductItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productItems = await _context.ProductItems.FindAsync(id);
            if (productItems == null)
            {
                return NotFound();
            }
            return View(productItems);
        }

        // POST: ProductItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Price,Category,ManufacturerName,DistributerName,Address,DateTime")] ProductItems productItems)
        {
            if (id != productItems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductItemsExists(productItems.Id))
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
            return View(productItems);
        }

        // GET: ProductItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productItems = await _context.ProductItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productItems == null)
            {
                return NotFound();
            }

            return View(productItems);
        }

        // POST: ProductItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productItems = await _context.ProductItems.FindAsync(id);
            _context.ProductItems.Remove(productItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductItemsExists(int id)
        {
            return _context.ProductItems.Any(e => e.Id == id);
        }
    }
}
