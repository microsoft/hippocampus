using System;
using System.ComponentModel;
using Microsoft.SemanticKernel;
using Newtonsoft.Json.Linq;

namespace CopilotChat.WebApi.Plugins;

/// <summary>
/// SummarizeData plugin provides a set of functions to do summarization of structured data.
/// </summary>
public sealed class SummarizeData
{
    /// <summary>
    /// Returns the count result of rows in the table provided where the column name provided contains the filtervalue provided.
    /// </summary>
    /// <param name="table">Input table data to perform summary on.</param>
    /// <param name="filtervalue">Filter value to be compared to the values in the provided column.</param>
    /// <param name="column">The column name to perform the filter on to find the table rows to count.</param>
    /// <returns>The resulting count as a string.</returns>
    [KernelFunction, Description("Counts the number of items in a JSON array where the specified property contains the filter value.")]
    [return: Description("The count")]
    public static string CountItemsInJsonArray(
        [Description("the input data")] string jsonArray,
        [Description("the value to filter on")] string filterValue,
        [Description("the property to filter")] string propertyName)
    {
        var count = 0;
        var jArray = JArray.Parse(jsonArray);
        foreach (var item in jArray)
        {
            var propertyValue = item[propertyName]?.ToString();
            if (propertyValue != null && propertyValue.Contains(filterValue, StringComparison.Ordinal))
            {
                count++;
            }
        }
        return count.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }
}