using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.CreateDateUtc).IsRequired();
        entityBuilder.Property(x => x.ModificationDateUtc).IsRequired();
        entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(80);
        entityBuilder.Property(x => x.Address).IsRequired().HasMaxLength(120);
        entityBuilder.Property(x => x.Country).IsRequired().HasMaxLength(50);
    }
}