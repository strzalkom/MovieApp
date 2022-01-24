using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SQLite;

namespace MovieApp
{
    public partial class AddPage : ContentPage
    {
       // public MovieDB _moviedb;
        public Movie movie;
        public AddPage()
        {
            InitializeComponent();
        }
        public void AddMovie_Clicked(object sender, System.EventArgs e)
        {
            movie = new Movie()
            {
                Title = title.Text,
                Overview = overview.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Movie>();
                int rows = conn.Insert(movie);
                conn.Close();
                if (rows > 0)
                {
                    DisplayAlert("Success", " Inserted", "OK");
                }
                else
                {
                    DisplayAlert("Warning", " Not Inserted", "OK");
                }
            }
        }

        private void Show_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new MovieList());
        }
    }
}