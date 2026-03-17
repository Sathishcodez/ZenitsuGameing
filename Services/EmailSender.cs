using Microsoft.AspNetCore.Identity.UI.Services;

namespace ZenitsuGameing.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // TODO: Implement actual email sending logic here
            // For now, this is a placeholder that does nothing
            // In production, you would integrate with SendGrid, SMTP, or another email service
            
            Console.WriteLine($"Email sent to: {email}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {htmlMessage}");
            
            return Task.CompletedTask;
        }
    }
}
