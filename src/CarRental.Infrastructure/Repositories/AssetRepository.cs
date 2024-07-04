using CarRental.Domain.Entities;
using CarRental.Domain.Repositories;
using CarRental.Infrastructure.Data;

namespace CarRental.Infrastructure.Repositories;

public class AssetRepository : GenericRepository<Asset>, IAssetRepository
{
    private readonly ApplicationDbContext _context;

    public AssetRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}