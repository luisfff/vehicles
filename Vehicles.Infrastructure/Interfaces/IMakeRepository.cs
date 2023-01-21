using Vehicles.Infrastructure.Entities;

namespace Vehicles.Infrastructure.Interfaces;

public interface IMakeRepository
{
    Task<List<Make>> GetMakes();
}