using SimpleShop.Application.Common;

namespace SimpleShop.Application.Products.Dto
{
    public class ProductDto : EntityDto
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public int CountVisit { get; set; }

        public int CountPeople { get; set; }

        public int CountDay { get; set; }

        public string? ClubName { get; set; }

        public int ClubId { get; set; }

        public string? PictureLink { get; set; }

        public string? Info { get; set; }
    }
}
