using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
