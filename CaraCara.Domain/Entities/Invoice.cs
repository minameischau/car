using System;
using System.Collections.Generic;

namespace CaraCara.Domain.Entities;

public class Invoice
{
    public int Id { get; set; }
    public string InvoiceNo { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Type { get; set; } = string.Empty; // Sale | Service

    public virtual Customer Customer { get; set; } = null!;
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<AccountReceivable> AccountReceivables { get; set; } = new List<AccountReceivable>();
}
