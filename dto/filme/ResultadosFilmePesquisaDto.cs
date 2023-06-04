namespace moviefinder.dto;

public class ResultadosFilmePesquisaDto
{
    public List<FilmePesquisaDto> Results { get; set; }

    public ResultadosFilmePesquisaDto(List<FilmePesquisaDto> results)
    {
        Results = results;
    }
}
