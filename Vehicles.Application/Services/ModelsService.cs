using AutoMapper;
using Vehicles.Application.Interfaces;
using Vehicles.Application.Models;
using Vehicles.Infrastructure.Entities;
using Vehicles.Infrastructure.Interfaces;

namespace Vehicles.Application.Services;

public class ModelsService : IModelsService
{
    private readonly IMakeRepository _makeRepository;

    private readonly IMapper _mapper;

    public ModelsService(IMakeRepository makeRepository, IMapper mapper)
    {
        _makeRepository = makeRepository;
        _mapper = mapper;
    }

    public async Task<List<ModelsResource>> Get()
    {
        var makes = await _makeRepository.GetMakes();

        var result = _mapper.Map<List<Make>, List<ModelsResource>>(makes);

        return result;
    }
}