using CarRental.Domain.Entities;
using CarRental.Domain.Repositories;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories;

internal sealed class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> GetReservationByIDAsync(Guid id)
    {
        return await _context.Reservations.Where(r => r != null && r.Id == id).SingleOrDefaultAsync();
    }

    public Task CreateReservationAsync()
    {
        throw new NotImplementedException();
    }
}