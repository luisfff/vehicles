using AutoMapper;
using Vehicles.Application.Interfaces;
using Vehicles.Application.Models.Vehicle;
using Vehicles.Infrastructure.Entities;
using Vehicles.Infrastructure.Interfaces;
using Vehicles.Infrastructure.Models;

namespace Vehicles.Application.Services;

public class VehiclesService : IVehiclesService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public VehiclesService(IVehicleRepository vehicleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<VehicleResource?> Get(int id)
    {
        var vehicle = await _vehicleRepository.GetById(id, includeRelated: true);

        if (vehicle is null)
        {
            return null;
        }

        var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);

        return result;
    }

    public async Task<QueryResult<VehicleResource>> GetAll()
    {
        var query = new VehicleQuery()
        {
            IsSortAscending = true,
            PageSize = 100
        };

        var vehiclesQueryQueryResult = await _vehicleRepository.GetByQuery(query);

        var result = _mapper.Map<QueryResult<Vehicle>, QueryResult<VehicleResource>>(vehiclesQueryQueryResult);

        return result;
    }

    public async Task Delete(int id)
    {
        var vehicle = await _vehicleRepository.GetById(id, includeRelated: false);

        if (vehicle is null)
        {
            return;
        }

        _vehicleRepository.Remove(vehicle);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<VehicleResource> Create(SaveVehicleResource vehicleResource)
    {
        var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
        vehicle.LastUpdate = DateTime.Now;

        _vehicleRepository.Add(vehicle);
        await _unitOfWork.CompleteAsync();

        vehicle = await _vehicleRepository.GetById(vehicle.Id);

        var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
        return result;
    }

    public async Task<VehicleResource?> Update(int id, SaveVehicleResource vehicleResource)
    {
        var vehicle = await _vehicleRepository.GetById(id);

        if (vehicle is null)
        {
            return null;
        }

        _mapper.Map(vehicleResource, vehicle);
        vehicle.LastUpdate = DateTime.Now;

        await _unitOfWork.CompleteAsync();

        vehicle = await _vehicleRepository.GetById(id);

        var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);

        return result;
    }
}