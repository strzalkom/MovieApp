using Plugin.LocalNotifications;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieApp.ViewModels
{
   
    public class AddPageViewModel:BaseViewModel
    {
        private ImageSource _imageSource { get; set; }
        public ImageSource imageSource
        {
            get
            {
                return _imageSource;

            }
            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }
        public Movie movie { get; set; }
        public ICommand takePhoto { get; }
        public ICommand pickPhoto { get; }
        public AddPageViewModel()
        {
           
            movie = new Movie();
            takePhoto = new Command(async () => await takePhotoFromCam());

            pickPhoto = new Command(async () => await PickPhotoFromStorage());
        }
        async Task PickPhotoFromStorage()
        {
            MediaFile photo;

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
            });


            if (file == null)
                return;
            if (file != null)
            {
                try
                {

                    ImageSource image = ImageSource.FromStream(() =>
                    {
                        var a = file.GetStream();
                        return a;
                    });

                    imageSource = image;

                    movie.Poster_path = file.Path;




                }
                catch (Exception ex)
                {
                    
                }
               
            }


        }
        async Task takePhotoFromCam()
        {

            try
            {
                
                // 1. Add camera logic.
                await CrossMedia.Current.Initialize();

                MediaFile photo;
                if (CrossMedia.Current.IsCameraAvailable)
                {
                    photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {

                        Directory = "Sample",
                        Name = "test.jpg"
                    });
                    movie.Poster_path = photo.Path;
                    imageSource = ImageSource.FromFile(photo.Path);
                }
                else
                {
                    photo = await CrossMedia.Current.PickPhotoAsync();
                    movie.Poster_path = photo.Path;
                    imageSource =ImageSource.FromFile(photo.Path);
                }

                if (photo == null)
                {
                   await Application.Current.MainPage.DisplayAlert("", "Photo was null", "Okay");
                   
                    return;
                }


             
            }
            catch (Exception ex)
            {
                await (Application.Current?.MainPage?.DisplayAlert("Error",
                    $"Something bad happened: {ex.Message}", "OK") ??
                    Task.FromResult(true));

               

            }
            

        }


        public Command AddMovieCmd
        {
            get
            {
                return new Command(() =>
                {
                  if(String.IsNullOrEmpty(movie.Title)&& String.IsNullOrEmpty(movie.Overview)&& String.IsNullOrEmpty(movie.Poster_path))
                    {
                        Application.Current.MainPage.DisplayAlert("Error", "Please fill the all details", "OK");
                    }
                   
                    else
                    {
                                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                                {
                                    conn.CreateTable<Movie>();
                                    int rows = conn.Insert(movie);
                                    conn.Close();
                                    if (rows > 0)
                                    {
                                        CrossLocalNotifications.Current.Show("Movie", "The" + movie.Title + "is added into your favorite Movies", 101, DateTime.Now.AddSeconds(5));
                                        Application.Current.MainPage.DisplayAlert("Success", " Inserted", "OK");
                                    }
                                    else
                                    {
                                        Application.Current.MainPage.DisplayAlert("Warning", " Not Inserted", "OK");
                                    }
                                }
                                
                    }

                });
            }
        }
        public Command ShowCmd
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage.Navigation.PushModalAsync(new MovieList());

                });
            }
        }

    }
}
