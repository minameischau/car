using System;

namespace CaraCara.Domain.Entities;

public class CustomerInteraction
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    public string Channel { get; set; } = string.Empty; // Call | SMS | Email
    public string Note { get; set; } = string.Empty;
    public DateTime InteractionDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
    public virtual Employee Employee { get; set; } = null!;
}
