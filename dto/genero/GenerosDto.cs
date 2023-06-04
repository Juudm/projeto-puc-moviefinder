namespace moviefinder.dto.genero;

public class GenerosDto
{
    public List<GeneroDto> Genres { get; set; }

    public GenerosDto(List<GeneroDto> genres)
    {
        Genres = genres;
    }
}