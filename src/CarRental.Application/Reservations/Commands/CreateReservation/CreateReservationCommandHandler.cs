using CarRental.Application.Abstractions;
using CarRental.Domain.Entities;
using CarRental.Domain.Repositories;
using CarRental.Domain.Shared;
using MediatR;

namespace CarRental.Application.Reservations.Commands.CreateReservation;

internal sealed class CreateReservationCommandHandler : ICommandHandler<CreateReservationCommand>
{
    private readonly IReservationRepository _reservationRepository;

    public CreateReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Result> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = new Reservation(
            request.StartDate,
            request.EndDate,
            request.Status,
            request.Type,
            request.AssetId);
        
        await _reservationRepository.AddAsync(reservation);

        await _reservationRepository.SaveChangesAsync();
        
        return Result.Success();
    }
}