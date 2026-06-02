using FluentAssertions;
using Practice.Domain;

namespace DomainTests;

public class UserTests
{
    [Fact]
    public void Validate_WithValidData_ShouldNotThrowException()
    {
        var validateAction = new UserBuilder().BuildValidateAction();
        validateAction.Should().NotThrow();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Validate_WithInvalidFirstName_ShouldThrowDomainException(string? invalidFirstName)
    {
        var validateAction = new UserBuilder()
            .WithFirstName(invalidFirstName!)
            .BuildValidateAction();

        validateAction.Should()
            .Throw<DomainException>()
            .WithMessage("First name is required.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Validate_WithInvalidLastName_ShouldThrowDomainException(string? invalidLastName)
    {
        var validateAction = new UserBuilder()
            .WithLastName(invalidLastName!)
            .BuildValidateAction();

        validateAction.Should()
            .Throw<DomainException>()
            .WithMessage("Last name is required.");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void Validate_WithInvalidAge_ShouldThrowDomainException(int invalidAge)
    {
        var validateAction = new UserBuilder()
            .WithAge(invalidAge)
            .BuildValidateAction();

        validateAction.Should()
            .Throw<DomainException>()
            .WithMessage("Age must be between 0 and 100.");
    }
}
