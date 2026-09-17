using System.Net.Mail;
using SolidRefactor.Domain;

namespace SolidRefactor.Invoicing;

public sealed class EmailInvoiceSender : IInvoiceSender
{
    private readonly SmtpSettings _settings;
    private readonly IInvoiceFormatter _formatter;

    public EmailInvoiceSender(SmtpSettings settings, IInvoiceFormatter formatter)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
    }

    public void Send(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        if (string.IsNullOrWhiteSpace(order.CustomerEmail))
            throw new InvalidOperationException("No customer e-mail address was entered.");

        using var smtp = new SmtpClient(_settings.Host, _settings.Port);
        using var mail = new MailMessage(_settings.FromAddress, order.CustomerEmail)
        {
            Subject = _formatter.BuildSubject(order),
            Body = _formatter.BuildBody(order)
        };

        smtp.Send(mail);
    }
}
