using FluentAssertions;
using NetArchTest.Rules;

namespace CarRental.ArchitectureTests;

public class LayerTests : BaseTests
{
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnAnyOtherProject()
    {
        // Arrange
        var assembly = DomainAssemblyReference;

        // Act
        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            WebNamespace
        };

        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnAnyOtherProject()
    {
        // Arrange
        var assembly = ApplicationAssemblyReference;

        // Act
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            WebNamespace
        };

        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnAnyOtherProject()
    {
        // Arrange
        var assembly = InfrastructureAssemblyReference;

        // Act
        var otherProjects = new[]
        {
            WebNamespace
        };

        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}