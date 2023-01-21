using Microsoft.AspNetCore.Mvc;
using Vehicles.Application.Interfaces;
using Vehicles.Application.Models;

namespace Vehicles.Api.Controllers;

[Route("models")]
[ApiController]
public class ModelsController : Controller
{
    private readonly IModelsService _makeService;

    public ModelsController(IModelsService makeService)
    {
        _makeService = makeService;
    }

    [HttpGet()]
    public async Task<IEnumerable<ModelsResource>> GetModels()
    {
        var result = await _makeService.Get();
        return result;
    }
}