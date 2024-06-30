using System.Reflection;
using CarRental.Domain.Primitives;
using FluentAssertions;
using NetArchTest.Rules;

namespace CarRental.ArchitectureTests;

public class DomainLayerTests : BaseTests
{
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