using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Domain.Entities.Products;

namespace SimpleShop.Application.ShopCard
{
    public class ShopCardAppService : SimpleShopAppService, IShopCardAppService
    {
        public ShopCardAppService(SimpleShopContext context, Domain.Entities.ShopCards.ShopCard shopCard, IMapper mapper) : base(context, shopCard, mapper)
        {
        }

        public async Task AddToCard(int productId, int clubId)
        {
            Product product = await Context.Products.FirstAsync(c => c.Id == productId);
            Club club = await Context.Clubs.FirstAsync(c => c.Id == clubId);

            ShopCard?.AddToCard(product, club);
        }
    }
}
