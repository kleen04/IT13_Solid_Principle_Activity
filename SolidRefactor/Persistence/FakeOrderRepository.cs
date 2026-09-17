using SolidRefactor.Domain;

namespace SolidRefactor.Persistence;

public sealed class FakeOrderRepository : IOrderWriter, IOrderReader
{
    private readonly List<Order> _saved = new();

    
    public IReadOnlyList<Order> SavedOrders => _saved;

    
    public Exception? FailWith { get; set; }

    public void Save(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        if (FailWith is not null) throw FailWith;

        _saved.Add(order);
    }

    public IReadOnlyList<Order> FindByEmail(string email) =>
        _saved.Where(o => string.Equals(o.CustomerEmail, email, StringComparison.OrdinalIgnoreCase)).ToList();
}
