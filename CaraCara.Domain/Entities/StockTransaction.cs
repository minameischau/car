using System;

namespace CaraCara.Domain.Entities;

public class StockTransaction
{
    public int Id { get; set; }
    public int PartId { get; set; }
    public int WarehouseId { get; set; }
    public string Type { get; set; } = string.Empty; // In | Out | Adjust
    public int Quantity { get; set; }
    public int? RelatedServiceOrderId { get; set; }
    public DateTime CreatedDate { get; set; }

    public virtual Part Part { get; set; } = null!;
    public virtual Warehouse Warehouse { get; set; } = null!;
}
