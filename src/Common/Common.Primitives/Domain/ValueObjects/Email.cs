using Common.Primitives.ValueObjects;

namespace Common.Primitives.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    public string To { get; }
    public string Subject { get; }
    public string Body { get; }

    private Email(string to, string subject, string body)
    {
        To = to;
        Subject = subject;
        Body = body;
    }

    public static Email From(string to, string subject, string body)
    {
        Ensure.Argument.NotNullOrEmpty(to, nameof(to));
        return new Email(to, subject, body);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}
