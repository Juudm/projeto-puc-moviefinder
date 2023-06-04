using moviefinder.dto.provedor;
using Newtonsoft.Json;

namespace moviefinder.dto;

public class ProvedoresResultadoDto
{
    public ProvedorPaisDto? BR { get; set; }

    public ProvedoresResultadoDto(ProvedorPaisDto br)
    {
        BR = br;
    }
}