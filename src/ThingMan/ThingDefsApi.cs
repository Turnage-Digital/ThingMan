using System.Security.Claims;
using AutoMapper;
using MediatR;
using ThingMan.App.Commands;
using ThingMan.Contracts.Dtos;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ThingMan;

public static class ThingDefsApi
{
    public static IEndpointConventionBuilder MapThingDefsApi(this IEndpointRouteBuilder endpoints)
    {
        var retval = endpoints
            .MapGroup("/api/thing-defs")
            .RequireAuthorization();

        retval.MapPost("/create", async (
                ThingDefDto thingDef,
                IMediator mediator,
                IMapper mapper,
                ClaimsPrincipal claimsPrincipal
            ) =>
            {
                var command = new CreateThingDefCommand { ThingDef = thingDef };
                var identity = (ClaimsIdentity)claimsPrincipal.Identity!;

                command.UserId = identity.Claims
                    .Single(claim => claim.Type == ClaimTypes.NameIdentifier)
                    .Value;

                var result = await mediator.Send(command);
                var dto = mapper.Map<ThingDefDto>(result);

                return Results.Created($"/thing-defs/{dto.Id}", dto);
            })
            .Produces(Status401Unauthorized)
            .Produces<ThingDefDto>(Status201Created)
            .Produces(Status500InternalServerError);

        return retval;
    }
}