using Newtonsoft.Json;

namespace ThingMan.Core.ValueObjects;

public record StatusDef
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}