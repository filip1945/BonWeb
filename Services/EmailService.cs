using System.Net;
using System.Net.Mail;

namespace BonWeb.Services;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void SendEmail(string name, string email, string phone, string subject, string message)
    {
        var senderEmail = _configuration["EmailSettings:Email"];
        var password = _configuration["EmailSettings:Password"];

        var mail = new MailMessage();

        mail.From = new MailAddress(senderEmail);
        mail.To.Add(senderEmail);
        mail.Subject = subject;

        mail.Body =
            $"Име: {name}\n" +
            $"Email: {email}\n" +
            $"Телефон: {phone}\n\n" +
            $"Порака:\n{message}";

        var smtpClient = new SmtpClient("smtp.gmail.com", 587);

        smtpClient.Credentials = new NetworkCredential(senderEmail, password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);
    }
}