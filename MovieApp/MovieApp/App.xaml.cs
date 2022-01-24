using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
namespace MovieApp
{
	public partial class App : Application
	{
		public static string DatabaseLocation = string.Empty;
		public App()
		{

			InitializeComponent();

			MainPage = new TabLayout();

			
		}
		public App(string databaseLocation)
		{

			InitializeComponent();

			MainPage = new TabLayout();

			DatabaseLocation = databaseLocation;
		}

		protected override void OnStart()
		{

		}

		protected override void OnSleep()
		{

		}

		protected override void OnResume()
		{
		
		}
	}
}