using Newtonsoft.Json;

namespace ThingMan.Core.ValueObjects;

public record PropertyDef
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("propertyType")]
    public string PropertyType { get; set; } = null!;
}