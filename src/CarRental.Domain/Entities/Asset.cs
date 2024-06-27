using CarRental.Domain.Enums;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Entities;

public class Asset : Entity
{
    // Properties
    public AssetStatus Status { get; set; }
    public string Vin { get; set; }
    public double Mileage { get; set; }

    // Relationships
    public Model Model { get; set; }
    public Guid ModelId { get; set; }

    public Location Location { get; set; }
    public Guid LocationId { get; set; }

    // Constructors
    public Asset(AssetStatus status, string vin, double mileage, Model model, Guid modelId, Location location,
        Guid locationId)
    {
        Status = status;
        Vin = vin;
        Mileage = mileage;
        Model = model;
        ModelId = modelId;
        Location = location;
        LocationId = locationId;
    }
}