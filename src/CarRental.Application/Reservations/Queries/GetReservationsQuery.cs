using FluentValidation;
using MediatR;

namespace CarRental.Application.Reservations.Queries;

public record GetReservationsQuery : IRequest<List<>>
{
    
}

public class Car
{
    public int Mileage { get; private set; }

    public Car(int mileage)
    {
        Mileage = mileage;
    }
}

public class Reservation
{
    private Reservation(Car car)
    {
        Car = car;
    }

    public Car Car { get; private set; }

    public int DziwkiCount { get; private set; }

    public static Reservation Create(Car car)
    {
        if (car.Mileage > 1000)
        {
            throw new Exception("CAR IS TOO OLD");
        }

        return new Reservation(car);
    }

    public void DodajDziwke()
    {
        if (DziwkiCount > 1000)
        {
            throw new Exception("Za duzo dziwek");
        }
        
        DziwkiCount++;
    }
}

public interface IReservationRepository
{
    void AddReservation(Reservation reservation);

    Task<Reservation?> GetReservation(Guid id);
}

public record CreateReservationCommand(Guid CarId) : IRequest;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IReservationRepository _reservationRepository;

    public CreateReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
    }
}


public record AddDziwkiCommand(Guid reservationId, int ilosc) : IRequest;

public class AddDziwkiCommandValidator : AbstractValidator<AddDziwkiCommand>
{
    public AddDziwkiCommandValidator()
    {
        RuleFor(x => x.ilosc)
            .LessThan(2000);
    }
}

public class AddDziwkiCommandHandler : IRequestHandler<AddDziwkiCommand>
{
    private readonly IReservationRepository _reservationRepository;

    public AddDziwkiCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public Task Handle(AddDziwkiCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var reservation = await _reservationRepository.GetReservation(command.reservationId);
        
        reservation.DodajDziwke(ilosc);
        
        // unit of work save
    }
}

public class CreateReservationDupCommand
{
    public Guid CarId { get; }

    public CreateReservationDupCommand(Guid carId)
    {
        CarId = carId;
    }
}
