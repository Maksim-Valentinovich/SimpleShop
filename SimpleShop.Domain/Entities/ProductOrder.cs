using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities
{
    public class ProductOrder
    {
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }


        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int? CountVisit { get; set; }

        public int? CountPeople { get; set; }

        public int? CountDay { get; set; }
    }
}
