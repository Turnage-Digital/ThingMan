using MediatR;
using ThingMan.Contracts.Dtos;

namespace ThingMan.App.Commands;

public class CreateThingDefCommand : IRequest<ThingDefDto>
{
    public string? UserId { get; set; }

    public ThingDefDto ThingDef { get; set; } = null!;
}