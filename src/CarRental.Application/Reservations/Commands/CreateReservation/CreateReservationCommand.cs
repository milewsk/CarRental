using CarRental.Domain.Enums;
using ICommand = CarRental.Application.Abstractions.ICommand;

namespace CarRental.Application.Reservations.Commands.CreateReservation;

public sealed record CreateReservationCommand(
    DateTime StartDate,
    DateTime? EndDate,
    ReservationType Type,
    ReservationStatus Status,
    int RentDays,
    Guid AssetId) : ICommand;