using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;
        }
        // GET api/movie
        [HttpGet]
        public IActionResult Get()
        {
            // Retrieve all movies from db logic
            var movies = _context.Movies;
            //return Ok(new string[] { "movie1 string", "movie2 string" });
            return Ok(movies);
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Retrieve movie by id from db logic
            // return Ok(movie);
            var movies = _context.Movies.Where(m => m.MovieId == id).FirstOrDefault();
            return Ok(movies);
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody]Movie value)
        {
            // Create movie in db logic
          
            try
            {
                _context.Movies.Add(value);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        // PUT api/movie
        [HttpPut]
        public IActionResult Put([FromBody] Movie movie)
        {
            // Update movie in db logic
            try
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete movie from db logic
            var song = _context.Movies.Where(e => e.MovieId == id).FirstOrDefault();


            try
            {
                _context.Movies.Remove(song);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }
    }
}