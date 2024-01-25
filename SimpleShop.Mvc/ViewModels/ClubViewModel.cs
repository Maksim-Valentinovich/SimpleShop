using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SimpleShop.Mvc.ViewsModels
{
    public class ClubViewModel
    {
        public required string Name { get; set; }

        public TimeSpan InterpreterStart { get; set; }

        public TimeSpan InterpreterFinish { get; set; }

        public TimeSpan WeekendsStart { get; set; }

        public TimeSpan WeekendsFinish { get; set; }

        public required string City { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }
    }
}
