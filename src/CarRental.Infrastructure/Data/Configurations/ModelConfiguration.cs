using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.Configurations;

public class ModelConfiguration: IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.CreateDateUtc).IsRequired();
        entityBuilder.Property(x => x.ModificationDateUtc).IsRequired();
        entityBuilder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        entityBuilder.Property(x => x.Manufacturer).HasMaxLength(100).IsRequired();
        entityBuilder.Property(x => x.BodyStyle).HasColumnType("byte").IsRequired();

        entityBuilder
            .HasMany<Asset>(m => m.Assets)
            .WithOne(a => a.Model)
            .HasForeignKey(a => a.ModelId)
            .IsRequired();
        
    }
}