using AutoMapper;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Mvc.ViewModels;

namespace SimpleShop.Mvc.Mapping
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile() 
        {
            CreateMap<Club, StartViewModel>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom((src, dest) => src.City.Name))
                .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.Name))
                .ForMember(dest => dest.ClubId, opt => opt.MapFrom((src, dest) => src.Id))
                .ForMember(dest => dest.ClubDisplayName, opt => opt.MapFrom((src, dest) => src.DisplayName))
                ;
        }
    }
}
