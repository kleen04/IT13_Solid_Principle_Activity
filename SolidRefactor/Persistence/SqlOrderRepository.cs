using Microsoft.Data.SqlClient;
using SolidRefactor.Domain;

namespace SolidRefactor.Persistence;

public sealed class SqlOrderRepository : IOrderWriter, IOrderReader
{
    private readonly string _connectionString;

    public SqlOrderRepository(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public void Save(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(
            "INSERT INTO Orders (Email, Total) VALUES (@e, @t)", connection);

        command.Parameters.AddWithValue("@e", order.CustomerEmail);
        command.Parameters.AddWithValue("@t", order.Total);

        connection.Open();
        command.ExecuteNonQuery();
    }

    public IReadOnlyList<Order> FindByEmail(string email)
    {
        var results = new List<Order>();

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(
            "SELECT Email, Total FROM Orders WHERE Email = @e", connection);

        command.Parameters.AddWithValue("@e", email ?? string.Empty);

        connection.Open();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            results.Add(new Order(reader.GetString(0), Array.Empty<OrderItem>(), reader.GetDecimal(1)));
        }

        return results;
    }
}
