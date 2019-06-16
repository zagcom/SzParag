using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SzParag.Data;
using SzParag.Models;

namespace SzParag.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.Category1).Include(p => p.Category2).Include(p => p.Category3).Include(p => p.Producer).Include(p => p.Unit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category1)
                .Include(p => p.Category2)
                .Include(p => p.Category3)
                .Include(p => p.Producer)
                .Include(p => p.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["Category1Id"] = new SelectList(_context.Category1, "Id", "Id");
            ViewData["Category2Id"] = new SelectList(_context.Category2, "Id", "Id");
            ViewData["Category3Id"] = new SelectList(_context.Category3, "Id", "Id");
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id");
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StripCode,Name,UnitId,Category1Id,Category2Id,Category3Id,ProducerId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category1Id"] = new SelectList(_context.Category1, "Id", "Id", product.Category1Id);
            ViewData["Category2Id"] = new SelectList(_context.Category2, "Id", "Id", product.Category2Id);
            ViewData["Category3Id"] = new SelectList(_context.Category3, "Id", "Id", product.Category3Id);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id", product.ProducerId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Id", product.UnitId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["Category1Id"] = new SelectList(_context.Category1, "Id", "Id", product.Category1Id);
            ViewData["Category2Id"] = new SelectList(_context.Category2, "Id", "Id", product.Category2Id);
            ViewData["Category3Id"] = new SelectList(_context.Category3, "Id", "Id", product.Category3Id);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id", product.ProducerId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Id", product.UnitId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,StripCode,Name,UnitId,Category1Id,Category2Id,Category3Id,ProducerId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["Category1Id"] = new SelectList(_context.Category1, "Id", "Id", product.Category1Id);
            ViewData["Category2Id"] = new SelectList(_context.Category2, "Id", "Id", product.Category2Id);
            ViewData["Category3Id"] = new SelectList(_context.Category3, "Id", "Id", product.Category3Id);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "Id", product.ProducerId);
            ViewData["UnitId"] = new SelectList(_context.Unit, "Id", "Id", product.UnitId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category1)
                .Include(p => p.Category2)
                .Include(p => p.Category3)
                .Include(p => p.Producer)
                .Include(p => p.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
