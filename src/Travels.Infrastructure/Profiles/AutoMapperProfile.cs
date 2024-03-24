using AutoMapper;
using Travels.Application.Entities;
using Travels.Infrastructure.DTO;

namespace Travels.Infrastructure.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Stops, StopsDTO>();
        CreateMap<Travel, TravelDTO>();
        CreateMap<Trip, TripDTO>();
    }
}
