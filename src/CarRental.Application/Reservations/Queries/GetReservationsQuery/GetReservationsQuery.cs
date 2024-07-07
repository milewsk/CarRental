using CarRental.Application.Abstractions;
using CarRental.Domain.Enums;

namespace CarRental.Application.Reservations.Queries.GetReservationsQuery;

public sealed record GetReservationsQuery(
    DateTime UtcNow,
    ReservationStatus? Status,
    ReservationType? Type) : IQuery<ReservationsResponse>;
    