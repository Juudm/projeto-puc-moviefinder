using Newtonsoft.Json;

namespace moviefinder.dto.provedor;

public class ProvedorDto
{
    [JsonProperty("provider_name")]
    public string ProviderName { get; set; }

    [JsonProperty("provider_id")]
    public string ProviderId { get; set; }

    [JsonProperty("logo_path")]
    public string LogoPath { get; set; }

    public ProvedorDto(string providerName, string providerId, string logoPath)
    {
        ProviderName = providerName;
        ProviderId = providerId;
        LogoPath = logoPath;
    }
}