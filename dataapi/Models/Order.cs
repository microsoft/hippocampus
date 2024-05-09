// Copyright (c) Microsoft. All rights reserved.
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;

namespace DataApi.Models;

/// <summary>
/// Data model for SalesOrder items from sales table.
/// </summary>
[Table("Sales")]
public class Order
{
    [Key, Required, Column("Sales Order Number")]
    [Description("A unique identifier for each sales transaction. This number is used to track the order through fulfillment and billing.")]
    public long SalesOrderNumber { get; set; }

    [Column("Product Number")]
    [Description("A unique identifier representing a given product.")]
    public string ProductNumber { get; set; }

    [Column("Product Name")]
    [Description("Name of the product. This includes products which either the company or its partners manufacture. Some product names represent components or parts of a larger system. Some products also indicate how many pieces there are, suck as 10pk or 5pcs. This should not be confused with products which numerically indicate clinical details, such as '64-channel' products of various types, or 'Pin Box 193-256' which would be purchased by a customer who clearly has/uses up to 256-channel systems.")]
    public string ProductName { get; set; }

    [Column("Product Group")]
    [Description("A portfolio category that the product belongs to, such as EEG, PMSD, EMG, IOM, aEEG, PSG, TCD, SPG, Neurocritical Care, Neurosurgery, Positioning, ICU.")]
    public string ProductGroup { get; set; }

    [Column("Prod Sub Type")]
    [Description("A more specific classification within the product group, which should be one of: Replacement Part, Servers, Service, Service Calibration, Service Contracts, Service Fees, Service Install, Service Refurbished, Service Repair, Service SWAP, Service Training, Shunts, Software, Software - Review, Software - Third Party, Software Upgrade, System, Third Party, Training, Upgrade.")]
    public string ProdSubType { get; set; }

    [Column("Install Base Trackable Flag")]
    [Description("Yes or No indicating whether a product is also able to be tracked in the asset data export contained in the asset spreadsheet, not to be confused with this sales transaction spreadsheet.")]
    public bool InstallBaseTrackableFlag { get; set; }

    [Column("Product Type")]
    [Description("Product high-level category, one of: Devices, Services, Supplies, Freight.")]
    public string ProductType { get; set; }

    [Column("Product Line")]
    [Description("Each product is part of a larger product line, which in some cases takes the name of a company which has previously been acquired and whose devices or software are supported. This may also include both a brand name and a device or application name, such as 'Contoso EEG' or 'Contoso EEG/PSG' which may apply to multiple device or application types. Other Product Lines are simply denoted by their function, such as 'Cannulas' or 'Gels' or 'PSG Supplies'.")]
    public string ProductLine { get; set; }

    [Column("Invoiced Quantity")]
    [Description("The number of units of the product sold for a given transaction.")]
    public decimal InvoicedQuantity { get; set; }

    [Column("Invoiced Amount")]
    [Description("The total amount billed to the customer for the products in the sales order. This is a sensitive column, so we will fill it with random values or leave this out during collaboration, and potentially include it in our final deliverables.")]
    public decimal InvoicedAmount { get; set; }

    [Column("Ship To Location Country Name")]
    [Description("The country to which the products were shipped.")]
    public string ShipToLocationCountryName { get; set; }

    [Column("Prod Segment")]
    [Description("Currently all 'Neuro' since we are working with only one product segment. There are currently no other product segments used.")]
    public string ProdSegment { get; set; }

    [Column("Customer Name")]
    [Description("The name of the entity who purchased the products.")]
    public string CustomerName { get; set; }

    [Column("Customer Number")]
    [Description("A unique identifier assigned to each customer. It's used internally to track all transactions associated with a specific customer, however some customers have merged or split over the years, which can make tracking them over time a bit difficult.")]
    public int CustomerNumber { get; set; }

    [Column("Quarter")]
    [Description("The fiscal quarter in which the transaction occurred.")]
    public string Quarter { get; set; }

    [Column("Year")]
    [Description("The calendar year in which the sales transaction took place.")]
    public short Year { get; set; }
}

[Obsolete("Only used for CSV mapping.")]
public class OrdersMap : ClassMap<Order>
{
    public OrdersMap()
    {
        this.Map(m => m.ProductNumber).Name("Product Number");
        this.Map(m => m.ProductName).Name("Product Name");
        this.Map(m => m.ProductGroup).Name("Product Group");
        this.Map(m => m.ProdSubType).Name("Prod Sub Type");
        this.Map(m => m.InstallBaseTrackableFlag).Name("Install Base Trackable Flag");
        this.Map(m => m.ProductType).Name("Product Type");
        this.Map(m => m.ProductLine).Name("Product Line");
        this.Map(m => m.SalesOrderNumber).Name("Sales Order Number");
        this.Map(m => m.InvoicedQuantity).Name("Invoiced Quantity");
        this.Map(m => m.InvoicedAmount).Name("Invoiced Amount");
        this.Map(m => m.ShipToLocationCountryName).Name("Ship To Location Country Name");
        this.Map(m => m.ProdSegment).Name("Prod Segment");
        this.Map(m => m.CustomerName).Name("Customer Name");
        this.Map(m => m.CustomerNumber).Name("Customer Number");
        this.Map(m => m.Quarter).Name("Quarter");
        this.Map(m => m.Year).Name("Year");
    }
}
