using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace MovieApp
{
	public partial class MainPage : ContentPage
	{
		
		public Movie movie;
		
		public MainPage()
		{
			InitializeComponent();
			BindingContext=new MainPageViewModel();
			


		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			

		}

		void OnMovieSelected(object sender, EventArgs args)
		{
			var list = (ListView)sender;
			var selected = list.SelectedItem as Movie;

			list.SelectedItem = null;

			Debug.WriteLine(selected.Title);

			var detailPage = new DetailPage();

			detailPage.BindingContext = selected;

			Navigation.PushModalAsync(detailPage);

		}

       
	

	}
}
