using System.ComponentModel.DataAnnotations;

namespace Vehicles.Application.Models.Vehicle;

public class SaveVehicleResource
{
    public int ModelId { get; set; }

    [Required]
    public ContactResource Contact { get; set; }
}