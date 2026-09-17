namespace SolidRefactor.Domain.Shipping;

public sealed class FreeShipping : IShippingAdjustment
{
    public string Name => "FreeShipping";

    public decimal Apply(decimal shippingFee)
    {
        if (shippingFee < 0m) throw new ArgumentOutOfRangeException(nameof(shippingFee));
        return 0m;
    }
}
