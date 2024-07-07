using CarRental.Domain.Enums;
using CarRental.Domain.Exceptions;
using CarRental.Domain.Primitives;
using CarRental.Domain.Shared;

namespace CarRental.Domain.Entities;

public class Reservation : Entity
{
    // Properties
    public DateTime StartDate { get; init; }

    public DateTime? EndDate { get; init; }

    public ReservationType Type { get; set; }
    public ReservationStatus Status { get; set; }

    public decimal Cost { get; set; } = 0;

    // Relationships
    public Asset Asset { get; set; } = null!;
    public Guid AssetId { get; set; }

    // Constructors
    public Reservation(DateTime startDate, DateTime? endDate, ReservationStatus status, ReservationType type,
         Guid assetId)
    {
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        Type = type;
        AssetId = assetId;
    }

    public Reservation(DateTime startDate, DateTime? endDate, ReservationStatus status, ReservationType type,
        decimal cost, Asset asset)
    {
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        Type = type;
        Cost = cost;
        AssetId = asset.Id;
        Asset = asset;
    }

    // Methods
    private void CalculateReservationCosts()
    {
        var modelPricing = Asset.Model.ModelPricing;
        Decimal discount = new decimal();

        switch (Type)
        {
            case ReservationType.PerDay:
                discount = CalculateDiscount();

                Cost = (DateTime.UtcNow - StartDate).Days * modelPricing.PricePerDay * discount;
                break;
            case ReservationType.DateRange:
                if (!EndDate.HasValue)
                {
                    throw new ReservationEndDateIsNullDomainException(
                        $"Reservation ID: {this.Id}, EndDate for ReservationType DateRange can't be null")
                }
                
                if (DateTime.UtcNow >= EndDate)
                {
                    var daysOverEndDate = (DateTime.UtcNow - EndDate).Value.Days;
                    Cost += 2 * (daysOverEndDate * modelPricing.StandardPrice);
                }
                else
                {
                    discount = CalculateDiscount();
                }

                (DateTime.UtcNow - StartDate).Days 
                break;
        }
    }

    private decimal CalculateDiscount()
    {
        switch (Type)
        {
            case ReservationType.PerDay:
                return
            case ReservationType.DateRange:
        }

        if (EndDate - StartDate).Value.Days)
    }

    public Result<Reservation> CloseReservation()
    {
        ReservationStatus = ReservationStatus.Ended;
    }
}