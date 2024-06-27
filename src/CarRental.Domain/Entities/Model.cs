using CarRental.Domain.Primitives;

namespace CarRental.Domain.Entities;

public class Model : Entity
{
    
    
    
    // Relationships
    public Guid ModelPricingId { get; set; }
    
    public ModelPricing ModelPricing { get; set; }
}