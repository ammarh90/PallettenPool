using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SendGrid;
using SendGridAPI.Api.ServiceInterfaces;
using SendGridAPI.DataLayer.Models;
using SendGridAPI.DataLayer.Models.Response;
using SendGridAPI.Models;
using SendGridAPI.Models.Response;
using SendGridAPI.Validators;
using System.Dynamic;
using System.Net;
using Root = SendGridAPI.Models.Root;

namespace SendGridAPI.API.Controllers;

public class MarketingController : Controller
{
    private readonly ISendGridApiClient _apiClient;
    private readonly ILogger<MarketingController> _logger;

    public MarketingController(ISendGridApiClient apiClient, ILogger<MarketingController> logger)
    {
        _apiClient = apiClient;
        _logger = logger;
    }

    [HttpGet]
    [Route("/api/v1/marketing/lists")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAllListsAsync(CancellationToken cancellation)
    {
        var payload = await _apiClient.HandleRequest(BaseClient.Method.GET, "marketing/lists", null, null, cancellation);
        return payload.Success ? Ok(new ApiResponse<Root>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<Root>(payload.Payload) }) : BadRequest(payload);
    }

    [HttpGet]
    [Route("/api/v1/marketing/lists/{id}")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetListAsyncByID(CancellationToken cancellation, string id)
    {
        var payload = await _apiClient.HandleRequest(BaseClient.Method.GET, $"marketing/lists/{id}", null, null, cancellation);
        return payload.Success ? Ok(new ApiResponse<ResultContact.Root>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<ResultContact.Root>(payload.Payload) }) : BadRequest(payload);
    }

    [HttpPost]
    [Route("/api/v1/marketing/lists")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateListAsync(CancellationToken cancellation, [FromBody] MarketingListDto marketingList)
    {
        _logger.LogInformation("CreateListAsync from MarketingController called");

        CustomerValidator validator = new CustomerValidator();
        FluentValidation.Results.ValidationResult results = validator.Validate(marketingList);

        if (!results.IsValid)
        {
            return BadRequest(results.Errors);
        }

        dynamic jsonObject = new ExpandoObject();
        jsonObject.name = marketingList.Name;
        var payload = await _apiClient.HandleRequest(BaseClient.Method.POST, "marketing/lists", null, JsonConvert.SerializeObject(jsonObject), cancellation);
        return Ok(new ApiResponse<Result>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<Result>(payload.Payload) });

    }

    [HttpPatch]
    [Route("/api/v1/marketing/lists/{id}")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateListAsync(CancellationToken cancellation, string id, [FromBody] MarketingListDto marketingList)
    {
        _logger.LogInformation("UpdateListAsync from MarketingController called");

        CustomerValidator validator = new CustomerValidator();
        FluentValidation.Results.ValidationResult results = validator.Validate(marketingList);

        if (!results.IsValid)
        {
            return BadRequest(results.Errors);
        }

        dynamic jsonObject = new ExpandoObject();
        jsonObject.name = marketingList.Name;
        var payload = await _apiClient.HandleRequest(BaseClient.Method.PATCH, $"marketing/lists/{id}", null, JsonConvert.SerializeObject(jsonObject), cancellation);
        return Ok(new ApiResponse<Result>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<Result>(payload.Payload) });
    }


    [HttpDelete]
    [Route("/api/v1/marketing/delete-list/{id}")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteListAsync(CancellationToken cancellation, string id)
    {
        var payload = await _apiClient.HandleRequest(BaseClient.Method.DELETE, $"marketing/lists/{id}", null, null, cancellation);
        return payload.Success ? Ok(payload) : BadRequest(payload);
    }

    [HttpPost]
    [Route("/api/v1/marketing/contacts")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<List<Contact>>> CreateContanct(CancellationToken cancellation, [FromBody] ContactPayload contactPayload)
    {
        return Ok(await _apiClient.CreateContactsAsync(cancellation, contactPayload));
    }

    [HttpGet]
    [Route("/api/v1/marketing/contacts")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetContact(CancellationToken cancellation)
    {

        var payload = await _apiClient.HandleRequest(BaseClient.Method.GET, $"marketing/contacts", null, null, cancellation);
        return payload.Success ? Ok(new ApiResponse<ResultContact.Root>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<ResultContact.Root>(payload.Payload) }) : BadRequest(payload);
    }


    [HttpGet]
    [Route("/api/v1/marketing/contacts/{id}")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetContactById(CancellationToken cancellation, string id)
    {

        var payload = await _apiClient.HandleRequest(BaseClient.Method.GET, $"marketing/contacts/{id}", null, null, cancellation);
        return payload.Success ? Ok(new ApiResponse<ResultContact.Result>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<ResultContact.Result>(payload.Payload) }) : BadRequest(payload);
    }

    //view status contact
    [HttpGet]
    [Route("/api/v1/marketing/contacts/imports/{id}")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetContactStatus(CancellationToken cancellation, string id)
    {

        var payload = await _apiClient.HandleRequest(BaseClient.Method.GET, $"marketing/contacts/imports/{id}", null, null, cancellation);
        return payload.Success ? Ok(new ApiResponse<ImportContactStatus>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<ImportContactStatus>(payload.Payload) }) : BadRequest(payload);
    }

    //to check
    //delete one contacnt
    [HttpDelete]
    [Route("/api/v1/marketing/contacts")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteContactFromListAsync(CancellationToken cancellation, string query)
    {
        dynamic deleteParam = new ExpandoObject();
        deleteParam.ids = query; 

        var payload = await _apiClient.HandleRequest(BaseClient.Method.DELETE, $"marketing/contacts", JsonConvert.SerializeObject(deleteParam), null, cancellation);
        return payload.Success ? Ok(payload) : BadRequest(payload);
    }

    [HttpDelete]
    [Route("/api/v1/marketing/lists/{id}/contacts")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteContactFromListById(CancellationToken cancellation, string id)
    {
        dynamic deleteParam = new ExpandoObject();
        deleteParam.ids = id;

        var payload = await _apiClient.HandleRequest(BaseClient.Method.DELETE, $"marketing/lists/{id}/contacts", JsonConvert.SerializeObject(deleteParam), null, cancellation);
        return payload.Success ? Ok(payload) : BadRequest(payload);
    }



    [HttpPost]
    [Route("/api/v1/marketing/singlesends")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateSingleSendAsync(CancellationToken cancellation, [FromBody] SingleSendDto.Root singleSend)
    {
        dynamic jsonObject = new ExpandoObject();
        jsonObject.name = singleSend.Name;
        var payload = await _apiClient.HandleRequest(BaseClient.Method.POST, "marketing/singlesends", null, JsonConvert.SerializeObject(jsonObject), cancellation);
        return Ok(new ApiResponse<SingleSendDto.Root>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<SingleSendDto.Root>(payload.Payload) });

    }

    [HttpPost]
    [Route("/api/v1/marketing/singlesends/{id}")]
    [ProducesResponseType(typeof(ApiResponse<dynamic>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<EmptyResult>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DuplicateSingleSendAsync(CancellationToken cancellation, [FromBody] SingleSendDto.Root duplicateName, string id)
    {
        dynamic jsonObject = new ExpandoObject();
        jsonObject.name = duplicateName.Name;
        var payload = await _apiClient.HandleRequest(BaseClient.Method.POST, $"marketing/singlesends/{id}", null, JsonConvert.SerializeObject(jsonObject), cancellation);
        return Ok(new ApiResponse<SingleSendDto.Root>() { Success = payload.Success, Payload = JsonConvert.DeserializeObject<SingleSendDto.Root>(payload.Payload) });

    }

}