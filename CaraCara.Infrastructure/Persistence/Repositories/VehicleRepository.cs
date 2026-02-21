using CaraCara.Application.Interfaces;
using CaraCara.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaraCara.Infrastructure.Persistence.Repositories;

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Vehicle>> GetAllWithModelAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(v => v.VehicleModel)
            .ToListAsync(cancellationToken);
    }
}
