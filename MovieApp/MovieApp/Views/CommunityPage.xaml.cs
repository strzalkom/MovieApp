using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace MovieApp
{
	public partial class CommunityPage : ContentPage
	{
		
		public Movie movie;
		
		public CommunityPage()
		{
			InitializeComponent();
			BindingContext=new CommunityPageViewModel();
			


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
