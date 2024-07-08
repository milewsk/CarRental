using CarRental.Application.Abstractions;
using CarRental.Application.Common.Extensions;
using CarRental.Domain.Repositories;
using CarRental.Domain.Shared;

namespace CarRental.Application.Reservations.Queries.GetReservationsQuery;

internal sealed class GetReservationsQueryHandler : IQueryHandler<GetReservationsQuery, ReservationsResponse>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationsQueryHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<Result<ReservationsResponse>> Handle(GetReservationsQuery request,
        CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetAllAsync();
        var mapper = new ReservationMapper();

        if (reservations.Count == 0)
        {
            return new ReservationsResponse(mapper.ReservationListToReservationListDto(reservations));
        }

        if (request.Status is not null)
        {
            reservations = reservations.Where(x => x.Status == request.Status).ToList();
        }

        if (request.Type is not null)
        {
            reservations = reservations.Where(x => x.Type == request.Type).ToList();
        }

        var response = new ReservationsResponse(mapper.ReservationListToReservationListDto(reservations));

        return response;
    }
}