using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly MusicDbContext _context;

        public AlbumsController(MusicDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index(string SearchString, string sortOrder)
        {
            var albums = _context.Albums.Include(a => a.Artist).Include(g => g.Genre).ToList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                albums = _context.Albums.Where(a => a.Title.Contains(SearchString) || a.Artist.Name.Contains(SearchString) || a.Genre.Name.Contains(SearchString)).ToList();
            }
            ViewData["TitleSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["ArtistSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["GenreSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["LikeSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var album = from a in _context.Albums
                           select a;
            switch (sortOrder)
            {
                case "name_desc":
                    album = album.OrderByDescending(a => a.Title );
                    break;
                case "name_asc":
                    album = album.OrderByDescending(a => a.Title);
                    break;
                case "name_desc":
                    album = album.OrderByDescending(a => a.Artist);
                    break;
                case "name_asc":
                    album = album.OrderByDescending(a => a.Artist);
                    break;
                case "name_desc":
                    album = album.OrderByDescending(a => a.Genre);
                    break;
                case "name_asc":
                    album = album.OrderByDescending(a => a.Genre);
                    break;
                case "name_desc":
                    album = album.OrderByDescending(a => a.Price);
                    break;
                case "name_asc":
                    album = album.OrderByDescending(a => a.Price);
                    break;
                //case "name_desc":
                //    album = album.OrderByDescending(a => a.Like);
                //    break;
                //case "name_asc":
                //    album = album.OrderByDescending(a => a.Like);
                //    break;
            }

            return View(albums);
        }

        public IActionResult Create()
        {
            ViewBag.Artist = new SelectList(_context.Artists.ToList(), "ArtistID", "Name");
            ViewBag.Genre = new SelectList(_context.Genres.ToList(), "GenreID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Album album)
        {
            ViewBag.Artist = new SelectList(_context.Artists.ToList(), "ArtistID", "Name");
            ViewBag.Genre = new SelectList(_context.Genres.ToList(), "GenreID", "Name");
            if (ModelState.IsValid)
            {
                _context.Albums.Add(album);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        public IActionResult Edit(int id)
        {
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            ViewBag.Artist = new SelectList(_context.Artists.ToList(), "ArtistID", "Name");
            ViewBag.Genre = new SelectList(_context.Genres.ToList(), "GenreID", "Name");
            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Albums.Update(album);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        public IActionResult Details(int id)
        {
            var album = _context.Albums.Include(a => a.Artist).Include(g => g.Genre).SingleOrDefault(a => a.AlbumID == id);
            return View(album);
        }

        [HttpPost]
        public IActionResult Details(Album album)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var album = _context.Albums.Include(a => a.Artist).SingleOrDefault(a => a.AlbumID == id);
            return View(album);
        }

        [HttpPost]
        public IActionResult Remove(int AlbumID)
        {
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == AlbumID);
            _context.Albums.Remove(album);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
