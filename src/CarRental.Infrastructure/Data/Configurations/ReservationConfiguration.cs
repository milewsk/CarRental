using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Data.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.Property(x => x.CreateDateUtc).IsRequired();
        entityBuilder.Property(x => x.ModificationDateUtc).IsRequired();
        
        entityBuilder
            .HasOne(r => r.Asset)
            .WithOne(a => a.Reservation)
            .HasForeignKey<Reservation>(r => r.AssetId)
            .IsRequired();
    }
}