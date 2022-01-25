using MovieApp.Models;
using Plugin.LocalNotifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
    }
}
