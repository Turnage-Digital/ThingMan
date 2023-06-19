using Newtonsoft.Json;

namespace ThingMan.Core.Views;

public record StatusDefView
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}