using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MusicApp.Models;
using Microsoft.AspNetCore.Identity;

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
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Remove()
        {
            return View();
        }
    }
}
