using CsvHelper;
using DataApi.Models;
using System.Globalization;
namespace DataApi.Helpers;


public class CSVReader
{
    public List<Asset> ReadCSV(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<AssetsMap>();
            var records = csv.GetRecords<Asset>();
            return new List<Asset>(records);
        }
    }
}
