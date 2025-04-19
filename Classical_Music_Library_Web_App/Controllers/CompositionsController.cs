using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Classical_Music_Library_Web_App.Models;

namespace Classical_Music_Library_Web_App.Controllers
{
    public class CompositionsController : Controller
    {
        private readonly MusicDbContext _context;

        public CompositionsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: Compositions
        public async Task<IActionResult> Index()
        {
            var musicDbContext = _context.Compositions.Include(c => c.Composer).Include(c => c.EnsembleType).Include(c => c.Genre);
            return View(await musicDbContext.ToListAsync());
        }

        // GET: Compositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composition = await _context.Compositions
                .Include(c => c.Composer)
                .Include(c => c.EnsembleType)
                .Include(c => c.Genre)
                .FirstOrDefaultAsync(m => m.CompositionID == id);
            if (composition == null)
            {
                return NotFound();
            }

            return View(composition);
        }

        // GET: Compositions/Create
        public IActionResult Create()
        {
            ViewData["ComposerID"] = new SelectList(_context.Composers, "ComposerID", "ComposerID");
            ViewData["EnsembleTypeID"] = new SelectList(_context.EnsembleTypes, "EnsembleTypeID", "EnsembleTypeID");
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID");
            return View();
        }

        // POST: Compositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompositionID,Title,ComposerID,EnsembleTypeID,GenreID,YearComposed")] Composition composition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(composition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComposerID"] = new SelectList(_context.Composers, "ComposerID", "ComposerID", composition.ComposerID);
            ViewData["EnsembleTypeID"] = new SelectList(_context.EnsembleTypes, "EnsembleTypeID", "EnsembleTypeID", composition.EnsembleTypeID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID", composition.GenreID);
            return View(composition);
        }

        // GET: Compositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composition = await _context.Compositions.FindAsync(id);
            if (composition == null)
            {
                return NotFound();
            }
            ViewData["ComposerID"] = new SelectList(_context.Composers, "ComposerID", "ComposerID", composition.ComposerID);
            ViewData["EnsembleTypeID"] = new SelectList(_context.EnsembleTypes, "EnsembleTypeID", "EnsembleTypeID", composition.EnsembleTypeID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID", composition.GenreID);
            return View(composition);
        }

        // POST: Compositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompositionID,Title,ComposerID,EnsembleTypeID,GenreID,YearComposed")] Composition composition)
        {
            if (id != composition.CompositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(composition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompositionExists(composition.CompositionID))
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
            ViewData["ComposerID"] = new SelectList(_context.Composers, "ComposerID", "ComposerID", composition.ComposerID);
            ViewData["EnsembleTypeID"] = new SelectList(_context.EnsembleTypes, "EnsembleTypeID", "EnsembleTypeID", composition.EnsembleTypeID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID", composition.GenreID);
            return View(composition);
        }

        // GET: Compositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composition = await _context.Compositions
                .Include(c => c.Composer)
                .Include(c => c.EnsembleType)
                .Include(c => c.Genre)
                .FirstOrDefaultAsync(m => m.CompositionID == id);
            if (composition == null)
            {
                return NotFound();
            }

            return View(composition);
        }

        // POST: Compositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var composition = await _context.Compositions.FindAsync(id);
            if (composition != null)
            {
                _context.Compositions.Remove(composition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompositionExists(int id)
        {
            return _context.Compositions.Any(e => e.CompositionID == id);
        }
    }
}
