using Practice.Domain.Common;
using System.Text.RegularExpressions;

namespace Practice.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    private static readonly Regex EmailRegex = new(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public string Value { get; private set; } = null!;

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("Email cannot be empty.", nameof(email));

        var normalizedEmail = email.Trim().ToLowerInvariant();

        if (!EmailRegex.IsMatch(email))
            throw new DomainException("Invalid email format.", nameof(email));

        return new Email(normalizedEmail);
    }


    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
