namespace CarRental.Domain.Exceptions;

public sealed class ReservationEndDateIsNullDomainException : DomainException
{
    public ReservationEndDateIsNullDomainException(string message) : base(message)
    {
    }
}