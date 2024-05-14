using Microsoft.SemanticKernel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CopilotChat.WebApi.Plugins.Models;
using System.Net.Http.Json;
using System.Net.Http;

namespace CopilotChat.WebApi.Plugins;

/// <summary>
/// DataApi plugin contains functions to fetch data from the Sales API.
/// </summary>
internal sealed class DataApiPlugin
{
    private readonly HttpClient _httpClient;

    internal DataApiPlugin(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    [KernelFunction]
    [Description("List assets belonging to customers from the Sales API.")]
    public async Task<List<Asset>> ListAssetsAsync()
    {
        // Print the asset details to the console
        var resultList = await this._httpClient.GetFromJsonAsync<IList<Asset>>("assets");

        return resultList.Take(25).ToList() ?? new List<Asset>();
    }

    [KernelFunction]
    [Description("List assets for customers located in the specified country.")]
    public async Task<List<Asset>> ListAssetsByCountryAsync(string country)
    {
        // Print the asset details to the console
        var resultList = await this._httpClient.GetFromJsonAsync<IList<Asset>>($"assets?countryName={country}");

        return resultList.ToList() ?? new List<Asset>();
    }

    [KernelFunction]
    [Description("List assets for a customer by the specified account number ID.")]
    public async Task<List<Asset>> ListAssetsByCustomerIdAsync(string accountId)
    {
        // Print the asset details to the console
        var resultList = await this._httpClient.GetFromJsonAsync<IList<Asset>>($"assets/{accountId}");

        return resultList.ToList() ?? new List<Asset>();
    }

    [KernelFunction]
    [Description("List assets for a customer by the specified account name.")]
    public async Task<List<Asset>> ListAssetsByCustomerAccountNameAsync(string accountName)
    {
        // Print the asset details to the console
        var resultList = await this._httpClient.GetFromJsonAsync<IList<Asset>>($"assets?accountName={accountName}");

        return resultList.ToList() ?? new List<Asset>();
    }
}
