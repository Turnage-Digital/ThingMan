using Newtonsoft.Json;

namespace ThingMan.Core.SqlDB.Views;

public record ThingDefView : IReadOnlyThingDef
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("statusDefs")]
    public StatusDefView[] StatusDefs { get; set; } = null!;

    [JsonProperty("notificationDefs")]
    public NotificationDefView[] NotificationDefs { get; set; } = null!;

    [JsonProperty("propertyDef1")]
    public PropertyDefView? PropertyDef1 { get; set; }

    [JsonProperty("propertyDef2")]
    public PropertyDefView? PropertyDef2 { get; set; }

    [JsonProperty("propertyDef3")]
    public PropertyDefView? PropertyDef3 { get; set; }

    [JsonProperty("propertyDef4")]
    public PropertyDefView? PropertyDef4 { get; set; }

    [JsonProperty("propertyDef5")]
    public PropertyDefView? PropertyDef5 { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; } = null!;
}