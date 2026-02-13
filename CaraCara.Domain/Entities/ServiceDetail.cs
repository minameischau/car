namespace CaraCara.Domain.Entities;

public class ServiceDetail
{
    public int Id { get; set; }
    public int ServiceOrderId { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal LaborCost { get; set; }
    public int AssignedEmployeeId { get; set; }

    public virtual ServiceOrder ServiceOrder { get; set; } = null!;
    public virtual Employee AssignedEmployee { get; set; } = null!;
}
