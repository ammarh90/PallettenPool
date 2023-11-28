using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGridAPI.DataLayer.Models;
using SendGridAPI.Models.Response;

namespace SendGridAPI.Api.ServiceInterfaces;

public interface ISendGridApiClient
{
    Task<ApiResponse<dynamic>> HandleRequest(BaseClient.Method method, string path, string param = null, string body = null, CancellationToken cancellationToken = default);
    Task<dynamic> CreateContactsAsync(CancellationToken cancellationToken, ContactPayload contactPayload);
}