using AutoMapper;
using SimpleShop.Application.Cities.Dto;
using SimpleShop.Application.Clubs.Dto;
using SimpleShop.Application.Coaches.Dto;
using SimpleShop.Application.Products.Dto;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Mvc.Areas.Store.ViewModels;
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
                .ForMember(dest => dest.ClubDisplayName, opt => opt.MapFrom((src, dest) => src.DisplayName));

            CreateMap<ClubDto, ClubViewModel>();
            CreateMap<CityDto, CityViewModel>();

            CreateMap<ProductDto, ProductViewModel>();
            CreateMap<ClubDto, ProductViewModel>();

            
            
            CreateMap<Club, ClubViewModel>();

            //CreateMap<Club, StartViewModel>()
            //    .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.Name))
            //    .ForMember(dest => dest.ClubId, opt => opt.MapFrom((src, dest) => src.Id))
            //    .ForMember(dest => dest.ClubDisplayName, opt => opt.MapFrom((src, dest) => src.DisplayName))
            //    .ForMember(dest => dest.CityName, opt => opt.MapFrom((src, dest) => src.City.Name));

            CreateMap<CoachDto, CoachesViewModel>();


        }
    }
}
