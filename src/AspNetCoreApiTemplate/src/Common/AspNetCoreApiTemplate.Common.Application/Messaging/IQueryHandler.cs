using AspNetCoreApiTemplate.Common.Domain;
using MediatR;

namespace AspNetCoreApiTemplate.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;