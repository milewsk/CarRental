using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Middlewares;

public class GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server Error",
                Title = "Server Error",
                Detail = "An internal server has occured"
            };

            var json = JsonSerializer.Serialize(problem);
            
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}