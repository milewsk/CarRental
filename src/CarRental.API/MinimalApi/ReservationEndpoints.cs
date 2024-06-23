using MediatR;
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

    private static async Task<IResult> CreateTodoItem([FromBody] CreateTodoItemCommand command,
        IMediator mediator)
    {
        var result = await mediator.Send(command);

        return Results.Ok(result);
    }

    public static void AddReservationEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        
        routeBuilder.MapPost("/todoitems", CreateTodoItem)
            .WithOpenApi();

        routeBuilder.MapPut("/todoitems/{id}", GetTodoItemsWithPagination)
            .WithOpenApi();
    }
}