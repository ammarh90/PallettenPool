using SendGrid;

namespace SendGridAPI.API.ServiceInterfaces
{
    public interface ITestEmailService
    {
        Task<Response> SendMailAsync(string fromEmailAddress, string toEmailAddress, string subject, string content);
    }
}
