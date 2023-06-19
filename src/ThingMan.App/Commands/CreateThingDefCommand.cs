using MediatR;
using ThingMan.Core.Views;

namespace ThingMan.App.Commands;

public class CreateThingDefCommand : IRequest<ThingDefView>
{
    public string? UserId { get; set; }

    public ThingDefView ThingDef { get; set; } = null!;
}