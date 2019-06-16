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
    public class Category2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Category2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category2.ToListAsync());
        }

        // GET: Category2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category2 = await _context.Category2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category2 == null)
            {
                return NotFound();
            }

            return View(category2);
        }

        // GET: Category2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category2 category2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category2);
        }

        // GET: Category2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category2 = await _context.Category2.FindAsync(id);
            if (category2 == null)
            {
                return NotFound();
            }
            return View(category2);
        }

        // POST: Category2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category2 category2)
        {
            if (id != category2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Category2Exists(category2.Id))
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
            return View(category2);
        }

        // GET: Category2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category2 = await _context.Category2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category2 == null)
            {
                return NotFound();
            }

            return View(category2);
        }

        // POST: Category2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category2 = await _context.Category2.FindAsync(id);
            _context.Category2.Remove(category2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Category2Exists(int id)
        {
            return _context.Category2.Any(e => e.Id == id);
        }
    }
}
