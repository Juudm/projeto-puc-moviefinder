using Newtonsoft.Json;

namespace moviefinder.dto.pessoa;

public class ListaTopRatedFilmesDto
{
    public int Page { get; set; }
    public List<TopRatedFilmesDto> Results { get; set; }
    
    [JsonProperty("total_results")]
    public int TotalResults { get; set; }
    
    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }

}