using DataApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SingletonDatastore>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GetDataAPI", Version = "v1" });

    // Add a server
    c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
    {
        //Url = "https://hippodataapi.azurewebsites.net/"
        Url = "https://localhost:7115"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// ------ Minimal API Routes -------
// -- Assets --
app.MapGet("/assets", (string countryName, string accountName, SingletonDatastore singletonAssets) =>
{
    var results = singletonAssets.Assets;
    if (!string.IsNullOrEmpty(countryName))
    {
        results = results.Where(r => r.Country.Contains(countryName, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    if (!string.IsNullOrEmpty(accountName))
    {
        results = results.Where(r => r.AccountName.Contains(accountName, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    return results;
})
.WithName("GetAllAssets")
.WithSummary("Get a list of all assets")
.WithOpenApi(o =>
{
    var countryParam = o.Parameters[0];
    countryParam.Description = "Name of a country to filter the list of assets";

    o.Parameters[1].Description = "Name of an account to filter the list of assets";
    return o;
});

app.MapGet("/assets/{accountNumber}", (int accountNumber, SingletonDatastore singletonAssets) =>
    singletonAssets.Assets.Where(a => a.AccountNumber == accountNumber).ToList())
    .WithName("GetAssetsByAccountNumber")
    .WithSummary("Get an asset by account number")
    .WithOpenApi();

// -- Orders --
app.MapGet("/orders", (SingletonDatastore singletonDatastore) => singletonDatastore.Orders)
    .WithName("GetAllOrders")
    .WithSummary("Get a list of all orders")
    .WithOpenApi();

app.Run();

