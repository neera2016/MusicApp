using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicApp.Controllers.API
{
    public class AlbumsController : Controller
    {


        // GET: /<controller>/
        [HttpGet("api/Albums")]
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["ArtistSortParm"] = String.IsNullOrEmpty(sortOrder) ? "artist_desc" : "";
            ViewData["CurrentFilter"] = searchString;

            var artists = from a in _context.Artists
                         select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(a => a.Artist.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "artist_desc":
                    artists = artists.OrderByDescending(a => a.Artist);
                    break;
            }
            return View(await artists.AsNoTracking().ToListAsync());
        }
    }
}
