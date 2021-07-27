using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kinoshka.Models;
using Kinoshka.Models.Entities;
using Kinoshka.Contexts;

namespace Kinoshka.Controllers
{
    public class MovieRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string MovieRequestGenre, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.MovieRequest
                                            orderby m.Genre
                                            select m.Genre;

            var MovieRequests = from m in _context.MovieRequest select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                MovieRequests = MovieRequests.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(MovieRequestGenre))
            {
                MovieRequests = MovieRequests.Where(s => s.Genre.Contains(MovieRequestGenre));
            }

            var MovieRequestGenreVM = new MovieRequestGenre
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                MovieRequests = await MovieRequests.ToListAsync()
            };

            return View(MovieRequestGenreVM);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MovieRequest = await _context.MovieRequest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (MovieRequest == null)
            {
                return NotFound();
            }

            return View(MovieRequest);
        }

        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Poster, Title, ReleaseDate, Starring, Director, Genre(s), Type, Rating, Summary")] MovieRequest MovieRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(MovieRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(MovieRequest);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MovieRequest = await _context.MovieRequest.FindAsync(id);
            if (MovieRequest == null)
            {
                return NotFound();
            }
            return View(MovieRequest);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Poster, Title, ReleaseDate, Starring, Director, Genre(s), Type, Rating, Summary")] MovieRequest MovieRequest)
        {
            if (id != MovieRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MovieRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieRequestExists(MovieRequest.Id))
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
            return View(MovieRequest);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MovieRequest = await _context.MovieRequest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (MovieRequest == null)
            {
                return NotFound();
            }

            return View(MovieRequest);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var MovieRequest = await _context.MovieRequest.FindAsync(id);
            _context.MovieRequest.Remove(MovieRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieRequestExists(int id)
        {
            return _context.MovieRequest.Any(e => e.Id == id);
        }
    }
}
