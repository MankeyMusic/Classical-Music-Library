using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Classical_Music_Library_Web_App.Models;
using Classical_Music_Library_Web_App.Data;
using Classical_Music_Library_Web_App.ViewModels;

namespace Classical_Music_Library_Web_App.Controllers
{
    public class MusicController : Controller
    {
        private readonly MusicDbContext _context;

        // Constructor: DbContext injected via dependency injection
        public MusicController(MusicDbContext context)
        {
            _context = context;
        }

        //--- COMPOSER CRUD ---//

        // GET: /Music/Composers (List all)
        public IActionResult Composers()
        {
            var composers = _context.Composers.OrderBy(c => c.LastName).ToList();
            return View(composers); // Renders Views/Music/Composers/Index.cshtml
        }

        // GET: /Music/AddComposer (Show form)
        public IActionResult AddComposer()
        {
            return View(); // Renders Views/Music/Composers/Create.cshtml
        }

        // POST: /Music/AddComposer (Save data)
        [HttpPost]
        public IActionResult AddComposer(Composer composer)
        {
            if (ModelState.IsValid)
            {
                _context.Composers.Add(composer);
                _context.SaveChanges();
                return RedirectToAction("Composers");
            }
            return View(composer);
        }

        //--- COMPOSITION CRUD ---//

        // GET: /Music/Compositions (List all)
        public IActionResult Compositions()
        {
            var compositions = _context.Compositions
                .Include(c => c.Composer)
                .Include(c => c.Genre)
                .Include(c => c.EnsembleType)
                .OrderBy(c => c.Title)
                .ToList();
            return View(compositions); // Renders Views/Music/Compositions/Index.cshtml
        }

        //--- PREDEFINED QUERIES ---//

        // GET: /Music/AvailableRecordings (JOIN query)
        public IActionResult AvailableRecordings()
        {
            var query = from inv in _context.LibraryInventories
                        where inv.Status == "Available"
                        join rec in _context.Recordings on inv.RecordingID equals rec.RecordingID
                        join comp in _context.Compositions on rec.CompositionID equals comp.CompositionID
                        join composer in _context.Composers on comp.ComposerID equals composer.ComposerID
                        select new AvailableRecordingViewModel
                        {
                            ComposerName = $"{composer.FirstName} {composer.LastName}",
                            WorkTitle = comp.Title,
                            Ensemble = rec.EnsembleName,
                            Format = inv.Format,
                            Location = inv.Location
                        };

            return View("Queries/AvailableRecordings", query.ToList());
        }

        // GET: /Music/PopularCompositions (GROUP BY query)
        public IActionResult PopularCompositions()
        {
            var query = from comp in _context.Compositions
                        join rec in _context.Recordings on comp.CompositionID equals rec.CompositionID into recordings
                        where recordings.Count() > 1
                        orderby recordings.Count() descending
                        select new PopularCompositionViewModel
                        {
                            CompositionId = comp.CompositionID,
                            Title = comp.Title,
                            ComposerName = comp.Composer.LastName,
                            RecordingCount = recordings.Count()
                        };

            return View("Queries/PopularCompositions", query.ToList());
        }

        // GET: /Music/CompositionsByEra (Filter by era)
        public IActionResult CompositionsByEra(string era)
        {
            var query = _context.Compositions
                .Include(c => c.Composer)
                .Where(c => c.Composer.Era == era)
                .OrderBy(c => c.Title)
                .ToList();

            ViewBag.Era = era; // Pass era to view
            return View("Queries/CompositionsByEra", query);
        }
    }
}