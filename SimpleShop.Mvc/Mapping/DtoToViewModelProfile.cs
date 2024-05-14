using AutoMapper;
using SimpleShop.Application.Cities.Dto;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Application.Clubs.Dto;
using SimpleShop.Application.Coaches.Dto;
using SimpleShop.Application.Orders.Dto;
using SimpleShop.Application.Products.Dto;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Domain.Entities.Orders;
using SimpleShop.Mvc.Areas.PersonalAccount.ViewModels;
using SimpleShop.Mvc.Areas.Store.Dto.Order;
using SimpleShop.Mvc.Areas.Store.ViewModels;
using SimpleShop.Mvc.ViewModels;

namespace SimpleShop.Mvc.Mapping
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<ClubDto, ClubViewModel>();
            CreateMap<CityDto, CityViewModel>();
            CreateMap<CoachDto, CoachesViewModel>();
            CreateMap<ProductDto, ProductViewModel>(); //
            CreateMap<Club, ClubViewModel>();
            CreateMap<ClientDto, ClientViewModel>();
            CreateMap<RegisterViewModel, ClientDto>();
            CreateMap<MakeOrderDto, ClientDto>();
            CreateMap<MakeOrderDto, OrderDto>();

            CreateMap<ClubDto, StartViewModel>()
                .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.Name))
                .ForMember(dest => dest.ClubId, opt => opt.MapFrom((src, dest) => src.Id))
                .ForMember(dest => dest.ClubDisplayName, opt => opt.MapFrom((src, dest) => src.DisplayName));

            //CreateMap<ClubDto, ProductViewModel>()
            //    .ForMember(dest => dest.ClubId, opt => opt.MapFrom((src, dest) => src.Id))
            //    .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.DisplayName))
            //    /*.ForMember(dest => dest.Name, opt => opt.Ignore())*/;

            CreateMap<ClubProduct, ProductViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => src.ProductId))
                .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.Club.DisplayName))
                .ForMember(dest => dest.ClubId, opt => opt.MapFrom((src, dest) => src.Club.Id));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Date, opt =>opt.Ignore());
        }
    }
}
