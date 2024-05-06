using System.ComponentModel.DataAnnotations;

namespace DataApi.Models;

public class Asset
{
    [Key, Required]
    public int AccountNumber { get; set; }
    public string? AccountName { get; set; }
    public DateTime? InstallDate { get; set; }
    public DateTime? RegisteredDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public string? AssetNumber { get; set; }
    public string? SerialNumber { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? Zipcode { get; set; }
    public string? ProductDescription { get; set; }
    public string? PartNumber { get; set; }
    public string? ProductSegment { get; set; }
    public string? ProductClass { get; set; }
    public string? ProductGroup { get; set; }
    public string? ProductLine { get; set; }
}
