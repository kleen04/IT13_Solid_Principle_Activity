namespace SolidRefactor.Domain.Shipping;

public interface IShippingAdjustment
{
    string Name { get; }

    decimal Apply(decimal shippingFee);
}
