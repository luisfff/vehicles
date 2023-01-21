using Microsoft.EntityFrameworkCore;
using Vehicles.Infrastructure.Entities;
using Vehicles.Infrastructure.Interfaces;

namespace Vehicles.Infrastructure.Repositories;

public class MakesRepository : IMakeRepository
{
    private readonly VehiclesDbContext _context;

    public MakesRepository(VehiclesDbContext context)
    {
        _context = context;
    }

    public async Task<List<Make>> GetMakes()
    {
        var result = await _context.Makes
            .Include(m => m.Models)
            .ToListAsync();

        return result;

    }
}