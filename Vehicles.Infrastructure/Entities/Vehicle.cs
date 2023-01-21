using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehicles.Infrastructure.Entities;

[Table("Vehicles")]
public class Vehicle
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public Model Model { get; set; }

    [Required]
    [StringLength(255)]
    public string ContactName { get; set; }

    public DateTime LastUpdate { get; set; }
}