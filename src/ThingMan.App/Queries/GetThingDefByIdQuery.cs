using MediatR;
using Newtonsoft.Json;
using ThingMan.Core;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQuery<TKey> : IRequest<IThingDef<TKey>>
{
    [JsonProperty("id")]
    public TKey Id { get; set; } = default!;
}