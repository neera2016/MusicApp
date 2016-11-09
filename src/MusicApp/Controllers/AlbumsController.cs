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
            ViewBag.SearchString = SearchString;
            var albums = _context.Albums.Include(a => a.Artist).Include(a => a.Genre).ToList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                albums = _context.Albums.Where(a => a.Title.Contains(SearchString)
                                                || a.Artist.Name.Contains(SearchString)
                                                || a.Genre.Name.Contains(SearchString)).ToList();
            }
            ViewBag.TitleSortParm = sortOrder == "Title" ? "title_desc" : "Title";
            ViewBag.ArtistSortParm = sortOrder == "Artist" ? "artist_desc" : "Artist";
            ViewBag.GenreSortParm = sortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.LikeSortParm = sortOrder == "Like" ? "like_desc" : "Like";

            switch (sortOrder)
            {
                case "title_desc":
                    albums = albums.OrderByDescending(a => a.Title ).ToList();
                    break;
                case "Title":
                    albums = albums.OrderBy(a => a.Title).ToList();
                    break;
                case "artist_desc":
                    albums = albums.OrderByDescending(a => a.Artist.Name).ToList();
                    break;
                case "Artist":
                    albums = albums.OrderBy(a => a.Artist.Name).ToList();
                    break;
                case "genre_desc":
                    albums = albums.OrderByDescending(a => a.Genre.Name).ToList();
                    break;
                case "Genre":
                    albums = albums.OrderBy(a => a.Genre.Name).ToList();
                    break;
                case "price_desc":
                    albums = albums.OrderByDescending(a => a.Price).ToList();
                    break;
                case "Price":
                    albums = albums.OrderBy(a => a.Price).ToList();
                    break;
                case "like_desc":
                    albums = albums.OrderByDescending(a => a.Like).ToList();
                    break;
                case "Like":
                    albums = albums.OrderBy(a => a.Like).ToList();
                    break;
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
        public IActionResult Create(Album album, string ArtistString, string GenreString)
        {
            ModelState.Remove("ArtistID");
            ModelState.Remove("GenreID");
            ViewBag.Artist = new SelectList(_context.Artists.ToList(), "ArtistID", "Name");
            ViewBag.Genre = new SelectList(_context.Genres.ToList(), "GenreID", "Name");

            if (string.IsNullOrEmpty(ArtistString) && album.ArtistID == 0)
            {
                ModelState.AddModelError("ArtistID", "Artist is required.");
            }
            if (!string.IsNullOrEmpty(ArtistString) && _context.Artists.Any(a => a.Name == ArtistString))
            {
                Artist newArtist = new Artist { Name = ArtistString };
                _context.Artists.Add(newArtist);
                _context.SaveChanges();
                album.ArtistID = newArtist.ArtistID;
                album.Artist = newArtist;
            }
            

            if (string.IsNullOrEmpty(GenreString) && album.GenreID == 0)
            {
                ModelState.AddModelError("GenreID", "Genre is required.");
            }
            if (!string.IsNullOrEmpty(GenreString) && _context.Genres.Any(a => a.Name == GenreString))
            {
                Genre newGenre = new Genre { Name = GenreString };
                _context.Genres.Add(newGenre);
                _context.SaveChanges();
                album.GenreID = newGenre.GenreID;
                album.Genre = newGenre;
            }
           

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

        public IActionResult Likes(int? id)
        {
            var album = _context.Albums.Include(a => a.Artist).Include(g => g.Genre).SingleOrDefault(a => a.AlbumID == id);
            if (id == null)
            {
                return NotFound();
            }
            if (album == null)
            {
                return NotFound();
            }
            album.Like++;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
