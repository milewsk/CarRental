using CarRental.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure;

public class ApplicationDbContext :DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}