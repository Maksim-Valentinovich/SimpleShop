namespace SimpleShop.Domain.Entities
{
    public class Club : Entity
    {
        public required string Name { get; set; }

        public required string DisplayName { get; set; }

        public required string City { get; set; }

        public TimeSpan InterpreterStart { get; set; }

        public TimeSpan InterpreterFinish { get; set; }

        public TimeSpan WeekendsStart { get; set; }

        public TimeSpan WeekendsFinish { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }
    }
}
