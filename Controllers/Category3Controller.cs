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
    public class Category3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Category3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category3.ToListAsync());
        }

        // GET: Category3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category3 = await _context.Category3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category3 == null)
            {
                return NotFound();
            }

            return View(category3);
        }

        // GET: Category3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category3 category3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category3);
        }

        // GET: Category3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category3 = await _context.Category3.FindAsync(id);
            if (category3 == null)
            {
                return NotFound();
            }
            return View(category3);
        }

        // POST: Category3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category3 category3)
        {
            if (id != category3.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Category3Exists(category3.Id))
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
            return View(category3);
        }

        // GET: Category3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category3 = await _context.Category3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category3 == null)
            {
                return NotFound();
            }

            return View(category3);
        }

        // POST: Category3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category3 = await _context.Category3.FindAsync(id);
            _context.Category3.Remove(category3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Category3Exists(int id)
        {
            return _context.Category3.Any(e => e.Id == id);
        }
    }
}
