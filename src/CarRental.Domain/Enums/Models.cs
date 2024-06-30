namespace CarRental.Domain.Enums;

public enum ModelClass : byte
{
    A = 1,
    B = 2,
    C = 3,
    D = 4,
    E = 5,
    F = 6,
    S = 7
}

public enum BodyStyle : byte
{
    Cabriolet = 1,
    Coupe = 2,
    Hatchback = 3,
    Limousine = 4,
    Minivan = 5,
    Sedan = 6,
    PickupTruck = 7
}

public enum FuelType : byte
{
    Diesel = 1,
    Hybrid = 2,
    Electric = 3,
    Gasoline = 4
}

public enum DriveTrain : byte
{
    FrontWheel = 1,
    RearWheel = 2,
    FourWheel = 3,
    AllWheel = 4
}