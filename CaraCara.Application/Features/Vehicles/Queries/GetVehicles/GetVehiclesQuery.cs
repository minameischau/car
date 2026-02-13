using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CaraCara.Application.Features.Vehicles.Queries.GetVehicles;

public record GetVehiclesQuery : IRequest<List<VehicleDto>>;

public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, List<VehicleDto>>
{
    public Task<List<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        // Mock data
        var vehicles = new List<VehicleDto>
        {
            new VehicleDto { Id = 1, VIN = "VN001", Brand = "Toyota", ModelName = "Camry", Year = 2023, Price = 1200000000, Color = "Black" },
            new VehicleDto { Id = 2, VIN = "VN002", Brand = "Honda", ModelName = "Civic", Year = 2022, Price = 900000000, Color = "White" },
            new VehicleDto { Id = 3, VIN = "VN003", Brand = "BMW", ModelName = "330i", Year = 2024, Price = 2500000000, Color = "Blue" }
        };

        return Task.FromResult(vehicles);
    }
}
