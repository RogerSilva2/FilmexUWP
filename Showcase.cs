using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmexUWP
{
    public class Showcase
    {
        private int page;
        private List<Movie> results;
        private int total_results;
        private int total_pages;

        public Showcase()
        {
        }

        public int Page { get; set; }
        public List<Movie> Results { get; set; }
        public int Total_Results { get; set; }
        public int Total_Pages { get; set; }
    }
}