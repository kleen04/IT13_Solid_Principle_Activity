namespace SolidRefactor.Domain;

public sealed class OrderItem
{
    public OrderItem(string product, decimal price, int qty)
    {
        if (price < 0m) throw new ArgumentOutOfRangeException(nameof(price));
        if (qty < 0) throw new ArgumentOutOfRangeException(nameof(qty));

        Product = product ?? string.Empty;
        Price = price;
        Qty = qty;
    }

    public string Product { get; }
    public decimal Price { get; }
    public int Qty { get; }

    public decimal LineTotal => Price * Qty;
}
