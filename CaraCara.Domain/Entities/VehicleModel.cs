using System.Collections.Generic;

namespace CaraCara.Domain.Entities;

public class VehicleModel
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public int Year { get; set; }
    public string EngineType { get; set; } = string.Empty;
    public string Transmission { get; set; } = string.Empty;

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
