namespace Practice.Domain;

public abstract class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }

    protected User() { }

    public User(Guid id, string firstName, string lastName, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public void Validate(Guid id, string firstName, string lastName, int age)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new DomainException("First name is required.");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new DomainException("Last name is required.");

        if (age < 0 || age > 100)
            throw new DomainException("Age must be between 0 and 100.");

        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}
