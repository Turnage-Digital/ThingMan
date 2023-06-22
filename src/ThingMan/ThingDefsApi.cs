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
                ThingDefView<Guid> thingDef,
                IMediator mediator,
                ClaimsPrincipal claimsPrincipal
            ) =>
            {
                var command = new CreateThingDefCommand<Guid> { ThingDef = thingDef };
                var identity = (ClaimsIdentity)claimsPrincipal.Identity!;

                command.UserId = identity.Claims
                    .Single(claim => claim.Type == ClaimTypes.NameIdentifier)
                    .Value;

                var result = await mediator.Send(command);
                return Results.Created($"/thing-defs/{result.Id}", result);
            })
            .Produces(Status401Unauthorized)
            .Produces<ThingDefView<Guid>>(Status201Created)
            .Produces(Status500InternalServerError);

        return retval;
    }
}