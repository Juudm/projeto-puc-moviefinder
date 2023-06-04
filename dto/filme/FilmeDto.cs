using moviefinder.dto.genero;
using moviefinder.dto.recomendado;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace moviefinder.dto.filme;

public class FilmeDto
{
    public int Budget { get; set; }

    public List<GeneroDto> Genres { get; set; }

    public int Id { get; set; }

    [JsonProperty("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonProperty("original_title")]
    public string OriginalTitle { get; set; }

    public string Overview { get; set; }

    public double Popularity { get; set; }

    [JsonProperty("poster_path")]
    public string PosterPath { get; set; }

    [JsonProperty("backdrop_path")]
    public string BackdropPath { get; set; }

    [JsonProperty("release_date")]
    public string ReleaseDate { get; set; }
    
    public long Revenue { get; set; }
    public int Runtime { get; set; }

    [JsonProperty("spoken_languages")]
    public List<IdiomaFaladoDto> SpokenLanguages { get; set; }
    
    public string status { get; set; }
    public string Title { get; set; }

    [JsonProperty("vote_average")]
    public double VoteAverage { get; set; }

    [JsonProperty("vote_count")]
    public int VoteCount { get; set; }

    public FilmeCreditosDto Credits { get; set; }

    public RecomendadoDto Recommendations { get; set; }

    [JsonProperty("watch/providers")]
    public ProvedoresFilmeDto Providers { get; set; }

    public FilmeDto(int budget, List<GeneroDto> genres, int id, string originalLanguage, string backdropPath, string originalTitle,  string overview, double popularity, string posterPath, string releaseDate, long revenue, int runtime, List<IdiomaFaladoDto> spokenLanguages, string title, double voteAverage, int voteCount, FilmeCreditosDto credits, RecomendadoDto recommendations, ProvedoresFilmeDto providers)
    {
        Budget = budget;
        Genres = genres;
        Id = id;
        OriginalLanguage = originalLanguage;
        OriginalTitle = originalTitle;
        Overview = overview;
        Popularity = popularity;
        ReleaseDate = releaseDate;
        Revenue = revenue;
        Runtime = runtime;
        SpokenLanguages = spokenLanguages;
        Title = title;
        VoteAverage = voteAverage;
        VoteCount = voteCount;
        Credits = credits;
        Recommendations = recommendations;
        Providers = providers;
        PosterPath = posterPath;
        BackdropPath = backdropPath;
}
}
