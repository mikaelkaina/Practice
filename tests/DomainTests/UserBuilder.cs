using Bogus;
using Practice.Domain;

namespace DomainTests;

public class TestUser : User
{
    public TestUser() : base() { }
    public TestUser(Guid id, string firstName, string lastName, int age) : base(id, firstName, lastName, age) { }
}
public class UserBuilder
{
    private Guid _id;
    private string _firstName;
    private string _lastName;
    private int _age;

    public UserBuilder()
    {
        var faker = new Faker();
        _id = Guid.NewGuid();
        _firstName = faker.Name.FirstName();
        _lastName = faker.Name.LastName();
        _age = faker.Random.Int(0, 100);
    }

    public UserBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public UserBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }

    public UserBuilder WithAge(int age)
    {
        _age = age;
        return this;
    }

    public Action BuildValidateAction()
    {
        return () => new TestUser().Validate(_id, _firstName, _lastName, _age);
    }
}
