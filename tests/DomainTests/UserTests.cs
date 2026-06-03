using FluentAssertions;
using Practice.Domain;

namespace DomainTests;

public class UserTests
{
    [Fact]
    public void Constructor_WithValidData_ShouldCreateUser()
    {
        var builder = new UserBuilder();

        var user = builder.Build();

        user.Should().NotBeNull();
        user.Id.Should().NotBeEmpty();
        user.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        user.UpdatedAt.Should().BeNull();
    }

    [Fact]
    public void Update_WithValidData_ShouldUpdatePropertiesAndSetUpdatedAt()
    {
        var user = new UserBuilder().Build();
        var newFirstName = "John";
        var newLastName = "Doe";
        var newAge = 30;

        user.Update(newFirstName, newLastName, newAge);

        user.FirstName.Should().Be(newFirstName);
        user.LastName.Should().Be(newLastName);
        user.Age.Should().Be(newAge);
        user.UpdatedAt.Should().NotBeNull();
        user.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Constructor_WithInvalidFirstName_ShouldThrowDomainException(string? invalidFirstName)
    {
        Action action = () => new UserBuilder().WithFirstName(invalidFirstName).Build();

        action.Should().Throw<Exception>()
            .WithMessage("First name is required.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Constructor_WithInvalidLastName_ShouldThrowDomainException(string? invalidLastName)
    {
        Action action = () => new UserBuilder().WithLastName(invalidLastName).Build();

        action.Should().Throw<Exception>()
            .WithMessage("Last name is required.");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void Constructor_WithInvalidAge_ShouldThrowDomainException(int invalidAge)
    {
        Action action = () => new UserBuilder().WithAge(invalidAge).Build();

        action.Should().Throw<Exception>()
            .WithMessage("Age must be between 0 and 100.");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Update_WithInvalidLastName_ShouldThrowDomainException(string? invalidLastName)
    {
        var user = new UserBuilder().Build();

        Action action = () => user.Update(user.FirstName, invalidLastName!, user.Age);

        action.Should().Throw<Exception>()
            .WithMessage("Last name is required.");
    }
}
