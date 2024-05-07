// Copyright (c) Microsoft. All rights reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration;

namespace DataApi.Models;

[Table("Sales")]
public class Order
{
    [Key, Required, Column("Sales Order Number")]
    public string SalesOrderNumber { get; set; }
    [Column("Product Number")]
    public string ProductNumber { get; set; }
    [Column("Product Name")]
    public string ProductName { get; set; }
    [Column("Product Group")]
    public string ProductGroup { get; set; }
    [Column("Prod Sub Type")]
    public string ProdSubType { get; set; }
    [Column("Install Base Trackable Flag")]
    public bool InstallBaseTrackableFlag { get; set; }
    [Column("Product Type")]
    public string ProductType { get; set; }
    [Column("Product Line")]
    public string ProductLine { get; set; }
    [Column("Invoiced Quantity")]
    public int InvoicedQuantity { get; set; }
    [Column("Invoiced Amount")]
    public decimal InvoicedAmount { get; set; }
    [Column("Ship To Location Country Name")]
    public string ShipToLocationCountryName { get; set; }
    [Column("Prod Segment")]
    public string ProdSegment { get; set; }
    [Column("Customer Name")]
    public string CustomerName { get; set; }
    [Column("Customer Number")]
    public string CustomerNumber { get; set; }
    [Column("Quarter")]
    public string Quarter { get; set; }
    [Column("Year")]
    public int Year { get; set; }
}

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
