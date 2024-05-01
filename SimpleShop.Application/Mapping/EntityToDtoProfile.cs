using AutoMapper;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Application.Clubs.Dto;
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

            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => src.Id));
        }
    }
}
