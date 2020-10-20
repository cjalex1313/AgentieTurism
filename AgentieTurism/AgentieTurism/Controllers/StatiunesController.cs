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
    public class StatiunesController : Controller
    {
        private readonly AppDbContext _context;

        public StatiunesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Statiunes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Statiuni.ToListAsync());
        }

        // GET: Statiunes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statiune = await _context.Statiuni
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statiune == null)
            {
                return NotFound();
            }

            return View(statiune);
        }

        // GET: Statiunes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statiunes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume")] Statiune statiune)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statiune);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statiune);
        }

        // GET: Statiunes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statiune = await _context.Statiuni.FindAsync(id);
            if (statiune == null)
            {
                return NotFound();
            }
            return View(statiune);
        }

        // POST: Statiunes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume")] Statiune statiune)
        {
            if (id != statiune.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statiune);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatiuneExists(statiune.Id))
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
            return View(statiune);
        }

        // GET: Statiunes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statiune = await _context.Statiuni
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statiune == null)
            {
                return NotFound();
            }

            return View(statiune);
        }

        // POST: Statiunes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statiune = await _context.Statiuni.FindAsync(id);
            _context.Statiuni.Remove(statiune);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatiuneExists(int id)
        {
            return _context.Statiuni.Any(e => e.Id == id);
        }
    }
}
