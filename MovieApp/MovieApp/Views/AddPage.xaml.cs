using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SQLite;
using Plugin.LocalNotifications;
using MovieApp.ViewModels;

namespace MovieApp
{
    public partial class AddPage : ContentPage
    {
      
        public AddPage()
        {
            InitializeComponent();
            BindingContext = new AddPageViewModel();
        }
        
    }
}