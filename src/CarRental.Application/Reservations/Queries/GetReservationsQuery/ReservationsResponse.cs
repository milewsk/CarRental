using CarRental.Domain.Entities;

namespace CarRental.Application.Reservations.Queries.GetReservationsQuery;
public sealed record ReservationsResponse(List<Reservation> Reservations);