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

    [JsonProperty("propDef1")]
    public PropDefDto? PropDef1 { get; set; }

    [JsonProperty("propDef2")]
    public PropDefDto? PropDef2 { get; set; }

    [JsonProperty("propDef3")]
    public PropDefDto? PropDef3 { get; set; }
}