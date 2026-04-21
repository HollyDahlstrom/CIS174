using Microsoft.AspNetCore.Identity.UI.Services;

namespace Ch04MovieListDahlstrom.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Fake email sender for development
            return Task.CompletedTask;
        }
    }
}