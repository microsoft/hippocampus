using CsvHelper;
using System.Globalization;
namespace DataApi.helpers;


public class CSVReader
{
    public List<Assets> ReadCSV(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<AssetsMap>();
            var records = csv.GetRecords<Assets>();
            return new List<Assets>(records);
        }
    }
}
