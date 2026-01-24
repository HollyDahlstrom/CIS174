/*
 * Author: Holly Dahlstrom
 * Course: CIS 174
 * Project: Ch 04 Movie List App
 * Date: January 23, 2026
 * Description: Controller for managing movies (list, add, edit, delete)
 */

using Ch04MovieListDahlstrom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ch04MovieListDahlstrom.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext context { get; set; }

        public MovieController(MovieContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Genres = context.Genres.ToList();
            ViewBag.Action = "Add";
            return View("Edit", new Movie());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = context.Genres.ToList();
            ViewBag.Action = "Edit";
            var movie = this.context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    this.context.Movies.Add(movie);
                }
                else
                {
                    this.context.Movies.Update(movie);
                }
                this.context.SaveChanges();
                return RedirectToAction("Index", "Movie");
            }
            else
            {
                ViewBag.Genres = context.Genres.ToList();
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                return View(movie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = this.context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            //context.Movies.Remove(movie);
            //context.SaveChanges();
            this.context.Movies.Remove(movie);
            this.context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}