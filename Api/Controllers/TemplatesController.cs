using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SendGrid;
using SendGridAPI.Api.ServiceInterfaces;
using SendGridAPI.DataLayer.Models;
using SendGridAPI.Models.Response;
using System.Net;

namespace SendGridAPI.Api.Controllers
{
    public class TemplatesController : Controller
    {
        private readonly ITemplatesInterface _apiClient;
        public TemplatesController(ITemplatesInterface apiClient)
        {
            _apiClient = apiClient;
        }
        [HttpGet]
        [Route("/api/v1/templates")]
        [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTemplatesListAsync(CancellationToken cancellationToken, Payload<Dictionary<string, string>> query)
        {
            var payload = await _apiClient.HandleRequest(BaseClient.Method.GET, "templates", query, cancellationToken);

            return payload.Success ? Ok(new ApiResponse<TemplatesResult>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<TemplatesResult>(payload.Payload) }) : BadRequest(payload);
        }
    }
}