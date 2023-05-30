using MediatR;
using Newtonsoft.Json;
using ThingMan.Domain;
using ThingMan.Domain.Dtos;

namespace ThingMan.App.Commands;

public class CreateThingDefCommand : IRequest<ThingDef>
{
    [JsonIgnore]
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
}