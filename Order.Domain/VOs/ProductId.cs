﻿namespace Order.Domain.VOs;

public record ProductId
{
    public Guid Value { get; }
    private ProductId(Guid value) => Value = value;

    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new ArgumentException("Product id is required", nameof(value));

        return new ProductId(value);
    }
}

public record OrderId
{
    public Guid Value { get; }
    private OrderId(Guid value) => Value = value;

    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new ArgumentException("OrderId is required", nameof(value));

        return new OrderId(value);
    }
}