using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DAL;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Api
{
    public class MovieController : ApiController
    {
        private IMovieRepository _movies;
        private IGenreRepository _genres;
        public MovieController()
        {
            StudContext _context = new StudContext();
            MovieRepository movies = new MovieRepository(_context);//JsonCustomerRepository or CustomerRepository
            GenreRepository genres = new GenreRepository(_context);
            _movies = movies;
            _genres = genres;
        }

        public IHttpActionResult GetMovies()
        {
            var movies = _movies.GetAllMovies();
            if (movies.Count == 0)
            {
                return NotFound();
            }
            return Ok(movies.Select(Mapper.Map<Movie, MovieDto>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _movies.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)//POST
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _movies.Add(movie);
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)//PUT
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            try
            {
                var movie = Mapper.Map<MovieDto, Movie>(movieDto);
                _movies.Update(movie);                
            }
            catch
            {
                NotFound();
            }
            return Ok(movieDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _movies.GetById(id);

            if (customerInDb == null)
            {
                NotFound();
            }

            _movies.Delete(customerInDb);
            return Ok();
        }
    }
}
