using System.Reflection;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSet List
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<Model> Models => Set<Model>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<ModelPricing> ModelPricings => Set<ModelPricing>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply entity configuration form Configurations folder
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}