﻿using System.ComponentModel.DataAnnotations;

namespace Movies.Models;
public class Movie
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Genre { get; set; }

	[DataType(DataType.Date)]
	public DateTime ReleaseDate { get; set; }
}
