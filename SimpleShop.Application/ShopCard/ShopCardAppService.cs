using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.ShopCard.Dto;
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

        public async Task AddProduct(int productId, int clubId)
        {
            Product product = await Context.Products.FirstAsync(c => c.Id == productId);
            Club club = await Context.Clubs.FirstAsync(c => c.Id == clubId);

            ShopCard?.AddToCard(product, club);
        }

        public void DeleteProduct(int index)
        {
            ShopCard?.DeleteProduct(index);
        }

        public ShopCardDto GetShopItems()
        {
            var items = ShopCard!.GetShopItems();

            ShopCard.ListShopItems = items;

            var clubs = ShopCard!.GetShopClubs();

            ShopCard.ListShopClubs = clubs;

            ShopCardDto shopCardDto = new()
            {
                ShopCard = ShopCard,
            };

            return shopCardDto;
        }

        public ShopCardDto GetShopClubs()
        {
            var clubs = ShopCard!.GetShopClubs();

            ShopCard.ListShopClubs = clubs;

            ShopCardDto shopCardDto = new()
            {
                ShopCard = ShopCard,
            };

            return shopCardDto;
        }

        public string ShopCardSession()
        {
            var model = Domain.Entities.ShopCards.ShopCard.Session.GetString("ShopCard");
            return model;
        }
    }
}
