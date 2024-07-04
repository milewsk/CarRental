using CarRental.Domain.Entities;
using CarRental.Domain.Repositories;
using CarRental.Infrastructure.Data;

namespace CarRental.Infrastructure.Repositories;

public class ModelPricingRepository : GenericRepository<ModelPricing>, IModelPricingRepository
{
    private readonly ApplicationDbContext _context;

    public ModelPricingRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}