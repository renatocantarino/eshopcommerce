using Order.Domain.Bases;
using Order.Domain.VOs;

namespace Order.Domain.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Document { get; private set; } = default!;
}