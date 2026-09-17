using SolidRefactor.Domain;

namespace SolidRefactor.Invoicing;

public interface IInvoiceFormatter
{
    string BuildSubject(Order order);

    string BuildBody(Order order);
}
