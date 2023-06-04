namespace moviefinder.dto;

public class ProvedoresFilmeDto
{
    public ProvedoresResultadoDto Results { get; set; }

    public ProvedoresFilmeDto(ProvedoresResultadoDto results)
    {
        Results = results;
    }
}