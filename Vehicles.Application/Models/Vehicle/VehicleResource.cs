using Vehicles.Api.Models;

namespace Vehicles.Application.Models.Vehicle;

public class VehicleResource
{
    public int Id { get; set; }
    public KeyValuePairResource Model { get; set; }

    public KeyValuePairResource Make { get; set; }
    public ContactResource Contact { get; set; }
    public DateTime LastUpdate { get; set; }

}