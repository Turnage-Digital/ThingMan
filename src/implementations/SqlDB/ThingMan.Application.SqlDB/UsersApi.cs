using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ThingMan.Application.SqlDB;

public static class UsersApi
{
    public static IEndpointConventionBuilder MapUserApi(this IEndpointRouteBuilder endpoints)
    {
        var retval = endpoints
            .MapGroup("/api/users")
            .WithTags("Users");

        retval.MapPost("/sign-in", async (SignInRequest input, SignInManager<IdentityUser> signInManager) =>
            {
                var result = await signInManager.PasswordSignInAsync(input.Username, input.Password,
                    true, false);
                return Results.Json(new SignInResponse { Succeeded = result.Succeeded });
            })
            .Produces<SignInResponse>();

        retval.MapGet("/claims", (ClaimsPrincipal claimsPrincipal) =>
            {
                var claims = claimsPrincipal.Claims
                    .Select(x => new Claim { Type = x.Type, Value = x.Value });
                return Results.Json(claims);
            })
            .RequireAuthorization()
            .Produces(Status401Unauthorized)
            .Produces<Claim[]>();

        return retval;
    }

    private record SignInRequest
    {
        [Required]
        [JsonProperty("username")]
        public string Username { get; set; } = null!;

        [Required]
        [JsonProperty("password")]
        public string Password { get; set; } = null!;
    }

    private record SignInResponse
    {
        [JsonProperty("succeeded")]
        public bool Succeeded { get; set; }
    }

    private record Claim
    {
        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        [JsonProperty("value")]
        public object Value { get; set; } = null!;
    }
}