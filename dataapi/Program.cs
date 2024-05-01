using DataApi.helpers;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


CSVReader _csvReader = new();
var assets = _csvReader.ReadCSV("files/assets.csv");


app.MapGet("/assets", () => assets)
.WithName("GetAllAssets")
.WithOpenApi();

app.MapGet("/assets/{id}", (int? id) =>
{
    if (id.HasValue)
    {
        assets = assets.Where(a => a.AccountNumber == id.Value).ToList();
    }

    return Results.Ok(assets);
})
.WithName("GetAssetsByAccountNumber")
.WithOpenApi();

app.Run();
