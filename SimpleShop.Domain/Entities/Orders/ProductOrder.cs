using System.ComponentModel.DataAnnotations.Schema;
using SimpleShop.Domain.Entities.Products;

namespace SimpleShop.Domain.Entities.Orders
{
    public class ProductOrder
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public required Product Product { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public required Order Order { get; set; }

        public int? CountVisit { get; set; }

        public int? CountPeople { get; set; }

        public int? CountDay { get; set; }
    }
}
