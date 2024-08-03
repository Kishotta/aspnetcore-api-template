namespace AspNetCoreApiTemplate.Common.Infrastructure.Auditing;

public interface IAuditingUserProvider
{
    string GetUserId();
}