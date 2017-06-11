using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
                            //this.Progresso.IsIndeterminate = !(this.Progresso.IsIndeterminate);
                            //this.Progresso.Visibility = Visibility.Collapsed;
                        }).AsTask().Wait();
                    }
                },
            request);
        }
    }
}
