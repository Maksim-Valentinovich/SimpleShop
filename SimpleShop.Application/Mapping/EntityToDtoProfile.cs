using AutoMapper;
using SimpleShop.Application.Cities.Dto;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Application.Clubs.Dto;
using SimpleShop.Application.Coaches.Dto;
using SimpleShop.Domain.Entities.Clients;
using SimpleShop.Domain.Entities.Clubs;

namespace SimpleShop.Application.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Club, ClubDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom((src, dest) => src.City.Name));

            CreateMap<Coach, CoachDto>()
                .ForMember(dest => dest.TelephoneNubmer, opt => opt.MapFrom((src, dest) => src.TelephoneNubmer))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest) => src.CategoryCoachId))
                .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.Club.DisplayName));

            CreateMap<City, CityDto>();
        }
    }
}
