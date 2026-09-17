namespace SolidRefactor.Domain.Discounts;

public sealed class NoDiscount : PercentageDiscount
{
    public NoDiscount() : base("None", 1.00m) { }
}
