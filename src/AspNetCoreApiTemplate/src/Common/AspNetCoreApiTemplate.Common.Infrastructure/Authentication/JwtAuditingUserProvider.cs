using AspNetCoreApiTemplate.Common.Application.Exceptions;
using AspNetCoreApiTemplate.Common.Infrastructure.Auditing;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreApiTemplate.Common.Infrastructure.Authentication;

public class JwtAuditingUserProvider(IHttpContextAccessor httpContextAccessor) : IAuditingUserProvider
{
    private const string DefaultUser = "Unknown User";
    
    public string GetUserId()
    {
        try
        {
            return httpContextAccessor.HttpContext?.User.GetUserId().ToString() ?? DefaultUser;
        }
        catch (AspNetCoreApiTemplateException)
        {
            return DefaultUser;
        }
    }
}