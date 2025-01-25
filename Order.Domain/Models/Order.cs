using Order.Domain.Bases;
using Order.Domain.VOs;

namespace Order.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;

    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        return new Product
        {
            Id = id,
            Name = name,
            Price = price
        };
    }
}

public class Customer : Entity<Guid>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
}

public class Order : Aggregate<Guid>
{
    public Guid CustomerId { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public Address ShippingAddress { get; private set; } = default!;
    public Address BillingAddress { get; private set; } = default!;

    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }

    public readonly List<OrderItem> _orderItems = [];
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
}

public class OrderItem : Aggregate<Guid>
{
    internal OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public Guid OrderId { get; private set; } = default!;
    public Guid ProductId { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
}