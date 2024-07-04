using CarRental.Domain.Entities;
using CarRental.Domain.Repositories;
using CarRental.Infrastructure.Data;

namespace CarRental.Infrastructure.Repositories;

public class ModelRepository : GenericRepository<Model>, IModelRepository
{
    private readonly ApplicationDbContext _context;

    public ModelRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}