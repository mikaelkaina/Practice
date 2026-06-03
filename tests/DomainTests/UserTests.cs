using FluentAssertions;
using Practice.Domain;
using Practice.Domain.ValueObjects;

namespace DomainTests;

public class UserTests
{
    [Fact]
    public void Constructor_WithValidData_ShouldCreateUser()
    {
        var user = new UserBuilder().returnUser();

        user.Should().NotBeNull();
        user.Email.Should().NotBeNull();
    }

    [Fact]
    public void Update_WithValidData_ShouldUpdateProperties()
    {
        var user = new UserBuilder().returnUser();
        var newEmail = Email.Create("novo@email.com");

        user.Update("NovoNome", "NovoSobrenome", newEmail, 25);

        user.Email.Should().Be(newEmail);
    }

    [Fact]
    public void Constructor_WithNullEmail_ShouldThrowDomainException()
    {
        Action action = () => new UserBuilder().WithEmail(null).returnUser();

        action.Should().Throw<DomainException>().WithMessage("Email is required.");
    }
}
