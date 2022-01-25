using MovieApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MovieApp.ViewModels
{
    public class MovieListViewModel : BaseViewModel
    {
       
        public MovieListModel movieList { get; set; }
       
        private ObservableCollection<MovieListModel> _MovieList { get; set; }
        public ObservableCollection<MovieListModel> MovieList
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
        public MovieListViewModel()
        {
            
          
            MovieList = new ObservableCollection<MovieListModel>();
            Getdata();

        }

        private void Getdata()
        {
               
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Movie>();
                conn.CreateTable<WatchLaterMovies>();
                var movielst = conn.Table<Movie>().ToList();
                foreach (Movie movie in movielst)
                {
                    movieList = new MovieListModel(movie.Title, movie.Overview);
                    movieList.Title = movie.Title;
                    movieList.Id = movie.Id;
                    movieList.Overview = movie.Overview;

                    movieList.Poster_path = ImageSource.FromFile(movie.Poster_path);





                    MovieList.Add(movieList);




                }
                var moviesLst = conn.Table<WatchLaterMovies>().ToList();
                foreach (WatchLaterMovies movie1 in moviesLst)
                {
                    movieList = new MovieListModel(movie1.Title, movie1.Overview);
                    movieList.Title = movie1.Title;
                    movieList.Id = movie1.Id;
                    movieList.Overview = movie1.Overview;
                    movieList.Poster_path = "https://image.tmdb.org/t/p/w500/"+movie1.Poster_path;
                    MovieList.Add(movieList);


                }
            }

        
    }
    }

}
