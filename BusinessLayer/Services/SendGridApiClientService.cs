using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SendGrid;
using SendGridAPI.Api.ServiceInterfaces;
using SendGridAPI.DataLayer.Models;
using SendGridAPI.Models.Response;

namespace SendGridAPI.BusinessLayer.Services;

public class SendGridApiClientService : ISendGridApiClient
{
    private readonly IConfiguration _configuration;
    private readonly SendGridClient _client;
    public SendGridApiClientService(IConfiguration configuration)
    {
        _configuration = configuration;
        var key = configuration["SendGridApyKey"];
        _client = new SendGridClient("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");
    }

    public async Task<ApiResponse<dynamic>> HandleRequest(BaseClient.Method method, string path, string param = null, string body = null, CancellationToken cancellationToken = default)
    {
        var response = await _client.RequestAsync(method: method, urlPath: path, cancellationToken: cancellationToken, requestBody: body, queryParams: param).ConfigureAwait(false);
        return new ApiResponse<dynamic>() { Success = response.IsSuccessStatusCode, Payload = await response.Body.ReadAsStringAsync(cancellationToken) };
    }

    public async Task<dynamic> CreateContactsAsync(CancellationToken cancellationToken, ContactPayload contactPayload)
    {
        var response = await _client.RequestAsync(method: SendGridClient.Method.PUT, urlPath: "marketing/contacts", cancellationToken: cancellationToken, requestBody: JsonConvert.SerializeObject(contactPayload));
        if (response.IsSuccessStatusCode)
        {
            return await response.Body.ReadAsStringAsync();

        }
        throw new Exception();

    
    }
}