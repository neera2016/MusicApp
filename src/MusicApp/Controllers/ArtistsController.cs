using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly MusicDbContext _context;

        public ArtistsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var artists = _context.Artists.ToList();
            return View(artists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            if (_context.Artists.Any(a => a.Name == artist.Name))
            {
                ModelState.AddModelError("Name", "This Artist already exists.");
            }
            if (ModelState.IsValid)
            {
                _context.Artists.Add(artist);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        public IActionResult Edit(int id)
        {
            var artist = _context.Artists.SingleOrDefault(a => a.ArtistID == id);
            return View(artist);
        }

        [HttpPost]
        public IActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Artists.Update(artist);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        public IActionResult Details(int id)
        {
            var artist = _context.Artists.SingleOrDefault(a => a.ArtistID == id);
            ViewBag.Albums = _context.Albums.Where(a => a.ArtistID == id).ToList();
            return View(artist);
        }

        [HttpPost]
        public IActionResult Details(Artist artist)
        {
            return View();
        }
    }
}
