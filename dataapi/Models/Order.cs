// Copyright (c) Microsoft. All rights reserved.

namespace DataApi.Models;

public class Order
{
    public string ProductNumber { get; set; }
    public string ProductName { get; set; }
    public string ProductGroup { get; set; }
    public string ProdSubType { get; set; }
    public bool InstallBaseTrackableFlag { get; set; }
    public string ProductType { get; set; }
    public string ProductLine { get; set; }
    public string SalesOrderNumber { get; set; }
    public int InvoicedQuantity { get; set; }
    public decimal InvoicedAmount { get; set; }
    public string ShipToLocationCountryName { get; set; }
    public string ProdSegment { get; set; }
    public string CustomerName { get; set; }
    public string CustomerNumber { get; set; }
    public string Quarter { get; set; }
    public int Year { get; set; }
}
