using System.Collections.Generic;

namespace CaraCara.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public string VIN { get; set; } = string.Empty;
    public int ModelId { get; set; }
    public string Color { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Status { get; set; } = string.Empty; // Available | Reserved | Sold
    public string StockLocation { get; set; } = string.Empty;

    public virtual VehicleModel VehicleModel { get; set; } = null!;
    public virtual VehicleSale? VehicleSale { get; set; }
    public virtual ICollection<VehicleBooking> Bookings { get; set; } = new List<VehicleBooking>();
    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
}
