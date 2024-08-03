using AspNetCoreApiTemplate.Common.Domain;
using MediatR;

namespace AspNetCoreApiTemplate.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
