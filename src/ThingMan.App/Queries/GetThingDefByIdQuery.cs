using MediatR;
using Newtonsoft.Json;
using ThingMan.Core;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQuery : IRequest<IReadOnlyThingDef>
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
}