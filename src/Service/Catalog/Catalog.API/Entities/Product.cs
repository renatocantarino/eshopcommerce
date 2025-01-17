namespace Catalog.API.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    private DateTime? UpdatedAt { get; set; }

    public void SetUpdatedAt() => this.UpdatedAt = DateTime.Now;
}

public class Product : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = default!;
    public List<string> Categories { get; set; } = [];
}