using MediatR;
using Newtonsoft.Json;
using ThingMan.Core;

namespace ThingMan.Application.Queries;

public class GetThingDefByIdQuery<TThingDef> : IRequest<TThingDef>
    where TThingDef : IReadOnlyThingDef
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
}