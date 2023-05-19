using MediatR;
using Newtonsoft.Json;
using ThingMan.Domain.Dtos;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQuery : IRequest<ThingDefDto>
{
    [JsonProperty("id")]
    public string Id { get; set; } = null!;
}