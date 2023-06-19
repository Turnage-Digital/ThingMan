using MediatR;
using Newtonsoft.Json;
using ThingMan.Core.Views;

namespace ThingMan.App.Queries;

public class GetThingDefByIdQuery : IRequest<ThingDefView>
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
}