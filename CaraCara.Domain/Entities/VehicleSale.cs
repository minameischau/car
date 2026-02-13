using System;

namespace CaraCara.Domain.Entities;

public class VehicleSale
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int CustomerId { get; set; }
    public int SalesPersonId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SalePrice { get; set; }
    public int InvoiceId { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;

    public virtual Vehicle Vehicle { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
    public virtual Employee SalesPerson { get; set; } = null!;
    public virtual Invoice Invoice { get; set; } = null!;
}
