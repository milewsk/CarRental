using System.ComponentModel.DataAnnotations;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Entities;

public class ModelPricing : Entity
{
    // Properties
    public decimal StandardPrice { get; set; }

    public decimal PricePerDay { get; set; }

    // Relationships
    public Guid ModelId { get; set; }
    public Model Model { get; set; } = null!;

    // Constructors
    public ModelPricing(decimal standardPrice, decimal pricePerDay,
        Guid modelId)
    {
        StandardPrice = standardPrice;
        PricePerDay = pricePerDay;
        ModelId = modelId;
    }

    public ModelPricing(decimal standardPrice, decimal shortTermPrice, decimal longTermPrice, decimal pricePerDay,
        Model model)
    {
        StandardPrice = standardPrice;
        PricePerDay = pricePerDay;
        ModelId = model.Id;
        Model = model;
    }
}