using ChillLancer.API;
using ChillLancer.API.Middlewares;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Services;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();



var logger = LoggerFactory.Create(loggingBuilder => loggingBuilder.AddConsole()).CreateLogger<Program>();
// Add services to the container.
builder.Services.DependencyInjectionServices(builder.Configuration);
logger.LogInformation("Logging configuration sources and values:");
var configurationRoot = (IConfigurationRoot)builder.Configuration;
foreach (var provider in configurationRoot.Providers)
{
    if (provider.TryGet("ConnectionStrings:DatabaseConnection", out var value))
    {
        logger.LogInformation("Provider: {Provider}, ConnectionStrings:DatabaseConnection: {Value}", provider, value);
    }
}
builder.Services.AddControllers()
    // Add OData
    .AddOData(options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100));
 //   .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//log odata
builder.Logging.AddFilter("Microsoft.AspNetCore.OData", LogLevel.Debug);
builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Debug);
builder.Logging.AddFilter("Microsoft.AspNetCore.OData", LogLevel.Trace);
builder.Logging.AddFilter("Microsoft.OData", LogLevel.Debug);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Allow all http
app.UseCors("AllowAll");
//app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
