using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class TblStock
{
    public string StockId { get; set; } = null!;

    public string StoreId { get; set; } = null!;

    public string ItemId { get; set; } = null!;

    public int Quantity { get; set; }

    public string ExpiaryDate { get; set; }

    //public virtual TblStore Store { get; set; } = null!;
}
