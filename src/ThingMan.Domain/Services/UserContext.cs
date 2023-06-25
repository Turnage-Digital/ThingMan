using System.Security.Claims;

namespace ThingMan.Domain;

public class UserContext : IUserContext
{
    private readonly ClaimsPrincipal _claimsPrincipal;

    public UserContext(ClaimsPrincipal claimsPrincipal)
    {
        _claimsPrincipal = claimsPrincipal;
    }

    public string UserId => _claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
}