namespace Order.Domain.VOs;

public record CustomerId
{
    public Guid Value { get; }
    private CustomerId(Guid value) => Value = value;
    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new ArgumentException($"value is GuidEmpty");
        }

        return new CustomerId(value);
    }
}