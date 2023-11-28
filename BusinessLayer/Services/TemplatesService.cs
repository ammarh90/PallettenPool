using Newtonsoft.Json;
using SendGrid;
using SendGridAPI.Api.ServiceInterfaces;
using SendGridAPI.DataLayer.Models;
using SendGridAPI.Models.Response;
using System.Dynamic;

namespace SendGridAPI.BusinessLayer.Services
{
    public class TemplatesService : ITemplatesInterface
    {
        private readonly IConfiguration _configuration;
        private readonly SendGridClient _client;
        public TemplatesService(IConfiguration configuration)
        {
            _configuration = configuration;
            var key = configuration["SendGridApyKey"];
            _client = new SendGridClient("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");
        }
        public async Task<ApiResponse<dynamic>> HandleRequest(BaseClient.Method method, string path, Payload<Dictionary<string, string>> query, CancellationToken cancellationToken = default)
        {
            dynamic jsonObject = new ExpandoObject();
            jsonObject.generations = query.generations;
            jsonObject.pagesize = query.pagesize;
            var response = await _client.RequestAsync(method: method, urlPath: path, cancellationToken: cancellationToken, queryParams: JsonConvert.SerializeObject(jsonObject));
            return new ApiResponse<dynamic>() { Success = response.IsSuccessStatusCode, Payload = await response.Body.ReadAsStringAsync(cancellationToken) };
        }

    }
}
