using Newtonsoft.Json;

namespace ThingMan.Core.SqlDB.Views;

public record PropertyDefView
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("propertyType")]
    public string PropertyType { get; set; } = null!;
}