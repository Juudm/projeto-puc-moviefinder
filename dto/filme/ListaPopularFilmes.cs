using Newtonsoft.Json;

namespace moviefinder.dto.pessoa;

public class ListaPopularFilmes
{
        public int Page { get; set; }
        public List<PopularFilmeDto> Results { get; set; }
        
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

}