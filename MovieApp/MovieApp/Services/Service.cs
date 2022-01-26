using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieApp
{
	public class Service
	{

		HttpClient client;

		public Service()
		{
			client = new HttpClient();
		}

		public async Task<List<Movie>> GetPopularMovies()
		{
			List<Movie> popularMovies = new List<Movie>();

			var uri = new Uri("https://api.themoviedb.org/3/movie/popular?api_key=" + Keys.API_KEY);
			var response = await client.GetAsync(uri);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				JObject body = JObject.Parse(content);
				string resultsString = body.SelectToken("results").ToString();
				popularMovies = JsonConvert.DeserializeObject<List<Movie>>(resultsString);


			}
			Console.WriteLine("Standard Numeric Format Specifiers");
			Console.WriteLine(popularMovies[0].Title); //Spider-Man: No Way Home
			Console.WriteLine(popularMovies[0].Vote_average); //8.5
			Console.WriteLine(popularMovies[0].Overview); //Peter Parker is unmasked and no longer able to separate his normal life from the high-stakes of being a super-hero. When he asks for help from Doctor Strange the stakes become even more dangerous, forcing him to discover what it truly means to be Spider-Man.
			Console.WriteLine(popularMovies[0].Poster_path); ///1g0dhYtq4irTY1GPXvft6k4YLjm.jpg
			//Console.WriteLine(string.Join("\t", popularMovies));
			return popularMovies;
		}

		public async Task<List<Movie>> GetCommunityMovies()
		{
			List<Movie> comMovies = new List<Movie>();

			var uri = new Uri("https://api.themoviedb.org/3/movie/popular?api_key=" + Keys.API_KEY);
			var response = await client.GetAsync(uri);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();

				JObject body = JObject.Parse(content);
				string resultsString = body.SelectToken("results").ToString();
				comMovies = JsonConvert.DeserializeObject<List<Movie>>(resultsString);


			}
			Console.WriteLine("Standard Numeric Format Specifiers");
			Console.WriteLine(comMovies[0].Title); //Spider-Man: No Way Home
			Console.WriteLine(comMovies[0].Vote_average); //8.5
			Console.WriteLine(comMovies[0].Overview); //Peter Parker is unmasked and no longer able to separate his normal life from the high-stakes of being a super-hero. When he asks for help from Doctor Strange the stakes become even more dangerous, forcing him to discover what it truly means to be Spider-Man.
			Console.WriteLine(comMovies[0].Poster_path); ///1g0dhYtq4irTY1GPXvft6k4YLjm.jpg
			//Console.WriteLine(string.Join("\t", popularMovies));
			return comMovies;
		}

	}
}
