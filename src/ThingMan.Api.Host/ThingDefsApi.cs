using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThingMan.Appl.Aggregates.Commands;
using ThingMan.Domain.Aggregates.ThingDefs.Dtos;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ThingMan.Appl;

public static class ThingDefsApi
{
    public static IEndpointConventionBuilder MapThingDefsApi(this IEndpointRouteBuilder endpoints)
    {
        var retval = endpoints
            .MapGroup("/thing-defs")
            .RequireAuthorization();

        retval.MapPost("/create", async (
                CreateThingDefCommand command,
                IMediator mediator,
                IMapper mapper,
                ClaimsPrincipal claimsPrincipal
            ) =>
            {
                var identity = (ClaimsIdentity)claimsPrincipal.Identity!;
                command.UserId = identity.Claims.Single(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

                var result = await mediator.Send(command);
                var dto = mapper.Map<ThingDefDto>(result);

                return Results.Created($"/thing-defs/{dto.Id}", dto);
            })
            .Produces(Status401Unauthorized)
            .Produces<ThingDefDto>(Status201Created)
            .Produces<ProblemDetails>(Status500InternalServerError)
            .WithTags("ThingDefs");

        return retval;
    }
}