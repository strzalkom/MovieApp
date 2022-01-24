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
        

        public MainPageViewModel()
        {
            LoadMovies();
            
            
        }

        private async Task LoadMovies()
        {
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
                        conn.CreateTable<Movie>();
                        int rows = conn.Insert(SelectedMovie);
                        conn.Close();
                        if (rows > 0)
                        {
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
