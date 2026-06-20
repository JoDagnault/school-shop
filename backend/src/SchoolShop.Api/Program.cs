using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SchoolShop.Api.Errors;
using SchoolShop.Api.SupplyLists;
using SchoolShop.Application;
using SchoolShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    // Keep generated numeric schemas compatible with Swagger UI. See docs/adr/0001-strict-json-number-handling.md.
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
var dbContext = scope.ServiceProvider.GetRequiredService<SchoolShopDbContext>();
await dbContext.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "School Shop API");
    });
}

app.UseErrorHandling();

app.MapSupplyListsEndpoints();

app.Run();

public partial class Program;
