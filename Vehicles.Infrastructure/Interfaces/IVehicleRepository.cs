using Vehicles.Infrastructure.Entities;
using Vehicles.Infrastructure.Models;

namespace Vehicles.Infrastructure.Interfaces;

public interface IVehicleRepository
{
    void Add(Vehicle? vehicle);
    Task<Vehicle?> GetById(int id, bool includeRelated = true);

    Task<QueryResult<Vehicle>> GetByQuery(VehicleQuery queryObject);

    void Remove(Vehicle vehicle);
}