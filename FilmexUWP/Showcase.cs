using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FilmexUWP
{
    [DataContract]
    public class Showcase
    {
        public Showcase()
        {
        }

        public Showcase(int page, List<Movie> results, int total_results, int total_pages)
        {
            this.Page = page;
            this.Results = results;
            this.Total_Results = total_results;
            this.Total_Pages = total_pages;
        }

        [DataMember(Name = "page")]
        public int Page { get; set; }

        [DataMember(Name = "results")]
        public List<Movie> Results { get; set; }

        [DataMember(Name = "total_results")]
        public int Total_Results { get; set; }

        [DataMember(Name = "total_pages")]
        public int Total_Pages { get; set; }
    }
}
