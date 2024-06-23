using FluentAssertions;
using NetArchTest.Rules;

namespace CarRental.ArchitectureTests;

public class ApplicationLayerTests : BaseTests
{
    [Fact]
    public void Handlers_Should_Have_DependencyOnDomain()
    {
        // Arrange
        var assembly = ApplicationAssemblyReference;

        // Act
        var result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}