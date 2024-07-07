using CarRental.Application.Reservations.Commands.CreateReservation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.MinimalApi;

public static class ReservationEndpoints
{
    private static async Task<IResult> GetTodoItemsWithPagination([AsParameters] GetTodoItemsWithPaginationQuery query,
        IMediator mediator)
    {
        var result = await mediator.Send(query);

        return Results.Ok(result);
    }

    private static async Task<IResult> CreateReservation([FromBody] CreateReservationCommand command,
        IMediator mediator)
    {
        var result = await mediator.Send(command);

        return result.IsSuccess ? Results.Ok()
        
        return Results.Ok(result);
    }
    
    private static async Task<IResult> GetReservations([AsParameters] GetReservationsQuery query,
        IMediator mediator)
    {
        var result = await mediator.Send(command);

        return Results.Ok(result);
    }

    public static void AddReservationEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("/reservations", GetReservations).WithOpenApi();
        
        routeBuilder.MapPost("/createReservation", CreateReservation)
            .WithOpenApi();
    }
}