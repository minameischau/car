using System;

namespace CaraCara.Domain.Entities;

public class AccountReceivable
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int InvoiceId { get; set; }
    public decimal TotalDue { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastPaymentDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
    public virtual Invoice Invoice { get; set; } = null!;
}
