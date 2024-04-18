using System;
using System.Collections.Generic;

namespace InventoryManagement.Models;

public partial class TblStore
{
    public string StoreId { get; set; } = null!;

    public string StoreName { get; set; } = null!;

    public bool IsActive { get; set; }

    //public virtual ICollection<TblStock> TblStocks { get; set; } = new List<TblStock>();
}
