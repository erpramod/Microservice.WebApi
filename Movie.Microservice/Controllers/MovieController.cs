using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Microservice.Data;

namespace Movie.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IApplicationDbContext _context;
        public MovieController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                await _context.SaveChanges();
                return Ok(movie.Id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var getMovie = await _context.Movies.ToListAsync();
                if (getMovie == null) return NotFound();
                return Ok(getMovie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }
        [HttpGet("{genre}")]
        public async Task<IActionResult> GetById(string genre)
        {
            try
            {
                var movie = await _context.Movies.Where(a => a.Genre.Contains(genre)).FirstOrDefaultAsync();
                if (movie == null) return NotFound();
                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
           
        }
    }
}