using SolidRefactor.Domain.Discounts;

namespace SolidRefactor.Domain;

public interface IOrderTotalCalculator
{
    decimal Calculate(IEnumerable<OrderItem> items, IDiscountStrategy discount);
}
