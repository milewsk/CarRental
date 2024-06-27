using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Model> Models { get; }
    
  //  Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}