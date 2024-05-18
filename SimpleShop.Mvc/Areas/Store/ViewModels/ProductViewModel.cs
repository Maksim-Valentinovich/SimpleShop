namespace SimpleShop.Mvc.Areas.Store.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

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
