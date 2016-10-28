using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult Index()
        {
            return View(_context.Albums.Include(a => a.Artist).Include(g => g.Genre).ToList());
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
            var album = _context.Albums.Include(a => a.Artist).Include(g => g.Genre).SingleOrDefault(a => a.AlbumID == id);
            return View(album);
        }

        [HttpPost]
        public IActionResult Delete(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Albums.Update(album);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
            //return View();
        }
    }
}
