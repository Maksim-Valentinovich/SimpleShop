
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Domain.Entities.Products;
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
        private static IServiceProvider _services { get; set; }

        public List<Product> ListShopItems { get; set; }

        public ShopCard()
        {

        }
        public ShopCard(IServiceProvider services)
        {
            _services = services;
        }

        public static ShopCard GetCard(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            if (session.GetString("ShopCard") == null)
            {
                ShopCard cardNew = new();

                string json = JsonSerializer.Serialize(cardNew);

                session.SetString("ShopCard", json);
            }
            ShopCard? card = JsonSerializer.Deserialize <ShopCard> (session.GetString("ShopCard"));

            return new ShopCard() { ListShopItems = card.ListShopItems};
        }

        public void AddToCard(Product product)
        {
            ISession? session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            ShopCard? card = JsonSerializer.Deserialize<ShopCard>(session.GetString("ShopCard"));

            card.ListShopItems.Add(product);

            ShopCard cardNew = new() {ListShopItems = card.ListShopItems};

            string json = JsonSerializer.Serialize(cardNew);

            session.SetString("ShopCard", json);
        }

        public List<Product> GetShopItems()
        {   
            ISession? session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var card = JsonSerializer.Deserialize<ShopCard>(session.GetString("ShopCard"));

            return card.ListShopItems;
        }
    }
}
