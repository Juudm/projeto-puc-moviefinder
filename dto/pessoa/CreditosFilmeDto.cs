namespace moviefinder.dto.pessoa;

public class CreditosFilmeDto
{
    public List<PessoaCreditosDto> Cast { get; set; }

    public CreditosFilmeDto(List<PessoaCreditosDto> cast)
    {
        Cast = cast;
    }
}