using MediatR;
using Newtonsoft.Json;
using ThingMan.Contracts.Dtos;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQuery : IRequest<ThingDefDto>
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
}