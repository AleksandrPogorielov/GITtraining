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
    public class RentApiController : ApiController
    {
        private IRentRepository _rents;
        private IMovieRepository _movies;
        
        public RentApiController()
        {
            StudContext _context = new StudContext();
            RentRepository rents = new RentRepository(_context);
            MovieRepository movies = new MovieRepository(_context);
            _rents = rents;
            _movies = movies;
        }

        public IHttpActionResult GetRents()
        {
            var rents = _rents.GetAllRents();
            if (rents.Count == 0)
            {
                return NotFound();
            }
            return Ok(rents.Select(Mapper.Map<Rent, RentDto>));
        }

        public IHttpActionResult GetRent(int id)
        {
            var rent = _rents.GetById(id);
            if (rent == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Rent, RentDto>(rent));
        }

        [HttpPost]
        public IHttpActionResult CreateRent(RentDto rentDto)//POST
        {
            //foreach (var item in rentDto.Movies)
            //{
                
            //}
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var rent = Mapper.Map<RentDto, Rent>(rentDto);
            _rents.Add(rent);            
            rentDto.Id = rent.Id;
            foreach (Movie m in rent.Movies)
            {
                m.count -= 1;
                _movies.Update(m);
            }
            
            return Created(new Uri(Request.RequestUri + "/" + rent.Id), rentDto);
        }

        public IHttpActionResult UpdateRent(int id, RentDto rentDto)//PUT
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            try
            {
                var rent = Mapper.Map<RentDto, Rent>(rentDto);
                _rents.Update(rent);

            }
            catch
            {
                return NotFound();
            }
            return Ok(rentDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteRent(int id)
        {
            var rentInDb = _rents.GetById(id);

            if (rentInDb == null)
            {
                return NotFound();
            }
            _rents.Delete(rentInDb);
            return Ok();
        }
    }
}
