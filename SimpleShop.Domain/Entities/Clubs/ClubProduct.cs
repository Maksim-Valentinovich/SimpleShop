using System.ComponentModel.DataAnnotations.Schema;
using SimpleShop.Domain.Entities.Products;

namespace SimpleShop.Domain.Entities.Clubs
{
    public class ClubProduct
    {
        public int ClubId { get; set; }

        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
