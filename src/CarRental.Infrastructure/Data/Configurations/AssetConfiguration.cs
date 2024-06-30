using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.Configurations;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.CreateDateUtc).IsRequired();
        entityBuilder.Property(x => x.ModificationDateUtc).IsRequired();

        entityBuilder
            .HasOne<Location>(a => a.Location)
            .WithMany(l => l.Assets)
            .HasForeignKey(a => a.LocationId)
            .IsRequired();
        
        entityBuilder
            .HasOne<Model>(a => a.Model)
            .WithMany(m => m.Assets)
            .HasForeignKey(a => a.ModelId)
            .IsRequired();
    }
}