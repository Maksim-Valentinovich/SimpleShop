namespace SimpleShop.Mvc.ViewModels
{
    public class StartViewModel
    {
        public required string CityName { get; set; }

        public int ClubId { get; set; }

        public required string ClubName { get; set; }

        public required string ClubDisplayName { get; set; }

        public string? Chapter {  get; set; }
    }
}
