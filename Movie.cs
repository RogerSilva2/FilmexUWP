using System;

public class Movie
{
    private long id;
    private string original_title;
    private string title;
    private string poster_path;
    private string backdrop_path;
    private string overview;
    private string release_date;
    private string original_language;
    private List<int> genre_ids;
    private int vote_count;
    private double vote_average;
    private double popularity;
    private bool adult;
    private bool video;

	public Movie()
	{
	}

    public long id { get; set; }
    public string original_title { get; set; }
    public string title { get; set; }
    public string poster_path { get; set; }
    public string backdrop_path { get; set; }
    public string overview { get; set; }
    public string release_date { get; set; }
    public string original_language { get; set; }
    public List<int> genre_ids { get; set; }
    public int vote_count { get; set; }
    public double vote_average { get; set; }
    public double popularity { get; set; }
    public bool adult { get; set; }
    public bool video { get; set; }
}
