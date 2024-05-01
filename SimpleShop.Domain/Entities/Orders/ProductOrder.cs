using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities.Orders
{
    public class ProductOrder
    {
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }

        public int ClubId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public Club? Club { get; set; }

    }
}
