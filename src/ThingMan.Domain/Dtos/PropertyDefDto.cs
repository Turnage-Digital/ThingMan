using Newtonsoft.Json;

namespace ThingMan.Domain.Dtos;

public record PropertyDefDto
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("propertyType")]
    public string PropertyType { get; set; } = null!;
}