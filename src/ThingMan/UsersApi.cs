using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ThingMan;

public static class UsersApi
{
    public static IEndpointConventionBuilder MapUserApi(this IEndpointRouteBuilder endpoints)
    {
        var retval = endpoints
            .MapGroup("/api/users")
            .WithTags("Users");

        retval.MapPost("/sign-in", async (SignInInput input, SignInManager<IdentityUser> signInManager) =>
            {
                var result = await signInManager.PasswordSignInAsync(input.Username, input.Password,
                    true, false);
                return Results.Json(new SignInResultDto { Succeeded = result.Succeeded });
            })
            .Produces<SignInResultDto>();

        retval.MapGet("/claims", (ClaimsPrincipal claimsPrincipal) =>
            {
                var claims = claimsPrincipal.Claims
                    .Select(x => new ClaimDto { Type = x.Type, Value = x.Value });
                return Results.Json(claims);
            })
            .RequireAuthorization()
            .Produces(Status401Unauthorized)
            .Produces<ClaimDto[]>();

        return retval;
    }

    private record SignInInput
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    private record SignInResultDto
    {
        public bool Succeeded { get; set; }
    }

    private record ClaimDto
    {
        public string Type { get; set; } = null!;
        public object Value { get; set; } = null!;
    }
}