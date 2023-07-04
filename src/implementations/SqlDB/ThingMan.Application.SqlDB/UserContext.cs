using System.Security.Claims;
using ThingMan.Core;

namespace ThingMan.Application.SqlDB;

public class UserContext : IUserContext
{
    private readonly ClaimsPrincipal _claimsPrincipal;

    public UserContext(ClaimsPrincipal claimsPrincipal)
    {
        _claimsPrincipal = claimsPrincipal;
    }

    public string UserId => _claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)!.Value;
}