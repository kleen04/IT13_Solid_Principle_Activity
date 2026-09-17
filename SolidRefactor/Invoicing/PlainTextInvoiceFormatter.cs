using System.Text;
using SolidRefactor.Domain;

namespace SolidRefactor.Invoicing;

public sealed class PlainTextInvoiceFormatter : IInvoiceFormatter
{
    public string BuildSubject(Order order) => $"Your invoice ({order.Total:C})";

    public string BuildBody(Order order)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Invoice for {order.CustomerEmail}");
        sb.AppendLine();

        foreach (var item in order.Items)
        {
            sb.AppendLine($"{item.Qty} x {item.Product} @ {item.Price:C} = {item.LineTotal:C}");
        }

        sb.AppendLine();
        sb.AppendLine($"Total: {order.Total:C}");
        return sb.ToString();
    }
}
