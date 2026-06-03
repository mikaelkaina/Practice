namespace Practice.Domain;

public class DomainException : Exception
{
    public DomainException(string message, string v) : base(message) { }
}