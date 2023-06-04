using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace moviefinder.dto;

public class CreditosEquipeDto
{
    public int Id { get; set; }
    
    [JsonProperty("known_for_department")]
    public string KnownForDepartment { get; set; }

    public string Name { get; set; }

    [JsonProperty("original_name")]
    public string OriginalName { get; set; }

    public double Popularity { get; set; }

    public string Department { get; set; }

    public string Job { get; set; }

    public CreditosEquipeDto(int id, string knownForDepartment, string name, string originalName, double popularity, string department, string job)
    {
        Id = id;
        KnownForDepartment = knownForDepartment;
        Name = name;
        OriginalName = originalName;
        Popularity = popularity;
        Department = department;
        Job = job;
    }
}