using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FSB.Data;
using fsb.Models;
using FSB.Models;

namespace FSB.Controllers
{
    public class DocsController : Controller
    {
        private readonly FSBContext _context;

        public DocsController(FSBContext context)
        {
            _context = context;
        }

        // GET: Docs
        public async Task<IActionResult> Index(string DocTypes, string searchString)
        {
            if (_context.Docs == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Docs
                                            orderby m.Title
                                            select m.Title;
            var movies = from m in _context.Docs
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.FIO!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(DocTypes))
            {
                movies = movies.Where(x => x.Title == DocTypes);
            }

            var movieGenreVM = new ViewModel
            {
                Types = new SelectList(await genreQuery.Distinct().ToListAsync()),
                FIO = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Docs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docs = await _context.Docs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (docs == null)
            {
                return NotFound();
            }

            return View(docs);
        }

        // GET: Docs/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FIO,Title,Date,place")] Docs docs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docs);
        }

        // GET: Docs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docs = await _context.Docs.FindAsync(id);
            if (docs == null)
            {
                return NotFound();
            }
            return View(docs);
        }

        // POST: Docs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FIO,Title,Date,place")] Docs docs)
        {
            if (id != docs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocsExists(docs.Id))
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
            return View(docs);
        }

        // GET: Docs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docs = await _context.Docs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (docs == null)
            {
                return NotFound();
            }

            return View(docs);
        }

        // POST: Docs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docs = await _context.Docs.FindAsync(id);
            if (docs != null)
            {
                _context.Docs.Remove(docs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocsExists(int id)
        {
            return _context.Docs.Any(e => e.Id == id);
        }
    }
}
