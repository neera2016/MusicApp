using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MusicApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            ViewData["Message"] = "This application is used to keep track of music albums and their properties on a database.";

            ViewData["Message2"] = "Contacts";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
