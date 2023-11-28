using FluentValidation;
using FluentValidation.AspNetCore;
using SendGridAPI.Api.ServiceInterfaces;
using SendGridAPI.API.ServiceInterfaces;
using SendGridAPI.BL.Services;
using SendGridAPI.BusinessLayer.Services;
using SendGridAPI.Models;
using SendGridAPI.Validators;
using System.Configuration;
#pragma warning disable CS0618

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMvc();
// Add services to the container.
builder.Services.AddFluentValidationAutoValidation();
// add the Seq logging configuration 
builder.Host.ConfigureLogging(loggingBuilder =>
    loggingBuilder.AddSeq(builder.Configuration.GetSection("Seq")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//registration service
builder.Services.AddScoped<ITestEmailService, TestEmailService>();
builder.Services.AddScoped<ISendGridApiClient, SendGridApiClientService>();
builder.Services.AddScoped<ITemplatesInterface, TemplatesService>();
builder.Services.AddScoped<IValidator<MarketingListDto>, CustomerValidator>();

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.Run();
