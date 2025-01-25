namespace Order.Domain.VOs;

public record Address(string ZipCode, string Country);

public record OrderName
{
    private const int Min_Length = 3;
    public string Value { get; }

    public OrderName(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        if (value.Length <= Min_Length)
            throw new ArgumentException($"Order name must have at least {Min_Length} characters");

        Value = value;
    }
}