namespace SolidRefactor.Domain.Discounts;

public abstract class PercentageDiscount : IDiscountStrategy
{
    private readonly decimal _multiplier;

    protected PercentageDiscount(string name, decimal multiplier)
    {
        if (multiplier < 0m || multiplier > 1m)
            throw new ArgumentOutOfRangeException(nameof(multiplier), "A discount multiplier must be between 0 and 1.");

        Name = name;
        _multiplier = multiplier;
    }

    public string Name { get; }

    public decimal Apply(decimal total)
    {
        if (total < 0m) throw new ArgumentOutOfRangeException(nameof(total));
        return decimal.Round(total * _multiplier, 2, MidpointRounding.AwayFromZero);
    }
}
