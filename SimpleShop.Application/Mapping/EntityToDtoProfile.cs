using AutoMapper;
using SimpleShop.Application.Cities.Dto;
using SimpleShop.Application.Clients.Dto;
using SimpleShop.Application.Clubs.Dto;
using SimpleShop.Application.Coaches.Dto;
using SimpleShop.Application.Orders.Dto;
using SimpleShop.Application.Products.Dto;
using SimpleShop.Domain.Entities.Clients;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Domain.Entities.Orders;
using SimpleShop.Domain.Entities.Products;

namespace SimpleShop.Application.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<ProductOrderDto, ProductOrder>();

            CreateMap<Club, ClubDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom((src, dest) => src.City.Name));

            CreateMap<Coach, CoachDto>()
                .ForMember(dest => dest.TelephoneNubmer, opt => opt.MapFrom((src, dest) => src.TelephoneNubmer))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom((src, dest) => src.CategoryCoachId))
                .ForMember(dest => dest.ClubName, opt => opt.MapFrom((src, dest) => src.Club.DisplayName));

            CreateMap<CategoryProduct, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest) => src.Product.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) => src.Product.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom((src, dest) => src.Product.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom((src, dest) => src.Product.Price))
                .ForMember(dest => dest.CountVisit, opt => opt.MapFrom((src, dest) => src.Product.CountVisit))
                .ForMember(dest => dest.CountPeople, opt => opt.MapFrom((src, dest) => src.Product.CountPeople))
                .ForMember(dest => dest.CountDay, opt => opt.MapFrom((src, dest) => src.Product.CountDay))
                .ForMember(dest => dest.Info, opt => opt.MapFrom((src, dest) => src.Category.Info))
                .ForMember(dest => dest.PictureLink, opt => opt.MapFrom((src, dest) => src.Category.PictureLink));

            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
        }
    }
}
