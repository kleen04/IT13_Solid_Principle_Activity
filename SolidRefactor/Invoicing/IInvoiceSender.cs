using SolidRefactor.Domain;

namespace SolidRefactor.Invoicing;

public interface IInvoiceSender
{
    void Send(Order order);
}
