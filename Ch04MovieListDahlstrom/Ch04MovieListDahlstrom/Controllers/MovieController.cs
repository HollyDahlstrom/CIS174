/*
 * Author: Holly Dahlstrom
 * Course: CIS 174
 * Project: Ch 04 Movie List App
 * Date: January 23, 2026; Added to 2/11/26
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
            // Set ViewBag.Name for the welcome message
            ViewBag.Name = "Student";

            //
            ViewData["ViewDataProperty"] = "View Data Works!";

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

        // ====== Dummy Pages for Assignment ======

        // Default routing page
        public IActionResult DefaultPage()
        {
            return View();
        }

        // Custom attribute routing page
        [Route("Movie/AttributePage")]
        public IActionResult AttributePage()
        {
            ViewData["Title"] = "Attribute Routing Page";
            return View();
        }

        // Display
        public IActionResult Display(string id)
        {
            int cnt = Convert.ToInt32(id);
            return View(cnt);
        }

        // Admin area page (dummy)
        public IActionResult Admin()
        {
            return View();
        }

        // Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OtherPrivacy()
        {
            return View("Privacy");
        }

        // Static Content
        public IActionResult StaticContent(string num)
        {
            return Content($"Static Content: {num}");
        }

        // Index Override
        [Route("/")]
        public IActionResult IndexOverride()
        {
            return Content("Index Override!");
        }
    }
}