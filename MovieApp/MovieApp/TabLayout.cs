using System;
using Xamarin.Forms;

namespace MovieApp
{
    public class TabLayout : TabbedPage
    {
        public TabLayout()
        {
            Children.Add(new About() { Title = "About the author", IconImageSource = "about" });
			Children.Add(new AddPage() { Title = "Add Movie", IconImageSource = "add" });
            Children.Add(new MainPage() { Title = "Find Movies", IconImageSource = "find" });
           
        }
    }
}