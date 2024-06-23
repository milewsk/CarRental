using System.Reflection;

namespace CarRental.ArchitectureTests;

// Abstract class to store Assemblies and project namespaces
public abstract class BaseTests
{
    // Namespaces
    protected const string DomainNamespace = "CarRental.Domain";
    protected const string ApplicationNamespace = "CarRental.Application";
    protected const string InfrastructureNamespace = "CarRental.Infrastructure";
    protected const string WebNamespace = "CarRental.API";
    
    // Assemblies
    protected static readonly Assembly DomainAssemblyReference = typeof(CarRental.Domain.AssemblyReference).Assembly;
    protected static readonly Assembly ApplicationAssemblyReference = typeof(CarRental.Application.AssemblyReference).Assembly;
    protected static readonly Assembly InfrastructureAssemblyReference = typeof(CarRental.Infrastructure.AssemblyReference).Assembly;
    protected static readonly Assembly WebAssemblyReference = typeof(CarRental.API.AssemblyReference).Assembly;
    
   // protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;
}