using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MusicApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp.Controllers
{
    [Authorize]
    public class PlaylistsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MusicDbContext _context;

        public PlaylistsController(MusicDbContext context,
                                  UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.User = _userManager.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
            //var playlists = _context.Albums.Include(a => a.Title).ToList();
            return View();
            //return View(playlists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Playlist playlist)
        {
            return View();
        }

        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var album = _context.Albums.Include(a => a.Artist).Include(g => g.Genre).SingleOrDefault(a => a.AlbumID == id);
            ViewBag.Suggestions = _context.Albums.Where(a => (a.Artist == album.Artist ||
                                                              a.Genre == album.Genre)
                                                              && a.AlbumID == album.AlbumID);
            return View(album);
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
