using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public MoviesViewModel MoviesVm { get; private set; }

        public MoviesController()
        {
            var movies = new List<Movie>()
            {
                new Movie { Name = "Shrek!", Id = 0 },
                new Movie { Name = "another movie", Id = 1 },
            };

            MoviesVm = new MoviesViewModel()
            {
                Movies = movies
            };
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };
            var customers = new List<Customer>
             {
                 new Customer{ Name = "Customer 1"},
                new Customer{ Name = "Customer 2"}
             };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model
            
            return View(viewModel);
            //return HttpNotFound();
            //return Content("hi");
            //return new ViewResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]  
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return View(MoviesVm); //Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult MovieDetails(int id)
        {
            var model = MoviesVm?.Movies?.FirstOrDefault(movie => movie.Id == id);

            if (model == null)
                return HttpNotFound();

            return View(model);
        }
    }
}