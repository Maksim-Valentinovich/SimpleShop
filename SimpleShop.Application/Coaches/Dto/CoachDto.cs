using SimpleShop.Application.Common;

namespace SimpleShop.Application.Coaches.Dto
{
    public class CoachDto : EntityDto
    {
        public int ClubId { get; set; }
        public required string Name { get; set; }

        public required string ClubName { get; set; }
        public required string Description { get; set; }
        public int TelephoneNubmer { get; set; }
        public int CategoryCoachId { get; set; }
        public required string PhotoLink { get; set; }
    }
}
