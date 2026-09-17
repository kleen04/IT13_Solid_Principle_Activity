using SolidRefactor.Domain;

namespace SolidRefactor.Invoicing;

public interface IInvoicePresenter
{
    void Present(Order order);
}
