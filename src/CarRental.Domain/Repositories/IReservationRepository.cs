using CarRental.Domain.Entities;

namespace CarRental.Domain.Repositories;

public interface IReservationRepository
{
    Task<Reservation?> GetReservationByIDAsync(Guid id);
    Task CreateReservationAsync();
}