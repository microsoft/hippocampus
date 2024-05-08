using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace DataApi.Helpers;

public class CSVReader<TMap> where TMap : ClassMap
{
    public List<T> ReadCSV<T>(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<TMap>();
            var records = csv.GetRecords<T>();
            return new List<T>(records);
        }
    }
}
