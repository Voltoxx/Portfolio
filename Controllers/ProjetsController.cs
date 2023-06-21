using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ProjetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projets
        public async Task<IActionResult> Index()
        {
              return _context.Projet != null ? 
                          View(await _context.Projet.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Projet'  is null.");
        }

        // GET: Projets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projet == null)
            {
                return NotFound();
            }

            var projets = await _context.Projet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projets == null)
            {
                return NotFound();
            }

            return View(projets);
        }

        // GET: Projets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ImagePrincipale")] Projets projets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projets);
        }

        // GET: Projets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projet == null)
            {
                return NotFound();
            }

            var projets = await _context.Projet.FindAsync(id);
            if (projets == null)
            {
                return NotFound();
            }
            return View(projets);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ImagePrincipale")] Projets projets)
        {
            if (id != projets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetsExists(projets.Id))
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
            return View(projets);
        }

        // GET: Projets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projet == null)
            {
                return NotFound();
            }

            var projets = await _context.Projet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projets == null)
            {
                return NotFound();
            }

            return View(projets);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projet == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Projet'  is null.");
            }
            var projets = await _context.Projet.FindAsync(id);
            if (projets != null)
            {
                _context.Projet.Remove(projets);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetsExists(int id)
        {
          return (_context.Projet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
