namespace CarRental.Domain.Enums;

public enum AssetStatus: byte
{
    Available = 1,
    Rented = 2,
    InRepair = 3,
    Unavailable = 4
}