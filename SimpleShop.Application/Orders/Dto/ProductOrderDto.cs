using SimpleShop.Domain.Entities.Clubs;
using SimpleShop.Domain.Entities.Orders;
using SimpleShop.Domain.Entities.Products;

namespace SimpleShop.Application.Orders.Dto
{
    public class ProductOrderDto
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ClubId { get; set; }
        public Club? Club { get; set; }
    }
}
