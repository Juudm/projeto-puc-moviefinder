using Newtonsoft.Json;

namespace moviefinder.dto;

public class FilmePesquisaDto
{
    [JsonProperty("genre_ids")]
    public List<int> Genre_ids { get; set; }

    public int Id { get; set; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonProperty("original_title")]
    public string OriginalTitle { get; set; }

    public string Overview { get; set; }

    public double Popularity { get; set; }
    
    [JsonProperty("poster_path")]
    public string PosterPath { get; set; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }

    public string Title { get; set; }

    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }

    [JsonProperty("vote_count")]
    public int VoteCount { get; set; }

    public FilmePesquisaDto(List<int> genreIds, int id, string originalLanguage, string originalTitle, string overview, double popularity, string posterPath, string releaseDate, string title, double voteAverage, int voteCount)
    {
        Genre_ids = genreIds;
        Id = id;
        OriginalLanguage = originalLanguage;
        OriginalTitle = originalTitle;
        Overview = overview;
        Popularity = popularity;
        PosterPath = posterPath;
        ReleaseDate = releaseDate;
        Title = title;
        VoteAverage = voteAverage;
        VoteCount = voteCount;
    }
}
