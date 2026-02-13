using System.Collections.Generic;

namespace CaraCara.Domain.Entities;

public class Part
{
    public int Id { get; set; }
    public string PartCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int MinStockLevel { get; set; }

    public virtual ICollection<PartStock> Stocks { get; set; } = new List<PartStock>();
    public virtual ICollection<StockTransaction> Transactions { get; set; } = new List<StockTransaction>();
    public virtual ICollection<ServicePartUsage> ServiceUsages { get; set; } = new List<ServicePartUsage>();
}
