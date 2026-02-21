using CaraCara.Domain.Entities;

namespace CaraCara.Application.Interfaces;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<List<Vehicle>> GetAllWithModelAsync(CancellationToken cancellationToken = default);
}
