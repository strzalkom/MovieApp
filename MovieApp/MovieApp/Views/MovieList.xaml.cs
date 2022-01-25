using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Models;
using MovieApp.ViewModels;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieList : ContentPage
    {

        public MovieList()
        {
            InitializeComponent();
            BindingContext = new MovieListViewModel();



        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
        //    {
               
        //        var posted = conn.Table<WatchLaterMovies>().ToList();
        //        MovieListView.ItemsSource = posted;
                
        //    }
        
        //}

    }
}