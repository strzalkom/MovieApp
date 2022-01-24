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

			return popularMovies;
		}

	}
}
