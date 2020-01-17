using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineTom.Models;
using CineTom.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineTom.Controllers
{
    public class MoviesController : Controller
    {
        DBContext _context;
        public MoviesController( DBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Movies.ToList());
        }

        public IActionResult Create()
        {
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(_context.Movies.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            var m = _context.Movies.Find(movie.Id);
            m.Name = movie.Name;
            m.DurationInSeconds = movie.DurationInSeconds;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
