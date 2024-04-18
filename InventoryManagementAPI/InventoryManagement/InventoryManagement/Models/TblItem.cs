using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class TblItem
{
    public string ItemId { get; set; } = null!;

    public string ItemCode { get; set; } = null!;

    public string ItemName { get; set; } = null!;

    public string? BrandName { get; set; }

    public string UnitOfMeasurement { get; set; } = null!;

    public int PurchaseRate { get; set; }

    public int SalesRate { get; set; }

    public bool IsActive { get; set; }
}
