using System.Reflection;
using CarRental.Domain.Abstractions;
using CarRental.Domain.Primitives;
using FluentAssertions;
using NetArchTest.Rules;

namespace CarRental.ArchitectureTests;

public class DomainLayerTests : BaseTests
{
    [Fact]
    public void DomainEvents_Should_BeSealed()
    {
        // Arrange
        var assembly = DomainAssemblyReference;

        // Act
        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .BeSealed()
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainEvents_Should_Have_DomainEventPostFix()
    {
        // Arrange
        var assembly = DomainAssemblyReference;

        // Act
        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .HaveNameEndingWith("DomainEvent")
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Entities_Should_Have_PrivateParameterlessConstructor()
    {
        // Arrange
        var assembly = DomainAssemblyReference;

        // Act
        var entityTypes = Types
            .InAssembly(assembly)
            .That()
            .Inherit(typeof(Entity)).GetTypes();

        var failingTypes = new List<Type>();

        foreach (var entity in entityTypes)
        {
            var constructors = entity.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);

            if (!Array.Exists(constructors, c => c.IsPrivate && c.GetParameters().Length == 0))
            {
                failingTypes.Add(entity);
            }
        }

        // Assert
        failingTypes.Should().BeEmpty();
    }
}