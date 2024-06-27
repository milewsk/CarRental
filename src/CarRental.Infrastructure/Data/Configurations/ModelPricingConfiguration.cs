using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.Configurations;

public class ModelPricingConfiguration: IEntityTypeConfiguration<ModelPricing>
{
    public void Configure(EntityTypeBuilder<ModelPricing> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.CreateDateUtc).IsRequired();
        entityBuilder.Property(x => x.ModificationDateUtc).IsRequired();
        entityBuilder.Property(x => x.PricePerDay).IsRequired();
        entityBuilder.Property(x => x.StandardPrice).IsRequired();
        entityBuilder.Property(x => x.StandardPrice).IsRequired();
    }
}