using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Mvc.ViewModels
{
    public class ClubViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        public string? DisplayName { get; set; }

        public TimeSpan InterpreterStart { get; set; }

        public TimeSpan InterpreterFinish { get; set; }

        public TimeSpan WeekendsStart { get; set; }

        public TimeSpan WeekendsFinish { get; set; }

        public string? CityName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? GumLink { get; set; }

        public string? SwimLink { get; set; }

        public string? GroupLink { get; set; }
    }
}
