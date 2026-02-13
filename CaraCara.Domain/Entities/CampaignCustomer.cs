namespace CaraCara.Domain.Entities;

public class CampaignCustomer
{
    public int CampaignId { get; set; }
    public int CustomerId { get; set; }
    public string Status { get; set; } = string.Empty; // Sent | Responded

    public virtual Campaign Campaign { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
}
