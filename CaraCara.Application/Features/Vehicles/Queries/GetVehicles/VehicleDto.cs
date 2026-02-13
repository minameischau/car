namespace CaraCara.Application.Features.Vehicles.Queries.GetVehicles;

public class VehicleDto
{
    public int Id { get; set; }
    public string VIN { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; } = string.Empty;
}
