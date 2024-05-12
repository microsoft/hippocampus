using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CopilotChat.WebApi.Plugins.Models;

/// <summary>
/// Model class for Asset items.
/// </summary>
public class Asset
{
    [Key, Required, Column("ACCOUNT_NUMBER")]
    [Description("A unique identifier assigned to each customer. It's used internally to track all transactions associated with a specific customer, however some customers have merged or split over the years, which can make tracking them over time a bit difficult.")]
    public string AccountNumber { get; set; }

    [Column("ACCOUNT_NAME")]
    [Description("The name of the entity who purchased the products.")]
    public string AccountName { get; set; }
    [Column("INSTALL_DATE")]
    [Description("The date the purchased products or systems were installed at the customer site.")]
    public DateTime? InstallDate { get; set; }

    [Column("REGISTERED_DATE")]
    [Description("The date the products or systems were registered as belonging to the customer.")]
    public DateTime? RegisteredDate { get; set; }

    [Column("SHIP_DATE")]
    [Description("The date the products were shipped to the customer.")]
    public DateTime? ShipDate { get; set; }

    [Column("ASSET_NUMBER")]
    [Description("A unique asset number similar to a serial number but for tracking all assets including those which do and do not have serial numbers formally defined.")]
    public string AssetNumber { get; set; }

    [Column("SERIAL_NUMBER")]
    [Description("A unique identifier for an asset. Not all assets have serial numbers, such as consumables and disposable supplies for example.")]
    public string SerialNumber { get; set; }

    [Column("ADDR_LINE_1")]
    [Description("The customer address line 1.")]
    public string AddressLine1 { get; set; }

    [Column("ADDR_LINE_1_1")]
    [Description("The customer address line 1 additional info or ATTN attention.")]
    public string AddressLine2 { get; set; }

    [Column("CITY")]
    [Description("Customer city.")]
    public string City { get; set; }

    [Column("COUNTRY")]
    [Description("Customer country.")]
    public string Country { get; set; }

    [Column("STATE")]
    [Description("Contain a mix of state abbreviations from the United States, as well as abbreviations representing regions or provinces from other countries.")]
    public string State { get; set; }

    [Column("ZIPCODE")]
    [Description("Customer zip code.")]
    public string Zipcode { get; set; }

    [Column("PRODUCT_DESC")]
    [Description("Human readable description of the product or part.")]
    public string ProductDescription { get; set; }

    [Column("PART_NUM")]
    [Description("Unique identifier for a product which can be ordered by a customer.")]
    public string PartNumber { get; set; }

    [Column("PROD_SEGMENT")]
    [Description("Currently all 'Neuro' since we specifically exported Neuro data. There are currently no other product segments.")]
    public string ProductSegment { get; set; }

    [Column("PROD_CLASS")]
    [Description("A subdivision of the product segment such as 'Infection Control' which is a subdivision of the Neuro product segment.")]
    public string ProductClass { get; set; }

    [Column("PROD_GROUP")]
    [Description("A portfolio category that the product belongs to, such as EEG, EMG, IOM, PSG, Neurocritical Care.")]
    public string ProductGroup { get; set; }

    [Column("PROD_LINE")]
    [Description("Each product is part of a larger product line, which in some cases takes the name of a company which has previously been acquired and whose devices or software are supported. This may also include both a brand name and a device or application name, such as 'Contoso EEG' or 'Contoso EEG/PSG' which may apply to multiple device or application types. Other Product Lines are simply denoted by their function, such as 'Cannulas' or 'Gels' or 'PSG Supplies'.")]
    public string ProductLine { get; set; }
}
