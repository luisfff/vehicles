using System.ComponentModel.DataAnnotations;

namespace Vehicles.Application.Models;

public class ContactResource
{
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
}