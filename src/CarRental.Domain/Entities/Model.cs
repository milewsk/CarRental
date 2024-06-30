using CarRental.Domain.Enums;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Entities;

public class Model : Entity
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public ModelClass ModelClass { get; set; }
    public BodyStyle BodyStyle { get; set; }
    public FuelType FuelType { get; set; }
    public DriveTrain DriveTrain { get; set; }

    // Relationships
    public Guid ModelPricingId { get; set; }
    public ModelPricing ModelPricing { get; set; } = null!;

    public ICollection<Asset> Assets { get; set; } = new List<Asset>();

    // Constructors
    public Model(string name, string manufacturer, ModelClass modelClass, BodyStyle bodyStyle, FuelType fuelType,
        DriveTrain driveTrain, Guid modelPricingId)
    {
        Name = name;
        Manufacturer = manufacturer;
        ModelClass = modelClass;
        BodyStyle = bodyStyle;
        FuelType = fuelType;
        DriveTrain = driveTrain;
        ModelPricingId = modelPricingId;
    }

    public Model(string name, string manufacturer, ModelClass modelClass, BodyStyle bodyStyle, FuelType fuelType,
        DriveTrain driveTrain, ModelPricing modelPricing, ICollection<Asset> assets)
    {
        Name = name;
        Manufacturer = manufacturer;
        ModelClass = modelClass;
        BodyStyle = bodyStyle;
        FuelType = fuelType;
        DriveTrain = driveTrain;
        ModelPricingId = modelPricing.Id;
        Assets = assets;
    }
}