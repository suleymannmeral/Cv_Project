using Core_Project;
using System.Net;
using System.Net.Mail;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("lexvon53@gmail.com", "kqsr hnyi lfyn ulrv")
        };

        return client.SendMailAsync(
            new MailMessage(from: "lexvon53@gmail.com",
                            to: email,
                            subject,
                            message
                            ));
    }
}
