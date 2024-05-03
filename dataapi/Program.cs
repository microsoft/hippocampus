//using Microsoft.AspNetCore.OData;
//using Microsoft.OData.ModelBuilder;
using DataApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SingletonAssets>();

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

//app.UseEndpoints(endpoints => endpoints.MapControllers());


app.MapGet("/assets", (SingletonAssets singletonAssets) => singletonAssets.Assets)
.WithName("GetAllAssets")
.WithOpenApi();

app.MapGet("/assetsByAccountName", (string accountName, SingletonAssets singletonAssets) =>
{
    var results = singletonAssets.Assets.Where(a => a.AccountName.Contains(accountName, StringComparison.OrdinalIgnoreCase)).ToList();
    return results;
})
    .WithName("GetAssetsByAccountName")
    .WithOpenApi();

app.MapGet("/assetsByCountry", (string countryName, SingletonAssets singletonAssets) =>
{
    var results = singletonAssets.Assets.Where(a => a.Country.Contains(countryName, StringComparison.OrdinalIgnoreCase)).ToList();
    return results;
})
    .WithName("GetAssetsByCountry")
    .WithOpenApi();

app.MapGet("/assets/{accountNumber}", (int accountNumber, SingletonAssets singletonAssets) =>
{
    //if (accountNumber.HasValue)
    //{
    var assets = singletonAssets.Assets.Where(a => a.AccountNumber == accountNumber).ToList();
    //}

    return Results.Ok(assets);
})
.WithName("GetAssetsByAccountNumber")
.WithOpenApi();

app.Run();

