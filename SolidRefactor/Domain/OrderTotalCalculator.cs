using SolidRefactor.Domain.Discounts;

namespace SolidRefactor.Domain;

public sealed class OrderTotalCalculator : IOrderTotalCalculator
{
    public decimal Calculate(IEnumerable<OrderItem> items, IDiscountStrategy discount)
    {
        ArgumentNullException.ThrowIfNull(items);
        ArgumentNullException.ThrowIfNull(discount);

        decimal subtotal = items.Sum(i => i.LineTotal);
        return decimal.Round(discount.Apply(subtotal), 2, MidpointRounding.AwayFromZero);
    }
}
