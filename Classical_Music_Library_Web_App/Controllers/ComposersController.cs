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
    public class ComposersController : Controller
    {
        private readonly MusicDbContext _context;

        public ComposersController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: Composers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Composers.ToListAsync());
        }

        // GET: Composers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composer = await _context.Composers
                .FirstOrDefaultAsync(m => m.ComposerID == id);
            if (composer == null)
            {
                return NotFound();
            }

            return View(composer);
        }

        // GET: Composers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Composers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComposerID,FirstName,LastName,Era,Nationality,BirthYear")] Composer composer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(composer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(composer);
        }

        // GET: Composers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composer = await _context.Composers.FindAsync(id);
            if (composer == null)
            {
                return NotFound();
            }
            return View(composer);
        }

        // POST: Composers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComposerID,FirstName,LastName,Era,Nationality,BirthYear")] Composer composer)
        {
            if (id != composer.ComposerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(composer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComposerExists(composer.ComposerID))
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
            return View(composer);
        }

        // GET: Composers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var composer = await _context.Composers
                .FirstOrDefaultAsync(m => m.ComposerID == id);
            if (composer == null)
            {
                return NotFound();
            }

            return View(composer);
        }

        // POST: Composers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var composer = await _context.Composers.FindAsync(id);
            if (composer != null)
            {
                _context.Composers.Remove(composer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComposerExists(int id)
        {
            return _context.Composers.Any(e => e.ComposerID == id);
        }
    }
}
