using System;

namespace CaraCara.Domain.Entities;

public class VehicleBooking
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int CustomerId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal DepositAmount { get; set; }
    public string Status { get; set; } = string.Empty;

    public virtual Vehicle Vehicle { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
}
