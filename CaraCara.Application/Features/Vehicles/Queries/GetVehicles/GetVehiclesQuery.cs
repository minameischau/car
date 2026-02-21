using CaraCara.Application.Interfaces;
using MediatR;

namespace CaraCara.Application.Features.Vehicles.Queries.GetVehicles;

public record GetVehiclesQuery : IRequest<List<VehicleDto>>;

public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, List<VehicleDto>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehiclesQueryHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<List<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.GetAllWithModelAsync(cancellationToken);

        return vehicles.Select(v => new VehicleDto
        {
            Id = v.Id,
            VIN = v.VIN,
            Brand = v.VehicleModel.Brand,
            ModelName = v.VehicleModel.ModelName,
            Year = v.VehicleModel.Year,
            Price = v.Price,
            Color = v.Color
        }).ToList();
    }
}
