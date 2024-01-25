
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Domain.Entities.Products;
using System.Text;

namespace SimpleShop.Domain.Entities.ShopCards
{
    public class ShopCard : Entity
    {
        private readonly SimpleShopContext _context;

        public ShopCard(SimpleShopContext context)
        {
            _context = context;
        }

        public string ShopCardId { get; set; }
        public List<ShopCardItem> ListShopItems { get; set; }

        public static ShopCard GetCard(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context1 = services.GetService<SimpleShopContext>(); //убрать

            string shopCardId = session.GetString("Id");

            if (shopCardId == null)
            {
                shopCardId = Guid.NewGuid().ToString();
                session.SetString("Id", shopCardId);
            }
            return new ShopCard(context1) { ShopCardId = shopCardId };
        }

        public void AddToCard(Product product)
        {
            _context?.ShopCardItem.Add(new ShopCardItem
            {
                ShopCardId = ShopCardId,
                product = product,
            });
            _context?.SaveChanges();
        }

        public List<ShopCardItem> GetShopItems()
        {
            return _context.ShopCardItem.Where(c => c.ShopCardId == ShopCardId).Include(s => s.product).ToList();
        }
    }
}
