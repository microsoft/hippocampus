// Copyright (c) Microsoft. All rights reserved.

using CsvHelper.Configuration;
using DataApi.Models;

namespace DataApi.helpers;

public class ProductMap : ClassMap<Order>
{
    public ProductMap()
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
