namespace SolidRefactor.Invoicing;

public sealed record SmtpSettings(string Host, int Port, string FromAddress);
