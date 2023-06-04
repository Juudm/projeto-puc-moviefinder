namespace moviefinder.dto.provedor;

public class ProvedoresDto
{
    public List<ProvedorDto> Results { get; set; }

    public ProvedoresDto(List<ProvedorDto> results)
    {
        Results = results;
    }
}