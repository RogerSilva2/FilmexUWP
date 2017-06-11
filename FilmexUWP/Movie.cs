using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FilmexUWP
{
    [DataContract]
    public class Movie
    {
        private string poster_path;

        public Movie()
        {
        }

        public Movie(long id, string original_title, string title,
            string poster_path, string backdrop_path, string overview,
            string release_date, string original_language, List<int> genre_ids,
            int vote_count, double vote_average, double popularity,
            bool adult, bool video)
        {
            this.Id = id;
            this.Original_Title = original_title;
            this.Title = title;
            this.Poster_Path = poster_path;
            this.Backdrop_Path = backdrop_path;
            this.Overview = overview;
            this.Release_Date = release_date;
            this.Original_Language = original_language;
            this.Genre_Ids = genre_ids;
            this.Vote_Count = vote_count;
            this.Vote_Average = vote_average;
            this.Popularity = popularity;
            this.Adult = adult;
            this.Video = video;
        }

        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "original_title")]
        public string Original_Title { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "poster_path")]
        public string Poster_Path
        {
            get
            {
                return "http://image.tmdb.org/t/p/w500" + this.poster_path;
            }
            set
            {
                this.poster_path = value;
            }
        }

        [DataMember(Name = "backdrop_path")]
        public string Backdrop_Path { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        [DataMember(Name = "release_date")]
        public string Release_Date { get; set; }

        [DataMember(Name = "original_language")]
        public string Original_Language { get; set; }

        [DataMember(Name = "genre_ids")]
        public List<int> Genre_Ids { get; set; }

        [DataMember(Name = "vote_count")]
        public int Vote_Count { get; set; }

        [DataMember(Name = "vote_average")]
        public double Vote_Average { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }

        [DataMember(Name = "adult")]
        public bool Adult { get; set; }

        [DataMember(Name = "video")]
        public bool Video { get; set; }
    }
}