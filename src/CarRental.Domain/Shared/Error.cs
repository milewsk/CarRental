namespace CarRental.Domain.Shared;

public sealed class Error : IEquatable<Error>
{
    public static readonly Error None = new Error(string.Empty, string.Empty);
    public static readonly Error NullValue = new Error("Error.NullValue", "The specified object result is null.");

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }

    public static implicit operator string(Error error) => error.Code;
    
    public static bool operator ==(Error? first, Error? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }
    
    public static bool operator !=(Error? first, Error? second)
    {
        return !(first == second);
    }
    
    public bool Equals(Error? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return other.Code == Code;
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

        if (obj is not Error error)
        {
            return false;
        }

        return error.Code == Code;
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }
}