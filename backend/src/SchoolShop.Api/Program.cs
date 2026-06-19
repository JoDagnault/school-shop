using SchoolShop.Api.Errors;
using SchoolShop.Application;
using SchoolShop.Api.SupplyLists;
using SchoolShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseErrorHandling();

app.MapSupplyListsEndpoints();

app.Run();

public partial class Program;
