using CarRental.Domain.Shared;
using MediatR;

namespace CarRental.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}