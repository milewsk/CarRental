namespace CarRental.Domain.Primitives;

public abstract class Entity
{
    //Properties
    public Guid Id { get; protected set; }
    public DateTime CreateDateUtc { get; set; } = DateTime.UtcNow;
    public DateTime ModificationDateUtc { get; set; } = DateTime.UtcNow;

    // Constructors
    protected Entity(Guid id) => Id = id;

    protected Entity()
    {
    }
    
}