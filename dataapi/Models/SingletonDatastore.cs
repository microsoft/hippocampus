using DataApi.Helpers;

namespace DataApi.Models;

public class SingletonDatastore
{
    public List<Asset> Assets { get; private set; }
    public List<Order> Orders { get; private set; }

    public SingletonDatastore()
    {
        DataApi.Helpers.CSVReader<AssetsMap> _assetReader = new();
        DataApi.Helpers.CSVReader<AssetsMap> _orderReader = new();
        this.Assets = _assetReader.ReadCSV<Asset>("Files/neuro_assets_sample.csv");
        this.Orders = _orderReader.ReadCSV<Order>("Files/neuro_sales_unique.csv");
    }
}
