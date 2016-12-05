using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MusicApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp.Controllers
{
    [Authorize]
    public class PlaylistsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
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
            var playlist = _context.Playlists.ToList();
            return View(playlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
                playlist.User = user;
                _context.Add(playlist);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playlist);
        }
        
        [HttpPost]
        public IActionResult Add(int id, int PlaylistID)
        {
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            var playlist = _context.Playlists.SingleOrDefault(p => p.PlaylistID == PlaylistID);
            PlaylistExtension playListAlbums = new PlaylistExtension { AlbumID = id, PlaylistID = PlaylistID };
            if (ModelState.IsValid)
            {
                _context.Add(playListAlbums);
                _context.SaveChanges();
                return RedirectToAction("Details", "Playlists", new {id = PlaylistID });
            }
            return View(playlist);
        }

        public IActionResult Add(int? id)
        {
            var playlist = _context.Playlists.Where(u => u.User.UserName == User.Identity.Name).ToList();
            ViewBag.Playlist = new SelectList(playlist, "PlaylistID", "Name");
            var album = _context.Albums.SingleOrDefault(a => a.AlbumID == id);
            return View(album);
        }
        
        public IActionResult Details(int id)
        {
            var playlist = _context.Playlists.SingleOrDefault(p => p.PlaylistID == id);
            ViewBag.PlaylistExtensions = _context.PlaylistExtension.Include(a => a.album).Where(a => a.PlaylistID == id).ToList();
            return View(playlist);            
        }

        [HttpPost]
        public IActionResult Edit(Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Update(playlist);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(playlist);
        }
               
        public IActionResult Edit(int id)
        {
            var playlist = _context.Playlists.SingleOrDefault(a => a.PlaylistID == id);
            return View(playlist);
        }

        public IActionResult Delete(int id)
        {
            var playlist = _context.Playlists.SingleOrDefault(a => a.PlaylistID == id);
            return View(playlist);
        }

        [HttpPost]
        public IActionResult Remove(int PlaylistID)
        {
            var playlist = _context.Playlists.SingleOrDefault(a => a.PlaylistID == PlaylistID);
            _context.Playlists.Remove(playlist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
