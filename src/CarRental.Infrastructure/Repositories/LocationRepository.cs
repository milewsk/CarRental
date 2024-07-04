using CarRental.Domain.Entities;
using CarRental.Domain.Repositories;
using CarRental.Infrastructure.Data;

namespace CarRental.Infrastructure.Repositories;

public class LocationRepository : GenericRepository<Location>, ILocationRepository
{
    private readonly ApplicationDbContext _context;

    public LocationRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}