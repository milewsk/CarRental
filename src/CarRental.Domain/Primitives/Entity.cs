using System.ComponentModel.DataAnnotations;

namespace CarRental.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    //Properties
    [Key]
    public Guid Id { get; private set; }
    
    public DateTime CreateDateUtc { get; set; } = DateTime.UtcNow;
    
    public DateTime ModificationDateUtc { get; set; } = DateTime.UtcNow;

    // Constructors
    protected Entity(Guid id) => Id = id;

    protected Entity()
    {
    }

    public static bool operator ==(Entity? first, Entity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }
    
    public static bool operator !=(Entity? first, Entity? second)
    {
        return !(first == second);
    }
    
    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return other.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}