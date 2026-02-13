using System.Collections.Generic;

namespace CaraCara.Domain.Entities;

public class Warehouse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Vehicle | Part

    public virtual ICollection<PartStock> Stocks { get; set; } = new List<PartStock>();
    public virtual ICollection<StockTransaction> Transactions { get; set; } = new List<StockTransaction>();
}
