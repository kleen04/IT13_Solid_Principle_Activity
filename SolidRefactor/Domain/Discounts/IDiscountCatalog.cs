namespace SolidRefactor.Domain.Discounts;

public interface IDiscountCatalog
{
    IReadOnlyList<string> Names();

    IDiscountStrategy Find(string name);
}
