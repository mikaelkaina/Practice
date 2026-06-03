using Bogus;
using Practice.Domain.Entities;
using Practice.Domain.ValueObjects;

namespace DomainTests;

public class UserBuilder
{
    private string _firstName;
    private string _lastName;
    private Email _email;
    private int _age;

    public UserBuilder()
    {
        var faker = new Faker();
        _firstName = faker.Name.FirstName();
        _lastName = faker.Name.LastName();
        _email = faker.Name.Email;
        
        _age = faker.Random.Int(0, 100);
    }

    public UserBuilder WithFirstName(string? firstName)
    {
        _firstName = firstName!;
        return this;
    }

    public UserBuilder WithLastName(string? lastName)
    {
        _lastName = lastName!;
        return this;
    }

    public UserBuilder WithAge(int age)
    {
        _age = age;
        return this;
    }

    public User Build()
    {
        return new User(_firstName, _lastName, _email, _age);
    }
}
