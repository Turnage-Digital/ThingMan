using MediatR;
using ThingMan.Core;

namespace ThingMan.App.Commands;

public class CreateThingDefCommand : IRequest<IReadOnlyThingDef>
{
    public string? UserId { get; set; }

    public IReadOnlyThingDef ThingDef { get; set; } = null!;
}