using FluentAssertions;
using Practice.Domain;
using Practice.Domain.ValueObjects;

namespace DomainTests;

public class EmailTests
{
    [Fact]
    public void Create_WithValidEmail_ShouldReturnEmailInstance()
    {
        var emailStr = "blabla@ll.com";
        var email = Email.Create(emailStr);

        email.Value.Should().Be("blabla@ll.com");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_WithEmptyOrNullEmail_ShouldThrowDomainException(string? invalidEmail)
    {
        Action action = () => Email.Create(invalidEmail!);

        action.Should().Throw<DomainException>().WithMessage("Email is required.");
    }

    [Theory]
    [InlineData("invalid-email")]
    [InlineData("joao@")]
    [InlineData("@blabla.com")]
    public void Create_WithInvalidFormat_ShouldThrowDomainException(string invalidFormat)
    {
        Action action = () => Email.Create(invalidFormat);

        action.Should().Throw<DomainException>().WithMessage("Invalid email format.");
    }

    [Fact]
    public void Emails_WithSameValue_ShouldBeEqual()
    {
        var emailA = Email.Create("Blabla@lll.com");
        var emailB = Email.Create("blabla@lll.com");

        emailA.Should().Be(emailB);
        (emailA == emailB).Should().BeTrue();
    }
}