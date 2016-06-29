using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movies
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.GenreSet).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.GenreSet).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        public ViewResult New()
         {
             var genres = _context.GenreSets.ToList();
 
            var viewModel = new MovieFormViewModel
             {
                
                 GenreSets = genres
             };
 
             return View("MovieForm", viewModel);
         }
        //edits movies
        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movies)
            {
                
                GenreSets = _context.GenreSets.ToList()
                
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    GenreSets = _context.GenreSets.ToList()
                };
                
                  return View("MovieForm", viewModel);
            }
            
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb           = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name          = movie.Name;
                movieInDb.GenreSetId    = movie.GenreSetId;
                movieInDb.DateAdded     = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            
                _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

       

       [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}