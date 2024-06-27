using CarRental.Domain.Enums;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Entities;

public class Reservation : Entity
{
    // Properties
    public DateTime StartDate { get; init; }

    public DateTime EndDate { get; init; }

    public ReservationType Type { get; set; }
    public ReservationStatus Status { get; set; }

    public int RentDays { get; set; }

    public decimal Cost { get; set; }

    // Relationships
    public Asset Asset { get; set; }

    // Constructors
    public Reservation(DateTime startDate, DateTime endDate, ReservationStatus status, ReservationType type,
        int rentDays, decimal cost, Asset asset)
    {
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        Type = type;
        RentDays = rentDays;
        Cost = cost;
        Asset = asset;
    }
}