using Practice.Domain.Common;
using Practice.Domain.ValueObjects;

namespace Practice.Domain.Entities;

public sealed class User : Entity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;
    public int Age { get; private set; }

    public User(string firstName, string lastName, Email email, int age)
    {
        Validate(firstName, lastName, email, age);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Age = age;
    }

    public void Update(string firstName, string lastName, Email email, int age)
    {
        Validate(firstName, lastName, email, age);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Age = age;
        SetUpdateAt();
    }

    public void Validate(string firstName, string lastName, Email email, int age)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("Last name is required.");
        
        if (email == null)
            throw new DomainException("Email is required.");

        if (age < 0 || age > 100)
            throw new DomainException("Age must be between 0 and 100.");
    }
}
