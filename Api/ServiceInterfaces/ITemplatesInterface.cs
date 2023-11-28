using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGridAPI.DataLayer.Models;
using SendGridAPI.Models.Response;

namespace SendGridAPI.Api.ServiceInterfaces
{
    public interface ITemplatesInterface
    {
        Task<ApiResponse<dynamic>> HandleRequest(BaseClient.Method method, string path, Payload<Dictionary<string, string>> query, CancellationToken cancellationToken = default);
    }
}
