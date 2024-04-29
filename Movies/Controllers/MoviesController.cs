using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly MovieContext _movieContext;

		public MoviesController(MovieContext movieContext)
		{
			_movieContext = movieContext;
		}


		//GET: api/movies
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
		{
			if (_movieContext.Movies == null)
			{
				return NotFound();
			}

			return await _movieContext.Movies.ToListAsync();
		}

		//GET: api/movies/3
		[HttpGet("{id}")]
		public async Task<ActionResult<Movie>> GetMovie(int id)
		{
			if (_movieContext.Movies == null)
			{
				return NotFound();
			}

			var movie = await _movieContext.Movies.FindAsync(id);
			if (movie == null)
			{
				return NotFound();
			}
			return Ok(movie);
		}

		//POST: api/movies
		[HttpPost]
		public async Task<ActionResult<Movie>> PostMovie([FromBody] Movie movie)
		{
			_movieContext.Movies.Add(movie);
			await _movieContext.SaveChangesAsync();
			return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
		}

		//PUT: api/movies/3
		[HttpPut("{id}")]
		public async Task<ActionResult<Movie>> UpdateMovie(int id, [FromBody] Movie movie)
		{
			if (id != movie.Id)
			{
				return BadRequest();
			}
			_movieContext.Entry(movie).State = EntityState.Modified;

			try
			{
				await _movieContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MovieExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return NoContent();
		}

		//DELETE: api/movies/3
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteMovie(int id)
		{
			if (_movieContext.Movies == null)
			{
				return NotFound();
			}

			var movie = await _movieContext.Movies.FindAsync(id);
			if (movie == null)
			{
				return NotFound();
			}
			_movieContext.Movies.Remove(movie);
			await _movieContext.SaveChangesAsync();
			return NoContent();
		}

		private bool MovieExists(long id)
		{
			return (_movieContext.Movies?.Any(m => m.Id == id)).GetValueOrDefault();
		}
	}
}
