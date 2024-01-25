using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities.Products
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public required Category Category { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public required Product Product { get; set; }
    }
}
