using System;
using System.Collections.Generic;

namespace CaraCara.Domain.Entities;

public class Campaign
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<CampaignCustomer> CampaignCustomers { get; set; } = new List<CampaignCustomer>();
}
