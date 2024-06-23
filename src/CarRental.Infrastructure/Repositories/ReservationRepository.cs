using CarRental.Infrastructure.Data;

namespace CarRental.Infrastructure.Repositories;

internal sealed class OrderRepository: IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
}