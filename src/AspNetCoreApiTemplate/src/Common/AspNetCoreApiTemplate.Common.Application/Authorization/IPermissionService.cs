using AspNetCoreApiTemplate.Common.Domain;

namespace AspNetCoreApiTemplate.Common.Application.Authorization;

public interface IPermissionService
{
    Task<Result<PermissionResponse>> GetUserPermissionsAsync(string identityId);
}