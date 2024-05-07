using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;

namespace DataApi.Models;

public class Asset
{
    [Key, Required, Column("ACCOUNT_NUMBER")]
    public string AccountNumber { get; set; }
    [Column("ACCOUNT_NAME")]
    [Description("The account name for the customer who owns this asset.")]
    public string AccountName { get; set; }
    [Column("INSTALL_DATE")]
    public DateTime? InstallDate { get; set; }
    [Column("REGISTERED_DATE")]
    public DateTime? RegisteredDate { get; set; }
    [Column("SHIP_DATE")]
    public DateTime? ShipDate { get; set; }
    [Column("ASSET_NUMBER")]
    public string AssetNumber { get; set; }
    [Column("SERIAL_NUMBER")]
    public string SerialNumber { get; set; }
    [Column("ADDR_LINE_1")]
    public string AddressLine1 { get; set; }
    [Column("ADDR_LINE_1_1")]
    public string AddressLine2 { get; set; }
    [Column("CITY")]
    public string City { get; set; }
    [Column("COUNTRY")]
    public string Country { get; set; }
    [Column("STATE")]
    public string State { get; set; }
    [Column("ZIPCODE")]
    public string Zipcode { get; set; }
    [Column("PRODUCT_DESC")]
    public string ProductDescription { get; set; }
    [Column("PART_NUM")]
    public string PartNumber { get; set; }
    [Column("PROD_SEGMENT")]
    public string ProductSegment { get; set; }
    [Column("PROD_CLASS")]
    public string ProductClass { get; set; }
    [Column("PROD_GROUP")]
    public string ProductGroup { get; set; }
    [Column("PROD_LINE")]
    public string ProductLine { get; set; }
}

public class AssetsMap : ClassMap<Asset>
{
    public AssetsMap()
    {
        this.Map(m => m.AccountNumber).Name("ACCOUNT_NUMBER");
        this.Map(m => m.AccountName).Name("ACCOUNT_NAME");
        this.Map(m => m.InstallDate).Name("INSTALL_DATE");
        this.Map(m => m.RegisteredDate).Name("REGISTERED_DATE");
        this.Map(m => m.ShipDate).Name("SHIP_DATE");
        this.Map(m => m.AssetNumber).Name("ASSET_NUMBER");
        this.Map(m => m.SerialNumber).Name("SERIAL_NUMBER");
        this.Map(m => m.AddressLine1).Name("ADDR_LINE_1");
        this.Map(m => m.AddressLine2).Name("ADDR_LINE_1_1");
        this.Map(m => m.City).Name("CITY");
        this.Map(m => m.Country).Name("COUNTRY");
        this.Map(m => m.State).Name("STATE");
        this.Map(m => m.Zipcode).Name("ZIPCODE");
        this.Map(m => m.ProductDescription).Name("PRODUCT_DESC");
        this.Map(m => m.PartNumber).Name("PART_NUM");
        this.Map(m => m.ProductSegment).Name("PROD_SEGMENT");
        this.Map(m => m.ProductClass).Name("PROD_CLASS");
        this.Map(m => m.ProductGroup).Name("PROD_GROUP");
        this.Map(m => m.ProductLine).Name("PROD_LINE");
    }
}
