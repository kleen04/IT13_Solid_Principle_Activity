namespace SolidRefactor.Domain.Discounts;

public sealed class StudentDiscount : PercentageDiscount
{
    public StudentDiscount() : base("Student", 0.90m) { }
}
