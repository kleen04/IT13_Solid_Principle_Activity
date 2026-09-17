using SolidRefactor.Domain.Discounts;

namespace SolidRefactor.LspDemo;

public class FreeShippingDiscount : IDiscountStrategy
{
    public string Name => "FreeShipping";

    public decimal Apply(decimal total)
    {
        throw new NotSupportedException("Doesn't apply to order totals, only shipping!");
    }
}

