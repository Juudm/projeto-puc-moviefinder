using Newtonsoft.Json;

namespace moviefinder.dto.recomendado;

public class RecomendacoesFilmeDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonProperty("original_title")]
    public string OriginalTitle { get; set; }

    public string Overview { get; set; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }

    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }

    [JsonProperty("vote_count")]
    public int VoteCount { get; set; }

    [JsonProperty("poster_path")]
    public string? PosterPath { get; set; }

    public RecomendacoesFilmeDto(int id, string title, string originalLanguage, string originalTitle, string overview, string releaseDate, double voteAverage, int voteCount, string posterPath)
    {
        Id = id;
        Title = title;
        OriginalLanguage = originalLanguage;
        OriginalTitle = originalTitle;
        Overview = overview;
        ReleaseDate = releaseDate;
        VoteAverage = voteAverage;
        VoteCount = voteCount;
        PosterPath = posterPath;
    }
}