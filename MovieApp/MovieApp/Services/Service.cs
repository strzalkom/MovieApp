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

			

			return popularMovies;
		}

	}
}
