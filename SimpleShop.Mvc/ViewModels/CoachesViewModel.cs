namespace SimpleShop.Mvc.ViewModels
{
    public class CoachesViewModel
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public required string ClubName { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? TelephoneNubmer { get; set; }
        public int CategoryId { get; set; }
        public required string PhotoLink { get; set; }
    }
}
