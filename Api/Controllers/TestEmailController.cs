using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SendGrid;
using SendGridAPI.API.ServiceInterfaces;
using SendGridAPI.Models;
using System.Dynamic;


namespace SendGridAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEmailController : ControllerBase
    {
        private readonly ITestEmailService _emailService;

        public TestEmailController(ITestEmailService emailService)
        {
            _emailService = emailService;

        }

        [HttpPost]
        [Route("send-mail")]
        public async Task<IActionResult> EmailSend([FromBody] TestEmail email)
        {
            var result = await _emailService.SendMailAsync(email.FromEmailAddress, email.ToEmailAddress, email.Subject, email.Content);
            return result.IsSuccessStatusCode ? Ok("Email Send Successfully") : BadRequest("Email Sending Failed");
        }
    }
}
