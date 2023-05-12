using MediatR;
using Newtonsoft.Json;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;

namespace ThingMan.Appl.Aggregates.Queries;

public class GetThingDefByIdQuery : IRequest<ThingDefDto>
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
}