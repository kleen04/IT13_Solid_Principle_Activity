using SolidRefactor.Domain;
using SolidRefactor.Invoicing;

namespace SolidRefactor.UI;


public sealed class MessageBoxInvoicePresenter : IInvoicePresenter
{
    private readonly IInvoiceFormatter _formatter;

    public MessageBoxInvoicePresenter(IInvoiceFormatter formatter)
    {
        _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
    }

    public void Present(Order order)
    {
        MessageBox.Show(_formatter.BuildBody(order), "Invoice preview",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
