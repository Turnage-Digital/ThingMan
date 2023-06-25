using MediatR;
using Newtonsoft.Json;
using ThingMan.Core;
using ThingMan.Core.ValueObjects;

namespace ThingMan.App.Commands;

public class CreateThingDefCommand : IRequest<IReadOnlyThingDef>
{
    [JsonIgnore]
    public string UserId { get; set; } = null!;

    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("statusDefs")]
    public StatusDef[] StatusDefs { get; set; } = null!;

    [JsonProperty("propertyDef1")]
    public PropertyDef? PropertyDef1 { get; set; }

    [JsonProperty("propertyDef2")]
    public PropertyDef? PropertyDef2 { get; set; }

    [JsonProperty("propertyDef3")]
    public PropertyDef? PropertyDef3 { get; set; }

    [JsonProperty("propertyDef4")]
    public PropertyDef? PropertyDef4 { get; set; }

    [JsonProperty("propertyDef5")]
    public PropertyDef? PropertyDef5 { get; set; }
}