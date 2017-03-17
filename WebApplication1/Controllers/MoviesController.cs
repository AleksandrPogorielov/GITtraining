using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModels;


namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieRepository _movies;
        private IGenreRepository _genres;
        
        public MoviesController()
        {
            StudContext _context = new StudContext();
            MovieRepository movies = new MovieRepository(_context);
            GenreRepository genres = new GenreRepository(_context);
            _movies = movies;
            _genres = genres;
        }

        private List<Movie> getMovies()
        {
            List<Movie> model = (List<Movie>)_movies.GetAllMovies();

            return model;
        }

        public ActionResult Movies()
        {
            var model = getMovies();
            return View(model);
        }

        public ActionResult MovieForm()
        {
            var genres = _genres.GetAllGenres();
            var viewModel = new MovieFormViewModel();
            viewModel.Genres = genres;
                        
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie);
                viewModel.Genres=_genres.GetAllGenres();
                return View("MovieForm", viewModel);
            }
               
            if (movie.Id == 0)
            {
                _movies.Add(movie);
            }
            else
            {

                _movies.Update(movie);
            }
            return RedirectToAction("Movies", "Movies");
        }

        public ActionResult Edit(int id)
        {
            
            Movie movie = _movies.GetById(id);

            var viewModel = new MovieFormViewModel(movie);
            viewModel.Genres = _genres.GetAllGenres();
            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {

            Movie model = _movies.GetById(id);

            if (model != null)
            {
                return View(model);
            }
            else
            {
                //return RedirectToAction("NotFound", "Errors");
                return new HttpStatusCodeResult(404);
                //return HttpNotFound();
            }

        }
    }
}