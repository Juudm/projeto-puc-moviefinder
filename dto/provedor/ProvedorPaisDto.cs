namespace moviefinder.dto.provedor;

public class ProvedorPaisDto
{
    public List<ProvedorDto> Flatrate { get; set; }

    public ProvedorPaisDto(List<ProvedorDto> flatrate)
    {
        Flatrate = flatrate;
    }
}