using System.Collections.Generic;

namespace CaraCara.Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string CustomerType { get; set; } = string.Empty; // Individual | Corporate

    public virtual ICollection<VehicleBooking> Bookings { get; set; } = new List<VehicleBooking>();
    public virtual ICollection<VehicleSale> Purchases { get; set; } = new List<VehicleSale>();
    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
    public virtual ICollection<CustomerInteraction> Interactions { get; set; } = new List<CustomerInteraction>();
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public virtual ICollection<AccountReceivable> AccountReceivables { get; set; } = new List<AccountReceivable>();
    public virtual ICollection<CampaignCustomer> CampaignCustomers { get; set; } = new List<CampaignCustomer>();
}
