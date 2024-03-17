using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Domain.Entities.Products;
using SimpleShop.Domain.Entities.Clubs;
using System.Text;
using System.Text.Json;

namespace SimpleShop.Domain.Entities.ShopCards
{
    //public class ShopCard : Entity
    //{
    //    private readonly SimpleShopContext _context;

    //    public ShopCard(SimpleShopContext context)
    //    {
    //        _context = context;
    //    }

    //    public Guid ShopCardId { get; set; }
    //    public List<ShopCardItem> ListShopItems { get; set; }

    //    public static ShopCard GetCard(IServiceProvider services)
    //    {
    //        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

    //        Guid shopCardId;

    //        if (session.GetString("Id") == null)
    //        {
    //            shopCardId = Guid.NewGuid();

    //            session.SetString("Id", shopCardId.ToString());
    //        }

    //        shopCardId = Guid.Parse(session.GetString("Id"));

    //        return new ShopCard(services.GetService<SimpleShopContext>()) { ShopCardId = shopCardId };
    //    }

    //    public void AddToCard(Product product)
    //    {
    //        _context?.ShopCardItem.Add(new ShopCardItem
    //        {
    //            ShopCardId = ShopCardId,
    //            Product = product,
    //        });
    //        _context?.SaveChanges();
    //    }

    //    public List<ShopCardItem> GetShopItems()
    //    {
    //        return _context.ShopCardItem.Where(c => c.ShopCardId == ShopCardId).Include(s => s.Product).ToList();
    //    }
    //}

    public class ShopCard : Entity
    {
        private static IServiceProvider? Services { get; set; }
        public static ISession? Session { get; set; }

        public List<Product>? ListShopItems { get; set; }

        public List<Club>? ListShopClubs {  get; set; }

        public static ShopCard GetCard(IServiceProvider services)
        {
            Services = services;

            Session = Services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            if (Session.GetString("ShopCard") == null)
            {
                ShopCard cardNew = new();

                string json = JsonSerializer.Serialize(cardNew);

                Session.SetString("ShopCard", json);
            }
            ShopCard? card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"));

            return new ShopCard() { ListShopItems = card?.ListShopItems , ListShopClubs = card?.ListShopClubs };
        }

        public void AddToCard(Product product, Club club)
        {
            ShopCard? card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"));

            if (card?.ListShopItems == null)
            {
                card.ListShopItems = new List<Product>() { product };
                card.ListShopClubs = new List<Club>() { club };
            }
            else
            {
                card?.ListShopItems?.Add(product);
                card?.ListShopClubs?.Add(club);
            }

            ShopCard cardNew = new() { ListShopItems = card?.ListShopItems, ListShopClubs = card?.ListShopClubs };

            string json = JsonSerializer.Serialize(cardNew);

            Session.SetString("ShopCard", json);
        }

        public void DeleteProduct(int index)
        {
            ShopCard? card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"));

            card?.ListShopItems?.RemoveAt(index);

            card?.ListShopClubs?.RemoveAt(index);

            ShopCard cardNew = new() { ListShopItems = card?.ListShopItems, ListShopClubs = card?.ListShopClubs };

            string json = JsonSerializer.Serialize(cardNew);

            Session.SetString("ShopCard", json);
        }

        public List<Product>? GetShopItems()
        {
            var card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"));
            return card?.ListShopItems;
        }

        public List<Club>? GetShopClubs() 
        {
            var card = JsonSerializer.Deserialize<ShopCard>(Session.GetString("ShopCard"));
            return card?.ListShopClubs;
        }
    }
}
