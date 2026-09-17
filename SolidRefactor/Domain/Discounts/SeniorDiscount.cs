namespace SolidRefactor.Domain.Discounts;

public sealed class SeniorDiscount : PercentageDiscount
{
    public SeniorDiscount() : base("Senior", 0.85m) { }
}
