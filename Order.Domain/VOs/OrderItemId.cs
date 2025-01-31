namespace Order.Domain.VOs;

public record OrderItemId
{
    public Guid Value { get; }
    private OrderItemId(Guid value) => Value = value;
    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, "value is GuidEmpty");
        if (value == Guid.Empty)
            throw new ArgumentException($"value is GuidEmpty");

        return new OrderItemId(value);
    }
}