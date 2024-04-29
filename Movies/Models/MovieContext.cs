using Microsoft.EntityFrameworkCore;

namespace Movies.Models;
public class MovieContext : DbContext
{
	DbSet<Movie> Movies { get; set; } = null!;
	public MovieContext(DbContextOptions<MovieContext> options) : base(options)
	{

	}
}
