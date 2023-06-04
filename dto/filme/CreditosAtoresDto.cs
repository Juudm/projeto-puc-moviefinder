using Newtonsoft.Json;

namespace moviefinder.dto.filme;

public class CreditosAtoresDto
{
    public int Id { get; set; }
    
    [JsonProperty("known_for_department")]
    public string KnownForDepartment { get; set; }

    public string Name { get; set; }

    [JsonProperty("original_name")]
    public string OriginalName { get; set; }

    public double Popularity { get; set; }
    
    [JsonProperty("profile_path")]
    public string? ProfilePath { get; set; } 

    public CreditosAtoresDto(int id, string knownForDepartment, string name, string originalName, string profilePath, double popularity)
    {
        Id = id;
        KnownForDepartment = knownForDepartment;
        Name = name;
        OriginalName = originalName;
        ProfilePath = profilePath;
        Popularity = popularity;
    }
}