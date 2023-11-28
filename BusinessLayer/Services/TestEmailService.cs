using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridAPI.API.ServiceInterfaces;

namespace SendGridAPI.BL.Services
{
    public class TestEmailService : ITestEmailService
    {
        private readonly IConfiguration _configuration;
        public TestEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response> SendMailAsync(string fromEmailAddress, string toEmailAddress, string subject, string content)
        {
            var apiKey = _configuration["SendGridApyKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ammar.hakanovic@gmail.com", "arabstyleofficial");
            var to = new EmailAddress(toEmailAddress);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }
}
