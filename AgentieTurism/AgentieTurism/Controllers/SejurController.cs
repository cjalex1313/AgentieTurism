using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Data;
using AgentieTurism.Data.Models;

namespace AgentieTurism.Controllers
{
    public class SejurController : Controller
    {
        private readonly AppDbContext _context;

        public SejurController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sejur
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Sejururi.Include(s => s.Statiune);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Sejur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sejur = await _context.Sejururi
                .Include(s => s.Statiune)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sejur == null)
            {
                return NotFound();
            }

            return View(sejur);
        }

        // GET: Sejur/Create
        public IActionResult Create()
        {
            ViewData["StatiuneId"] = new SelectList(_context.Statiuni, "Id", "Nume");
            return View();
        }

        // POST: Sejur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataStart,DataSfarsit,StatiuneId")] Sejur sejur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sejur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatiuneId"] = new SelectList(_context.Statiuni, "Id", "Id", sejur.StatiuneId);
            return View(sejur);
        }

        // GET: Sejur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sejur = await _context.Sejururi.FindAsync(id);
            if (sejur == null)
            {
                return NotFound();
            }
            ViewData["StatiuneId"] = new SelectList(_context.Statiuni, "Id", "Id", sejur.StatiuneId);
            return View(sejur);
        }

        // POST: Sejur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataStart,DataSfarsit,StatiuneId")] Sejur sejur)
        {
            if (id != sejur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sejur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SejurExists(sejur.Id))
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
            ViewData["StatiuneId"] = new SelectList(_context.Statiuni, "Id", "Nume", sejur.StatiuneId);
            return View(sejur);
        }

        // GET: Sejur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sejur = await _context.Sejururi
                .Include(s => s.Statiune)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sejur == null)
            {
                return NotFound();
            }

            return View(sejur);
        }

        // POST: Sejur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sejur = await _context.Sejururi.FindAsync(id);
            _context.Sejururi.Remove(sejur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SejurExists(int id)
        {
            return _context.Sejururi.Any(e => e.Id == id);
        }
    }
}
