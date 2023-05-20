using Newtonsoft.Json;

namespace ThingMan.Domain.Dtos;

public record ThingDefDto
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("propertyDef1")]
    public PropertyDefDto? PropertyDef1 { get; set; }

    [JsonProperty("propertyDef2")]
    public PropertyDefDto? PropertyDef2 { get; set; }

    [JsonProperty("propertyDef3")]
    public PropertyDefDto? PropertyDef3 { get; set; }
}