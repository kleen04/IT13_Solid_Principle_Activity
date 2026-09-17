using SolidRefactor.Domain;
using SolidRefactor.Domain.Discounts;
using SolidRefactor.Invoicing;
using SolidRefactor.Persistence;
using SolidRefactor.UI;
using SolidRefactor.LspDemo;

namespace SolidRefactor;


public sealed record OrderScreenDependencies(
    IOrderTotalCalculator Calculator,
    IDiscountCatalog Discounts,
    IOrderWriter Orders,
    IInvoiceSender InvoiceSender,
    IInvoicePresenter InvoicePresenter);


public static class Composition
{
    private const string ConnectionString =
        "Server=localhost;Database=Orders;Trusted_Connection=True;TrustServerCertificate=True;";

    public static OrderScreenDependencies Default()
    {
        var formatter = new PlainTextInvoiceFormatter();

        var discounts = new DiscountCatalog(new IDiscountStrategy[]
        {
            new NoDiscount(),
            new StudentDiscount(),
            new SeniorDiscount(),
            new BlackFridayDiscount(),
            new FreeShippingDiscount()   
        });

        return new OrderScreenDependencies(
            new OrderTotalCalculator(),
            discounts,
            new SqlOrderRepository(ConnectionString),
            new EmailInvoiceSender(new SmtpSettings("smtp.gmail.com", 587, "store@shop.com"), formatter),
            new MessageBoxInvoicePresenter(formatter));
    }

    
    public static OrderScreenDependencies Offline(FakeOrderRepository repository)
    {
        var formatter = new PlainTextInvoiceFormatter();

        return Default() with
        {
            Orders = repository,
            InvoicePresenter = new MessageBoxInvoicePresenter(formatter)
        };
    }
}
