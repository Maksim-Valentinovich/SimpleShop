using AutoMapper;
using SimpleShop.Application.Clubs.Dto;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Mvc.ViewModels;

namespace SimpleShop.Mvc.Mapping
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile() 
        {
            CreateMap<ClubDto, StartViewModel>()
                .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.Name))
                .ForMember(dest => dest.ClubId, opt => opt.MapFrom((src, dest) => src.Id))
                .ForMember(dest => dest.ClubDisplayName, opt => opt.MapFrom((src, dest) => src.DisplayName))
                ;
        }
    }
}
