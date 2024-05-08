// Copyright (c) Microsoft. All rights reserved.
using Microsoft.EntityFrameworkCore;
using DataApi.Models;

namespace DataApi.Data;

/// <summary>
/// DbContext class for SalesDb database
/// </summary>
public class SalesDb : DbContext
{
    public SalesDb(DbContextOptions<SalesDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>().ToTable("Assets");
        modelBuilder.Entity<Order>().ToTable("Sales");
    }

    /// <summary>
    /// Assets table
    /// </summary>
    public DbSet<Asset> Assets { get; set; }

    /// <summary>
    /// Sales table
    /// </summary>
    public DbSet<Order> Sales { get; set; }
}
