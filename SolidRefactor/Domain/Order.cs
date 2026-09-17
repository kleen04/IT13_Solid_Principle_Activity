namespace SolidRefactor.Domain;

public sealed class Order
{
    public Order(string customerEmail, IEnumerable<OrderItem> items, decimal total)
    {
        CustomerEmail = customerEmail ?? string.Empty;
        Items = (items ?? Enumerable.Empty<OrderItem>()).ToList();
        Total = total;
    }

    public string CustomerEmail { get; }
    public IReadOnlyList<OrderItem> Items { get; }
    public decimal Total { get; }
}
