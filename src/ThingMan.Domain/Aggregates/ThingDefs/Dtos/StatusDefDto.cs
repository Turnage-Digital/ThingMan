using Newtonsoft.Json;

namespace ThingMan.Domain.Aggregates.ThingDefs.Dtos;

public record StatusDefDto
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}