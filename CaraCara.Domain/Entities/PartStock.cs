namespace CaraCara.Domain.Entities;

public class PartStock
{
    public int Id { get; set; }
    public int PartId { get; set; }
    public int WarehouseId { get; set; }
    public int Quantity { get; set; }
    public string LocationCode { get; set; } = string.Empty;

    public virtual Part Part { get; set; } = null!;
    public virtual Warehouse Warehouse { get; set; } = null!;
}
