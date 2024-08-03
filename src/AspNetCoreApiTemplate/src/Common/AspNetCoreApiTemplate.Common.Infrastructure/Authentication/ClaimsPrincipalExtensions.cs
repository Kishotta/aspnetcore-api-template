using System.Security.Claims;
using AspNetCoreApiTemplate.Common.Application.Exceptions;

namespace AspNetCoreApiTemplate.Common.Infrastructure.Authentication;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        var userId = principal?.FindFirstValue(CustomClaims.Sub);

        return Guid.TryParse(userId, out var parsedUserId)
            ? parsedUserId
            : throw new AspNetCoreApiTemplateException("User identifier is unavailable");
    }
    
    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier) ??
               throw new AspNetCoreApiTemplateException("User identity is unavailable");
    }

    public static HashSet<string> GetPermissions(this ClaimsPrincipal? principal)
    {
        var permissionClaims = principal?.FindAll(CustomClaims.Permission) ??
                               throw new AspNetCoreApiTemplateException("Permissions are unavailable");
        return permissionClaims.Select(claim => claim.Value).ToHashSet();
    }
}