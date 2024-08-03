using MediatR;

namespace AspNetCoreApiTemplate.Common.Domain;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    DateTime OccurredAtUtc { get; }
}