using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace FilmexUWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Movie> Movies = new List<Movie>();
        private List<Movie> FavoriteMovies = new List<Movie>();

        public MainPage()
        {
            this.InitializeComponent();
            LoadMovies();
        }

        public void LoadMovies()
        {
            string url = "https://api.themoviedb.org/3/discover/movie?sort_by=popularity.desc&api_key=6915e6c062c55c7960722e080386e39c&language=pt-BR";
            Uri uri = new Uri(url, UriKind.Absolute);
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.Accept = "application/json";
            request.BeginGetResponse((result) =>
                {
                    var req = (HttpWebRequest)result.AsyncState;
                    var response = req.EndGetResponse(result);
                    var stream = response.GetResponseStream();
                    if (stream != null)
                    {
                        var serializer = new DataContractJsonSerializer(typeof(Showcase));
                        var data = (Showcase)serializer.ReadObject(stream);
                        Movies.Clear();
                        foreach (Movie movie in data.Results)
                        {
                            Movies.Add(movie);
                        }

                        this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            this.DataContext = Movies;
                        }).AsTask().Wait();
                    }
                },
            request);
        }

        private SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        }

        private void Favoritar_Click(object sender, RoutedEventArgs e)
        {
            bool favorited = true;
            Button button = sender as Button;
            foreach (Movie movie in FavoriteMovies)
            {
                if (movie.Id == button.DataContext as long?)
                {
                    FavoriteMovies.Remove(movie);
                    button.Content = "Favoritar";
                    button.Background = GetSolidColorBrush("#FFFFC107");
                    favorited = false;
                    break;
                }
            }

            if (favorited)
            {
                foreach (Movie movie in Movies)
                {
                    if (movie.Id == button.DataContext as long?)
                    {
                        FavoriteMovies.Add(movie);
                        button.Content = "Favoritado";
                        button.Background = GetSolidColorBrush("#FF795548");
                        break;
                    }
                }
            }
        }
    }

    public class DateFormatter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            string formatString = parameter as string;
            if (!string.IsNullOrEmpty(formatString))
            {
                return string.Format(
                    new CultureInfo(language), formatString, value);
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
