using Vehicles.Application.Models.Vehicle;
using Vehicles.Infrastructure.Models;

namespace Vehicles.Application.Interfaces;

public interface IVehiclesService
{
    Task<VehicleResource> Create(SaveVehicleResource vehicleResource);
    Task<VehicleResource?> Update(int id, SaveVehicleResource vehicleResource);
    Task<VehicleResource?> Get(int id);
    Task<QueryResult<VehicleResource>> GetAll();
    Task Delete(int id);
}