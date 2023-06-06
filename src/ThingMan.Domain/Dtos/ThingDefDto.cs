using Newtonsoft.Json;

namespace ThingMan.Domain.Dtos;

public record ThingDefDto
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;

    [JsonProperty("userId")]
    public string? UserId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("statusDefs")]
    public StatusDefDto[] StatusDefs { get; set; } = null!;

    [JsonProperty("notificationDefs")]
    public NotificationDefDto[] NotificationDefs { get; set; } = null!;

    [JsonProperty("propDef1")]
    public PropertyDefDto? PropertyDef1 { get; set; }

    [JsonProperty("propDef2")]
    public PropertyDefDto? PropertyDef2 { get; set; }

    [JsonProperty("propDef3")]
    public PropertyDefDto? PropertyDef3 { get; set; }

    [JsonProperty("propDef4")]
    public PropertyDefDto? PropertyDef4 { get; set; }

    [JsonProperty("propDef5")]
    public PropertyDefDto? PropertyDef5 { get; set; }
}