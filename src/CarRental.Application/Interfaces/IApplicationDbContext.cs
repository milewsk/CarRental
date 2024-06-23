using CarRental.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<IModel> Models { get; }
    
  //  Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}