using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project5.Controllers
{
    public class HomeController : Controller
    {
        private MovieListContext mlContext { get; set; }
        public HomeController(MovieListContext someName)
        {
            mlContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies()
        {
            ViewBag.Categories = mlContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult EnterMovies(MovieLists ml)
        {
            if (ModelState.IsValid)
            {
                mlContext.Add(ml);
                mlContext.SaveChanges();
                return View("Index", ml);
            }
            else
            {
                ViewBag.Categories = mlContext.Categories.ToList();
                return View(ml);
            }
            //Puts what the user just inserted in the new movie into the database
        }
        public IActionResult MovieCollection()
        {
            var movies = mlContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = mlContext.Categories.ToList();

            var movies = mlContext.Responses.Single(x => x.MovieId == movieid);
            return View("EnterMovies", movies);
        }
        [HttpPost]
        public IActionResult Edit (MovieLists ml)
        {
            mlContext.Update(ml);
            mlContext.SaveChanges();
            return RedirectToAction("MovieCollection");
        }
        [HttpGet]
        public IActionResult Delete (int movieid)
        {
            var movie = mlContext.Responses.Single(x => x.MovieId == movieid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete (MovieLists ml)
        {
            mlContext.Responses.Remove(ml);
            mlContext.SaveChanges();

            return RedirectToAction("MovieCollection");
        }
    }
}
