using CarRental.Application.Interfaces;
using CarRental.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;


namespace CarRental.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CarRental");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
        
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString);
        });
        
        return services;
    }
}