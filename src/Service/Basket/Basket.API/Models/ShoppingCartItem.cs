using System.Text.Json.Serialization;

namespace Basket.API.Models;

public class ShoppingCartItem
{
    public Guid Product { get; set; } = default!;
    public int Quantity { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public string Color { get; set; } = default!;
}

public class ShoppingCart
{
    [JsonIgnore]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Document { get; set; } = default!;

    public List<ShoppingCartItem> Items { get; set; } = [];

    [JsonIgnore]
    public decimal Total => Items.Sum(x => x.Price * x.Quantity);

    public ShoppingCart(string document)
    {
        Document = document;
    }

    public ShoppingCart()
    { }
}