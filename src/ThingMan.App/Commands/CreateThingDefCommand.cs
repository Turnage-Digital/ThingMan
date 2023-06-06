using MediatR;
using ThingMan.Domain;
using ThingMan.Domain.Dtos;

namespace ThingMan.App.Commands;

public class CreateThingDefCommand : IRequest<ThingDef>
{
    public string? UserId { get; set; }

    public ThingDefDto ThingDef { get; set; } = null!;
}