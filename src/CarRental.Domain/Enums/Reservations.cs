namespace CarRental.Domain.Enums;

public enum ReservationStatus : byte
{
    Pending = 1,
    Accepted = 2,
    InProgress = 3,
    Ended = 4,
    Cancelled = 5
}

public enum ReservationType : byte
{
    PerDay = 1,
    DateRange = 2
}