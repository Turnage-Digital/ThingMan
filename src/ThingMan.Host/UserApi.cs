using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ThingMan.Host;

public static class UserApi
{
    public static IEndpointConventionBuilder MapUserApi(this IEndpointRouteBuilder endpoints)
    {
        var retval = endpoints
            .MapGroup("/user");

        retval.MapPost("/sign-in", async (
                SignInInput input,
                SignInManager<IdentityUser> signInManager
            ) =>
            {
                var result = await signInManager.PasswordSignInAsync(input.Username, input.Password,
                    true, false);
                return Results.Json(new SignInResultDto { Succeeded = result.Succeeded });
            })
            .Produces<SignInResultDto>()
            .WithTags("User");

        retval.MapGet("/claims", (
                ClaimsPrincipal claimsPrincipal
            ) =>
            {
                var claims = claimsPrincipal.Claims
                    .Select(x => new ClaimDto { Type = x.Type, Value = x.Value });
                return Results.Json(claims);
            })
            .RequireAuthorization()
            .Produces(Status401Unauthorized)
            .Produces<ClaimDto[]>()
            .WithTags("User");

        return retval;
    }

    public record SignInInput
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public record SignInResultDto
    {
        public bool Succeeded { get; set; }
    }

    public record ClaimDto
    {
        public string Type { get; set; } = null!;
        public object Value { get; set; } = null!;
    }
}