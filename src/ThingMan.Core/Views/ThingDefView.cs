using Newtonsoft.Json;

namespace ThingMan.Core.Views;

public record ThingDefView
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("statusDefs")]
    public StatusDefView[] StatusDefs { get; set; } = null!;

    [JsonProperty("notificationDefs")]
    public NotificationDefView[] NotificationDefs { get; set; } = null!;

    [JsonProperty("propDef1")]
    public PropertyDefView? PropertyDef1 { get; set; }

    [JsonProperty("propDef2")]
    public PropertyDefView? PropertyDef2 { get; set; }

    [JsonProperty("propDef3")]
    public PropertyDefView? PropertyDef3 { get; set; }

    [JsonProperty("propDef4")]
    public PropertyDefView? PropertyDef4 { get; set; }

    [JsonProperty("propDef5")]
    public PropertyDefView? PropertyDef5 { get; set; }
}