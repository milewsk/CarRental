using CarRental.Application.Common.Dtos.Reservation;
using CarRental.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace CarRental.Application.Common.Extensions;

[Mapper]
public partial class ReservationMapper
{
    public partial ReservationDto ReservationToReservationDto(Reservation reservation);
    public partial List<ReservationDto> ReservationListToReservationListDto(List<Reservation> reservations);
}