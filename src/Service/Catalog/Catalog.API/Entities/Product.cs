namespace Catalog.API.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    { }

    protected BaseEntity(Guid code)
    {
        Id = code;
        CreatedAt = DateTime.Now;
    }

    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    private DateTime? UpdatedAt { get; set; }

    public void SetUpdatedAt() => this.UpdatedAt = DateTime.Now;
}

public class Product
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;
    public List<string> Categories { get; set; } = [];
}