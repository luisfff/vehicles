using AutoMapper;
using Vehicles.Application.Models;
using Vehicles.Application.Models.Vehicle;
using Vehicles.Infrastructure.Entities;
using Vehicles.Infrastructure.Models;

namespace Vehicles.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
        CreateMap<Make, ModelsResource>();
        CreateMap<Make, KeyValuePairResource>();
        CreateMap<Model, KeyValuePairResource>();

        CreateMap<Vehicle, SaveVehicleResource>()
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v =>
                new ContactResource {Name = v.ContactName}));

        CreateMap<Vehicle, VehicleResource>()
            .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v =>
                new ContactResource {Name = v.ContactName}));

        CreateMap<VehicleQueryResource, VehicleQuery>();

        CreateMap<SaveVehicleResource, Vehicle>()
            .ForMember(v => v.Id, opt => opt.Ignore())
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .AfterMap(((vr, v) => {
            }));

        CreateMap<QueryResult<Vehicle>, QueryResult<VehicleResource>>();
    }
}