using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Application.Interfaces;
using Vehicles.Application.Models.Vehicle;

namespace Vehicles.Api.Controllers;

[Route("vehicles")]
[ApiController]
public class VehiclesController : Controller
{
    private readonly IVehiclesService _vehiclesService;

    public VehiclesController(IVehiclesService vehiclesService)
    {
        _vehiclesService = vehiclesService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicle(int id)
    {
        var result = await _vehiclesService.Get(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllVehicle()
    {
        var result = await _vehiclesService.GetAll();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
    {
        if (!ModelState.IsValid)

        {
            return BadRequest(ModelState);
        }

        var result = await _vehiclesService.Create(vehicleResource);

        return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _vehiclesService.Update(id, vehicleResource);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        await _vehiclesService.Delete(id);
        return Ok(id);
    }
}