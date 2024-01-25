using SimpleShop.Domain.Entities.Products;

namespace SimpleShop.Domain.Entities.ShopCards
{
    public class ShopCardItem : Entity
    {
        public int productId { get; set; }
        public required string ShopCardId { get; set; }
        public required Product product { get; set; }
    }
}
