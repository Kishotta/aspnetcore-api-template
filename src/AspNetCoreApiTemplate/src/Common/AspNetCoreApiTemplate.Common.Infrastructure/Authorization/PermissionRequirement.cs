using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreApiTemplate.Common.Infrastructure.Authorization;

internal sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}