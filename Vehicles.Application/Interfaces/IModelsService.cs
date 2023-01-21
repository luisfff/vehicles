using Vehicles.Application.Models;

namespace Vehicles.Application.Interfaces;

public interface IModelsService
{
    Task<List<ModelsResource>> Get();
}