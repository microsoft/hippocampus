using DataApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Uncomment the following line to use local CSV files
// builder.Services.AddSingleton<SingletonDatastore>();

//var modelBuilder = new ODataConventionModelBuilder();
//modelBuilder.EntitySet<Asset>("Assets");

//builder.Services.AddControllers().AddOData(
//    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
//        "odata",
//        modelBuilder.GetEdmModel()));

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

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseRouting();

// GET /assets - Get a list of all assets with optional query params
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
.WithOpenApi();

app.MapGet("/assetsByAccountName", (string accountName, SingletonAssets singletonAssets) =>
{
    var results = singletonAssets.Assets.Where(a => a.AccountName.Contains(accountName, StringComparison.OrdinalIgnoreCase)).ToList();
    return results;
})
    .WithName("GetAssetsByAccountName")
    .WithOpenApi();

// GET /assets/{accountNumber} - Get an asset by account number
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

// GET /orders - Get a list of all orders
app.MapGet("/orders", async (SalesDb db) =>
{
    var results = await db.Sales.ToListAsync();
    return results.Take(100);
})
    .WithName("GetAllOrders")
    .WithSummary("Get a list of all orders")
    .WithOpenApi();

// GET /orders/{salesOrderNumber} - Get an order by sales order number
app.MapGet("/orders/{salesOrderNumber}", (long salesOrderNumber, SalesDb db) =>
    db.Sales.FirstOrDefault(o => o.SalesOrderNumber == salesOrderNumber))
    .WithName("GetOrderBySalesOrderNumber")
    .WithSummary("Get an order by sales order number")
    .WithOpenApi(o =>
    {
        o.Parameters[0].Required = true;
        o.Parameters[0].Description = "Sales order number of the order to retrieve";
        o.Parameters[0].In = Microsoft.OpenApi.Models.ParameterLocation.Path;
        return o;
    });

app.Run();

