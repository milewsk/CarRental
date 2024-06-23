using System.Reflection;
using CarRental.Domain.Abstractions;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data;

public class ApplicationDbContext :DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    // DbSet List
    public DbSet<Reservation?> Reservations => Set<Reservation>();
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Model> Models => Set<Model>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply entity configuration form Configurations folder
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}