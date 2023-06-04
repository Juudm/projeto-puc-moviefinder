using Newtonsoft.Json;

namespace moviefinder.dto.pessoa;

public class PessoaCreditosDto
{
    public int Id { get; set; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonProperty("original_title")]
    public string OriginalTitle { get; set; }

    public string Overview { get; set; }

    public double Popularity { get; set; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }

    public string Title { get; set; }

    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }

    [JsonProperty("vote_count")]
    public int VoteCount { get; set; }

    public string Character { get; set; }

    public PessoaCreditosDto(int id, string originalLanguage, string originalTitle, string overview, double popularity, string releaseDate, string title, double voteAverage, int voteCount, string character)
    {
        Id = id;
        OriginalLanguage = originalLanguage;
        OriginalTitle = originalTitle;
        Overview = overview;
        Popularity = popularity;
        ReleaseDate = releaseDate;
        Title = title;
        VoteAverage = voteAverage;
        VoteCount = voteCount;
        Character = character;
    }
}