using System;
using System.Collections.Generic;

namespace CaraCara.Domain.Entities;

public class ServiceOrder
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int VehicleId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Status { get; set; } = string.Empty; // Pending | InProgress | Done
    public decimal TotalCost { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
    public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();
    public virtual ICollection<ServicePartUsage> PartUsages { get; set; } = new List<ServicePartUsage>();
}
