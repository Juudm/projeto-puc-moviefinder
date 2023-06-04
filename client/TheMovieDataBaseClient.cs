namespace moviefinder.client;

public class TheMovieDataBaseClient
{
    private readonly HttpClient _httpClient;
    
    private readonly string _url;

    public TheMovieDataBaseClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _url = "https://api.themoviedb.org/3";
    }

    public async Task<string> FindMovieById(string movieId, string apiKey, string apiLanguage)
    {
        Console.WriteLine(_url + $"/movie/{movieId}?api_key={apiKey}&language={apiLanguage}&append_to_response=credits%2Crecommendations%2Cwatch%2Fproviders");
        return await _httpClient.GetStringAsync(_url + $"/movie/{movieId}?api_key={apiKey}&language={apiLanguage}&append_to_response=credits%2Crecommendations%2Cwatch%2Fproviders");
    }
    
    public async Task<string> FindMovieByQuery(string query, string apiKey, string apiLanguage)
    {
        return await _httpClient.GetStringAsync(_url + $"/search/movie?api_key={apiKey}&language={apiLanguage}&query={query}&page=1&include_adult=false");
    }

    public async Task<string> FindPersonById(string personId, string apiKey, string apiLanguage)
    {
        return await _httpClient.GetStringAsync(_url + $"/person/{personId}?api_key={apiKey}&language={apiLanguage}&append_to_response=movie_credits");
    }

    public async Task<string> ListPopularityMovies(string apiKey, string apiLanguage)
    {
        return await _httpClient.GetStringAsync(_url + $"/movie/popular?page=1&api_key={apiKey}&language={apiLanguage}");
    }

    public async Task<string> ListTopRatedMovies(string apiKey, string apiLanguage)
    {
        return await _httpClient.GetStringAsync(_url + $"/movie/top_rated?page=1&api_key={apiKey}&language={apiLanguage}");
    }

    public async Task<string> ListGenres(string apiKey, string apiLanguage)
    {
        return await _httpClient.GetStringAsync(_url + $"/genre/movie/list?api_key={apiKey}&language={apiLanguage}");
    }
    public async Task<string> DiscoverMovies(string apiKey, string apiLanguage, string genreId )
    {
        return await _httpClient.GetStringAsync(_url + $"/discover/movie?api_key={apiKey}&language={apiLanguage}&with_genres={genreId}");
    }

    public async Task<string> ListProviders(string apiKey, string apiLanguage)
    {
        return await _httpClient.GetStringAsync(_url + $"/watch/providers/movie?api_key={apiKey}&language={apiLanguage}&watch_region=BR");
    }

    public async Task<string> ListLanguages(string apiKey)
    {
        return await _httpClient.GetStringAsync(_url + $"/configuration/languages?api_key={apiKey}");
    }

    public async Task<string> ListRecommendationsByMovie(string movieId, string apiKey, string apiLanguage)
    {
        return await _httpClient.GetStringAsync(_url + $"/movie/{movieId}/recommendations?api_key={apiKey}&language={apiLanguage}&page=1");
    }
}