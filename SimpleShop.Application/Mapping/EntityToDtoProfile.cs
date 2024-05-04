using AutoMapper;
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
                .ForMember(dest => dest.CityName, opt => opt.MapFrom((src, dest) => src.City.Name))
                ;

            CreateMap<Coach, CoachDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) => src.Name))
                .ForMember(dest => dest.ClubId, opt => opt.MapFrom((src, dest) => src.ClubId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest) => src.Description))
                .ForMember(dest => dest.TelephoneNubmer, opt => opt.MapFrom((src, dest) => src.TelephoneNubmer))
                .ForMember(dest => dest.CategoryCoachId, opt => opt.MapFrom((src, dest) => src.CategoryCoachId))
                .ForMember(dest => dest.PhotoLink, opt => opt.MapFrom((src, dest) => src.PhotoLink))
                .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.Club.DisplayName));
        }
    }
}
