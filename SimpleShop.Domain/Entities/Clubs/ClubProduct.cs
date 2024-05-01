using System.ComponentModel.DataAnnotations.Schema;
using SimpleShop.Domain.Entities.Products;

namespace SimpleShop.Domain.Entities.Clubs
{
    public class ClubProduct
    {
        public int ClubId { get; set; }
        [ForeignKey(nameof(ClubId))]
        public required Club Club { get; set; }


        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public required Product Product { get; set; }
    }
}
