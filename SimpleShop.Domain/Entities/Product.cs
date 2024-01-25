using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public int ClubId { get; set; }

        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public int? Count { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

    }
}
