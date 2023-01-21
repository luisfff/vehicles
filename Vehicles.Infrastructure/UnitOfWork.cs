using Vehicles.Infrastructure.Interfaces;

namespace Vehicles.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly VehiclesDbContext _context;

    public UnitOfWork(VehiclesDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

}