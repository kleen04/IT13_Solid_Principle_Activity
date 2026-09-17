using SolidRefactor.Domain;

namespace SolidRefactor.Persistence;

public interface IOrderWriter
{
    void Save(Order order);
}
