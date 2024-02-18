namespace SimpleShop.Mvc.Areas.PersonalAccount.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int? CountVisit { get; set; }

        public int? CountPeople { get; set; }

        public int? CountDay { get; set; }

        public string? ClubName { get; set; }

        public DateTime Date { get; set; }

    }
}
