using MovieApp.Models;
using Newtonsoft.Json;
using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace MovieApp
{
  public  class MainPageViewModel:BaseViewModel
    {
        
        private List<Movie> _MovieList { get; set; }
        public List<Movie> MovieList 
        {
            get
            {
                return _MovieList;

            }
            set
            {
                _MovieList = value;
                OnPropertyChanged();
            }
        }

        private WatchLaterMovies _WatchMovie;
        public WatchLaterMovies WatchMovie 
        {
            get
            {
                return _WatchMovie;

            }
            set
            {
                _WatchMovie = value;
                OnPropertyChanged();
            }
        }
        

        public MainPageViewModel()
        {
            LoadMovies();
            
            
        }

        private async Task LoadMovies()
        {
            WatchMovie = new WatchLaterMovies();
            var service = new Service();
            MovieList = await service.GetPopularMovies();
        }

      
        public Command<Movie> Watch
{
            get
            {
                return new Command<Movie>(async(Movie SelectedMovie) =>
                {
                   
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        // conn.CreateTable<Movie>();
                        WatchMovie.Id = SelectedMovie.Id;
                        WatchMovie.Title = SelectedMovie.Title;
                        WatchMovie.Overview = SelectedMovie.Overview;
                        WatchMovie.Poster_path = SelectedMovie.Poster_path;

                        conn.CreateTable<WatchLaterMovies>();
                        int rows = conn.Insert(WatchMovie);
                        conn.Close();
                        if (rows > 0)
                        {
                            CrossLocalNotifications.Current.Show("Movie", "The" + SelectedMovie.Title + "is added into your Watch later Movies", 101, DateTime.Now.AddSeconds(5));
                            Application.Current.MainPage.DisplayAlert("Success", " Inserted", "OK");
                        }
                        else
                        {
                            Application.Current.MainPage.DisplayAlert("Warning", " Not Inserted", "OK");
                        }
                    }
                });
            }
        }

        public Command<Movie> AddCommunityWatch
        {
            get
            {
                return new Command<Movie>(async (Movie SelectedMovie) =>
                {

                    HttpClient client;
                    client = new HttpClient();
                    // conn.CreateTable<Movie>();

                    Console.WriteLine("Add to community");
                    
                    Console.WriteLine(SelectedMovie.Title);
                    Console.WriteLine(SelectedMovie.Overview.Replace("'", "’"));
                    Console.WriteLine(SelectedMovie.Vote_average);
                    Console.WriteLine(SelectedMovie.Poster_path);

                    var myData = new
                    {
                        Title = SelectedMovie.Title.Replace("'", "’"),
                        Overview = SelectedMovie.Overview.Replace("'", "’"),
                        Vote_average = SelectedMovie.Vote_average,
                        Poster_path = SelectedMovie.Poster_path
                    };

                   
                    var uri = new Uri("https://restapiwithazurefunctioncdv.azurewebsites.net/api/film");
                    client.DefaultRequestHeaders.Add("x-functions-key", "J/giR03OQbJPa/A6wJLb5iFWvEkOKUGvhFfzE1ansa8urAPqZEBQeQ==");
                    string json = JsonConvert.SerializeObject(myData);
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                   
                    Console.WriteLine("httpContent");
                    Console.WriteLine(httpContent);
                    var response = await client.PostAsync(uri, httpContent);
                    Console.WriteLine("Response");
                    Console.WriteLine(response);
                    Console.WriteLine("JSON Test");
                    Console.WriteLine(json);
                    CrossLocalNotifications.Current.Show("Movie", "The" + SelectedMovie.Title + "is added into communityr Movies", 101, DateTime.Now.AddSeconds(5));
                    Application.Current.MainPage.DisplayAlert("Success", " Inserted", "OK");

                        
                    
                });
            }
        }

    }
}
