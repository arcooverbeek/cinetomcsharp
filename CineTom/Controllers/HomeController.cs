using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CineTom.Models;
using CineTom.Persistence;

namespace CineTom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext _context;

        public HomeController(ILogger<HomeController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            if(movies.Count <= 1)
            {
                for(int i = 0; i< 10; i++)
                {
                    _context.Movies.Add(new Movie
                    {
                        Name = $"Brokeback mountain {i}",
                        DurationInSeconds = 341285761
                    });
                    _context.SaveChanges();
                }
                
                movies = _context.Movies.ToList();
            }
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
