using FluentAssertions;
using NetArchTest.Rules;

namespace CarRental.ArchitectureTests;

public class PresentationLayerTests : BaseTests
{
    [Fact]
    public void Controllers_Should_Have_DependencyOnMediatr()
    {
        // Arrange
        var assembly = WebAssemblyReference;

        // Act
        var result = Types
            .InAssembly(assembly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}