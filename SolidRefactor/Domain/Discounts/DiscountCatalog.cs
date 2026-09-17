namespace SolidRefactor.Domain.Discounts;

public sealed class DiscountCatalog : IDiscountCatalog
{
    private readonly IReadOnlyList<IDiscountStrategy> _strategies;

    public DiscountCatalog(IEnumerable<IDiscountStrategy> strategies)
    {
        _strategies = (strategies ?? throw new ArgumentNullException(nameof(strategies))).ToList();

        if (_strategies.Count == 0)
            throw new ArgumentException("At least one discount strategy is required.", nameof(strategies));
    }

    public IReadOnlyList<string> Names() => _strategies.Select(s => s.Name).ToList();

    public IDiscountStrategy Find(string name) =>
        _strategies.FirstOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase))
        ?? _strategies[0];
}
