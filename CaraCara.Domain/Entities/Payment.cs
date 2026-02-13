using System;

namespace CaraCara.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = string.Empty; // Cash | Transfer | Card
    public string Note { get; set; } = string.Empty;

    public virtual Invoice Invoice { get; set; } = null!;
}
