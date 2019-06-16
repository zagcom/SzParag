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
    public class Category1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Category1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Category1.ToListAsync());
        }

        // GET: Category1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category1 = await _context.Category1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category1 == null)
            {
                return NotFound();
            }

            return View(category1);
        }

        // GET: Category1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Category1 category1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category1);
        }

        // GET: Category1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category1 = await _context.Category1.FindAsync(id);
            if (category1 == null)
            {
                return NotFound();
            }
            return View(category1);
        }

        // POST: Category1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category1 category1)
        {
            if (id != category1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Category1Exists(category1.Id))
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
            return View(category1);
        }

        // GET: Category1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category1 = await _context.Category1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category1 == null)
            {
                return NotFound();
            }

            return View(category1);
        }

        // POST: Category1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category1 = await _context.Category1.FindAsync(id);
            _context.Category1.Remove(category1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Category1Exists(int id)
        {
            return _context.Category1.Any(e => e.Id == id);
        }
    }
}
