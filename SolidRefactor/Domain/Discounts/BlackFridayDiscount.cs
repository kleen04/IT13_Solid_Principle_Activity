namespace SolidRefactor.Domain.Discounts;

public sealed class BlackFridayDiscount : PercentageDiscount
{
    public BlackFridayDiscount() : base("BlackFriday", 0.70m) { }
}
