using SolidRefactor.Domain;

namespace SolidRefactor.Persistence;

public interface IOrderReader
{
    IReadOnlyList<Order> FindByEmail(string email);
}
