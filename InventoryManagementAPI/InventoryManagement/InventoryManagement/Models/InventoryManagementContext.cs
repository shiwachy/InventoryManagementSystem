using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Models;

public partial class InventoryManagementContext : DbContext
{
    public InventoryManagementContext()
    {
    }

    public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblItem> TblItems { get; set; }

    public virtual DbSet<TblStock> TblStocks { get; set; }

    public virtual DbSet<TblStore> TblStores { get; set; }

    public virtual DbSet<TblUsersInfo> TblUsersInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK_tbl_items_1");

            entity.ToTable("tbl_items");

            entity.Property(e => e.ItemId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("itemId");
            entity.Property(e => e.BrandName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("brandName");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("itemCode");
            entity.Property(e => e.ItemName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("itemName");
            entity.Property(e => e.PurchaseRate).HasColumnName("purchaseRate");
            entity.Property(e => e.SalesRate).HasColumnName("salesRate");
            entity.Property(e => e.UnitOfMeasurement)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("unitOfMeasurement");
        });

        modelBuilder.Entity<TblStock>(entity =>
        {
            entity.HasKey(e => e.StockId);

            entity.ToTable("tbl_stock");

            entity.Property(e => e.StockId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("stockId");
            entity.Property(e => e.ExpiaryDate).HasColumnName("expiaryDate");
            entity.Property(e => e.ItemId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("itemId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StoreId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("storeId");

            //entity.HasOne(d => d.Store).WithMany(p => p.TblStocks)
            //    .HasForeignKey(d => d.StoreId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_tbl_stock_tbl_store");
        });

        modelBuilder.Entity<TblStore>(entity =>
        {
            entity.HasKey(e => e.StoreId);

            entity.ToTable("tbl_store");

            entity.Property(e => e.StoreId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("storeId");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.StoreName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("storeName");
        });

        modelBuilder.Entity<TblUsersInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).IsClustered(false);

            entity.ToTable("tbl_usersInfo");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.FullName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
