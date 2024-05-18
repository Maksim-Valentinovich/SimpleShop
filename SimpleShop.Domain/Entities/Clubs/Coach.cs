using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities.Clubs
{
    public class Coach : Entity
    {
        public int ClubId { get; set; }

        [ForeignKey(nameof(ClubId))]
        public required Club Club { get; set; }

        public required string Name { get; set; }
        public required string Description { get; set; }
        public int TelephoneNubmer { get; set; }
        public int CategoryCoachId { get; set; }
        public required string PhotoLink { get; set; }
    }
}
