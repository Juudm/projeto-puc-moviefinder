using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace moviefinder.dto;

public class IdiomaFaladoDto
{
    [JsonProperty("iso_639_1")]
    public string Iso6391 { get; set; }
    
    public string Name { get; set; }

    public IdiomaFaladoDto(string iso6391, string name)
    {
        Iso6391 = iso6391;
        Name = name;
    }
}