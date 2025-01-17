namespace Catalog.API.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
}

public class Product : BaseEntity
{
    public Product(string name, string description, List<string> categories, string imageUrl, decimal price)
    {
        Name = name;
        Description = description;
        Category = categories;
        ImageUrl = imageUrl;
        Price = price;
    }

    public string Name { get; protected set; } = default!;
    public string Description { get; protected set; } = default!;
    public decimal Price { get; protected set; }
    public string ImageUrl { get; protected set; } = default!;
    public List<string> Category { get; protected set; } = new();
}