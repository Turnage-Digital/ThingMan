using Newtonsoft.Json;

namespace ThingMan.Domain.Dtos;

public record PropDefDto
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("propType")]
    public string PropType { get; set; } = null!;
}