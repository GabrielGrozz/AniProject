using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AniProject.Context;
using AniProject.Models;

namespace AniProject.Controllers
{
    public class AnimesDataController : Controller
    {
        private readonly DataContext _context;

        public AnimesDataController(DataContext context)
        {
            _context = context;
        }

        // GET: AnimesData
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Animes.Include(a => a.Category);
            return View(await dataContext.ToListAsync());
        }

        // GET: AnimesData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimeId == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: AnimesData/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryDescription");
            return View();
        }

        // POST: AnimesData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimeId,AnimeName,AnimeDescription,CategoryId")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryDescription", anime.CategoryId);
            return View(anime);
        }

        // GET: AnimesData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryDescription", anime.CategoryId);
            return View(anime);
        }

        // POST: AnimesData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimeId,AnimeName,AnimeDescription,AnimeImage,CategoryId")] Anime anime)
        {
            if (id != anime.AnimeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeExists(anime.AnimeId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryDescription", anime.CategoryId);
            return View(anime);
        }

        // GET: AnimesData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.AnimeId == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: AnimesData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animes == null)
            {
                return Problem("Entity set 'DataContext.Animes'  is null.");
            }
            var anime = await _context.Animes.FindAsync(id);
            if (anime != null)
            {
                _context.Animes.Remove(anime);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
          return _context.Animes.Any(e => e.AnimeId == id);
        }
    }
}
