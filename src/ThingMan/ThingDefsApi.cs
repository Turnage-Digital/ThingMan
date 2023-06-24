using System.Security.Claims;
using MediatR;
using ThingMan.App.Commands;
using ThingMan.Core.SqlDB.Views;
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
                ThingDefView thingDef,
                IMediator mediator,
                ClaimsPrincipal claimsPrincipal
            ) =>
            {
                var command = new CreateThingDefCommand { ThingDef = thingDef };
                var identity = (ClaimsIdentity)claimsPrincipal.Identity!;

                command.UserId = identity.Claims
                    .Single(claim => claim.Type == ClaimTypes.NameIdentifier)
                    .Value;

                var result = await mediator.Send(command);
                return Results.Created($"/thing-defs/{result.Id}", result);
            })
            .Produces(Status401Unauthorized)
            .Produces<ThingDefView>(Status201Created)
            .Produces(Status500InternalServerError);

        return retval;
    }
}