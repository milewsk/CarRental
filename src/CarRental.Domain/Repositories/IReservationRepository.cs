using CarRental.Domain.Entities;

namespace CarRental.Domain.Repositories;

public interface IReservationRepository: IGenericRepository<Reservation>
{
    Task<Reservation?> GetReservationByIDAsync(Guid id);
    Task CreateReservationAsync();
}