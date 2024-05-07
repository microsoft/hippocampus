using DataApi.Data;
using DataApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SingletonDatastore>();

// Add sql dbcontext
builder.Services.AddDbContext<SalesDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SalesDbConnection")));

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
app.MapGet("/assets",
    (
        string countryName,
        string accountName,
        string state,
        SalesDb db) =>
{
    var results = db.Assets.AsQueryable();
    if (!string.IsNullOrEmpty(countryName))
    {
        results = results.Where(r => r.Country.ToUpper().Contains(countryName.ToUpper()));
    }
    if (!string.IsNullOrEmpty(accountName))
    {
        results = results.Where(r => r.AccountName.ToUpper().Contains(accountName.ToUpper()));
    }
    if (!string.IsNullOrEmpty(state))
    {
        results = results.Where(r => r.State.ToUpper().Contains(state.ToUpper()));
    }
    return results.ToList();
})
.WithName("GetAllAssets")
.WithSummary("Get a list of all assets")
.WithOpenApi(o =>
{
    o.Parameters[0].Description = "Name of a country to filter the list of assets";
    o.Parameters[1].Description = "Name of an account to filter the list of assets";
    o.Parameters[2].Description = "Name of a state to filter the list of assets";
    return o;
});

app.MapGet("/assets/{accountNumber}", (string accountNumber, SalesDb db) =>
    db.Assets.FirstOrDefault(a => a.AccountNumber.Equals(accountNumber)))
    .WithName("GetAssetsByAccountNumber")
    .WithSummary("Get an asset by account number")
    .WithOpenApi(o =>
    {
        o.Parameters[0].Required = true;
        o.Parameters[0].Description = "Account number of the asset to retrieve";
        o.Parameters[0].In = Microsoft.OpenApi.Models.ParameterLocation.Path;
        return o;
    });

// -- Orders --
app.MapGet("/orders", (SingletonDatastore singletonDatastore) => singletonDatastore.Orders)
    .WithName("GetAllOrders")
    .WithSummary("Get a list of all orders")
    .WithOpenApi();

app.Run();

