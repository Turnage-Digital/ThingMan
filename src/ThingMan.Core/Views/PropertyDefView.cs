using Newtonsoft.Json;

namespace ThingMan.Core.Views;

public record PropertyDefView
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("propertyType")]
    public string PropertyType { get; set; } = null!;
}