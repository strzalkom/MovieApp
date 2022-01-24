using SQLite;
using System;
namespace MovieApp
{
	public class Movie
	{
		public string Title { get; set; }
		public string Overview { get; set; }
		public double Vote_average { get; set; }
		public string Category { get; set; }
		public string Poster_path { get; set; }
		public string Backdrop_path { get; set; }
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public Movie()
		{
		}

	
		public Movie(string Title, string Overview, string Category, double Vote_average)
		{
			this.Title = Title;
			this.Overview = Overview;
			this.Category = Category;
			this.Vote_average = Vote_average;
		}

	}
}
