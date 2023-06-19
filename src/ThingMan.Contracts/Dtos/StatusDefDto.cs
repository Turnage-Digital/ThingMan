using Newtonsoft.Json;

namespace ThingMan.Contracts.Dtos;

public record StatusDefDto
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}