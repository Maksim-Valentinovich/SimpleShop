using SimpleShop.Domain.Entities.Products;

namespace SimpleShop.Domain.Entities.ShopCards
{
    public class ShopCardItem : Entity
    {
        public int ProductId { get; set; }
        public Guid ShopCardId { get; set; }
        public required Product Product { get; set; }
    }
}
