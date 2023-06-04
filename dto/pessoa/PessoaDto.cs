using Newtonsoft.Json;

namespace moviefinder.dto.pessoa;

public class PessoaDto
{
    [JsonProperty("also_known_as")]
    public List<string> AlsoKnownAs { get; set; }

    public string Biography { get; set; }

    public string Birthday { get; set; }

    public string Deathday { get; set; }

    public int Gender { get; set; }

    public int Id { get; set; }

    [JsonProperty("known_for_department")]
    public string KnownForDepartment { get; set; }

    public string Name { get; set; }

    [JsonProperty("place_of_birth")]
    public string PlaceOfBirth { get; set; }

    public double Popularity { get; set; }

    [JsonProperty("movie_credits")]
    public CreditosFilmeDto MovieCredits { get; set; }

    public PessoaDto(List<string> alsoKnownAs, string biography, string birthday, string deathday, int gender, int id, string knownForDepartment, string name, string placeOfBirth, double popularity, CreditosFilmeDto movieCredits)
    {
        AlsoKnownAs = alsoKnownAs;
        Biography = biography;
        Birthday = birthday;
        Deathday = deathday;
        Gender = gender;
        Id = id;
        KnownForDepartment = knownForDepartment;
        Name = name;
        PlaceOfBirth = placeOfBirth;
        Popularity = popularity;
        MovieCredits = movieCredits;
    }
}