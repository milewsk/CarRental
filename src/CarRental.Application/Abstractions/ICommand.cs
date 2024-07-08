using CarRental.Domain.Shared;
using MediatR;

namespace CarRental.Application.Abstractions;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}