namespace CaraCara.Domain.Entities;

public class ServicePartUsage
{
    public int Id { get; set; }
    public int ServiceOrderId { get; set; }
    public int PartId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public virtual ServiceOrder ServiceOrder { get; set; } = null!;
    public virtual Part Part { get; set; } = null!;
}
