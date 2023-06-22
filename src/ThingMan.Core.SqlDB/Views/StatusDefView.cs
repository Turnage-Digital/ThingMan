using Newtonsoft.Json;

namespace ThingMan.Core.SqlDB.Views;

public record StatusDefView
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}