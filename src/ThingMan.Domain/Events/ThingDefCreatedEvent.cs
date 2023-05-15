using MediatR;
using Newtonsoft.Json;

namespace ThingMan.Domain.Events;

public class ThingDefCreatedEvent : INotification
{
    [JsonProperty("thingDef")]
    public ThingDef ThingDef { get; set; } = null!;
}