using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities.Orders
{
    public class ProductOrder
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public required Product Product { get; set; }

        //public List<Product>? Products;

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public required Order Order { get; set; }

        public int ClubId { get; set; }

        [ForeignKey("ClubId")]
        public required Club Club { get; set; }

    }
}
