using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Vehicles.Infrastructure.Entities;
using Vehicles.Infrastructure.Extension;
using Vehicles.Infrastructure.Interfaces;
using Vehicles.Infrastructure.Models;

namespace Vehicles.Infrastructure.Repositories;

public class VehiclesRepository : IVehicleRepository
{
    private readonly VehiclesDbContext _context;

    public VehiclesRepository(VehiclesDbContext context)
    {
        _context = context;
    }

    public async Task<Vehicle?> GetById(int id, bool includeRelated = true)
    {
        if (!includeRelated)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        return await _context.Vehicles
            .Include(v => v.Model)
            .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
    }

    public async Task<QueryResult<Vehicle>> GetByQuery(VehicleQuery queryObject)
    {
        var result = new QueryResult<Vehicle>();

        var query = _context.Vehicles
            .Include(v => v.Model)
            .ThenInclude(m => m.Make)
            .AsQueryable();

        query = query.ApplyFiltering(queryObject);

        var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
        {
            ["make"] = v => v.Model.Make.Name,
            ["model"] = v => v.Model.Name,
            ["contactName"] = v => v.ContactName
        };

        query = query.ApplyOrdering(queryObject, columnsMap);

        result.TotalItems = await query.CountAsync();
        query = query.ApplyPaging(queryObject);

        result.Items = await query.ToListAsync();

        return result;

    }

    public void Add(Vehicle? vehicle)
    {
        _context.Vehicles.Add(vehicle);
    }

    public void Remove(Vehicle vehicle)
    {
        _context.Add(vehicle);
    }
}