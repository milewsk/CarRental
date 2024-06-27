using System.ComponentModel.DataAnnotations;
using CarRental.Domain.Primitives;

namespace CarRental.Domain.Entities;

public class ModelPricing : Entity
{
    // Properties
    public decimal StandardPrice { get; set; }

    public decimal ShortTermPrice { get; set; }

    public decimal LongTermPrice { get; set; }

    public decimal PricePerDay { get; set; }

    // Relationships
    public Guid ModelId { get; set; }
    public Model Model { get; set; }

    public ModelPricing(decimal standardPrice, decimal shortTermPrice, decimal longTermPrice, decimal pricePerDay,
        Model model)
    {
        StandardPrice = standardPrice;
        ShortTermPrice = shortTermPrice;
        LongTermPrice = longTermPrice;
        PricePerDay = pricePerDay;
        ModelId = model.Id;
        Model = model;
    }
}