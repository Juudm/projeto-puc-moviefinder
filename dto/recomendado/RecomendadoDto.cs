namespace moviefinder.dto.recomendado;

public class RecomendadoDto
{
    public List<RecomendacoesFilmeDto> Results { get; set; }

    public RecomendadoDto(List<RecomendacoesFilmeDto> results)
    {
        Results = results;
    }
}