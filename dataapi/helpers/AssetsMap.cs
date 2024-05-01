using CsvHelper.Configuration;

namespace DataApi.helpers;

public class AssetsMap : ClassMap<Assets>
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
