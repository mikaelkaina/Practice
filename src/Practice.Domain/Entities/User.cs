using Practice.Domain.Common;

namespace Practice.Domain.Entities;

public sealed class User : Entity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public int Age { get; private set; }

    public User(string firstName, string lastName, int age)
    {
        Validate(firstName, lastName, age);

        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public void Update(string firstName, string lastName, int age)
    {
        Validate(firstName, lastName, age);

        FirstName = firstName;
        LastName = lastName;
        Age = age;
        SetUpdateAt();
    }

    public void Validate(string firstName, string lastName, int age)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("Last name is required.");

        if (age < 0 || age > 100)
            throw new DomainException("Age must be between 0 and 100.");

        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}
