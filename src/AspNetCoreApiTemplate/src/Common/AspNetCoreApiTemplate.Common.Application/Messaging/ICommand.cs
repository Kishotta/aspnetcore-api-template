using AspNetCoreApiTemplate.Common.Domain;
using MediatR;

namespace AspNetCoreApiTemplate.Common.Application.Messaging;

public interface IBaseCommand;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;
