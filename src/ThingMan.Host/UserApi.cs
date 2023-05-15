using System.Security.Claims;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ThingMan.Host;

public static class UserApi
{
    public static IEndpointConventionBuilder MapUserApi(this IEndpointRouteBuilder endpoints)
    {
        var retval = endpoints
            .MapGroup("/user")
            .RequireAuthorization();

        retval.MapGet("/claims", (ClaimsPrincipal claimsPrincipal) =>
            {
                var claims = claimsPrincipal.Claims
                    .Select(x => new Claim(x.Type, x.Value));
                return Results.Json(claims);
            })
            .Produces(Status401Unauthorized)
            .Produces<Claim[]>()
            .WithTags("User");

        return retval;
    }

    private record Claim(string Type, object Value);
}