// Copyright (c) Microsoft. All rights reserved.
using Microsoft.EntityFrameworkCore;
using DataApi.Models;

namespace DataApi.Data;

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

    public DbSet<Asset> Assets { get; set; }

    public DbSet<Order> Sales { get; set; }
}
