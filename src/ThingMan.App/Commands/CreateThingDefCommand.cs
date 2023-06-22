using MediatR;
using ThingMan.Core;

namespace ThingMan.App.Commands;

public class CreateThingDefCommand<TKey> : IRequest<IThingDef<TKey>>
{
    public string? UserId { get; set; }

    public IThingDef<TKey> ThingDef { get; set; } = null!;
}