using AutoMapper;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.ShopCards;

namespace SimpleShop.Application
{
    public abstract class SimpleShopAppService
    {
        protected SimpleShopContext Context { get; set; }

        protected Domain.Entities.ShopCards.ShopCard? ShopCard { get; set; }

        protected IMapper Mapper { get; set; }

        protected SimpleShopAppService(SimpleShopContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        protected SimpleShopAppService(SimpleShopContext context, Domain.Entities.ShopCards.ShopCard shopCard, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            ShopCard = shopCard;
        }
    }
}
