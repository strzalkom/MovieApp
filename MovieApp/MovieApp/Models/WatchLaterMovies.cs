using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Models
{
   public class WatchLaterMovies
    {
		public string Title { get; set; }
		public string Overview { get; set; }
		public double Vote_average { get; set; }
		public string Category { get; set; }
		public string Poster_path { get; set; }
		public string Backdrop_path { get; set; }
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

	}
}
