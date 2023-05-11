using Newtonsoft.Json;

namespace ThingMan.Domain.Aggregates.ThingDefs.Dtos;

public record ThingDefDto
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("propDef1")]
    public PropDefDto? PropDef1 { get; set; }

    [JsonProperty("propDef2")]
    public PropDefDto? PropDef2 { get; set; }

    [JsonProperty("propDef3")]
    public PropDefDto? PropDef3 { get; set; }
}