using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Models;
using MovieApp.ViewModels;
using SQLite;
using System.Diagnostics;

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


        protected override async void OnAppearing()
        {
            base.OnAppearing();



        }
        void OnMovieSelected2(object sender, EventArgs args)
        {
            var list = (ListView)sender;
            var selected = list.SelectedItem as MovieListModel;

            list.SelectedItem = null;

            Debug.WriteLine(selected.Title);

            var detailPage = new DetailPage();

            detailPage.BindingContext = selected;

            Navigation.PushModalAsync(detailPage);

        }


    }
}