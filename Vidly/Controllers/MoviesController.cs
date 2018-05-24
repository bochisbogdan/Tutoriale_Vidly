using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Linq;
using System;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            return View(movie);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewMovieViewModel viewModel)
        {

            var movie = viewModel.Movie;
           
           

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.StockNumber = movie.StockNumber;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genre  
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            var genre = _context.Genres.ToList();
            if (movie.Id == null)
                return HttpNotFound();
            
            
           var viewModel = new NewMovieViewModel()
            {
                    Movie = movie,
                    Genres = genre

            };
           
            return View("MovieForm", viewModel);
        }

    }
}