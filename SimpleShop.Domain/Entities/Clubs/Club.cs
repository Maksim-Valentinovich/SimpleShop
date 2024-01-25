namespace SimpleShop.Domain.Entities.Clubs
{
    public class Club : Entity
    {
        public required string Name { get; set; }

        public required string DisplayName { get; set; }

        public required int CityId { get; set; }

        public TimeSpan InterpreterStart { get; set; }

        public TimeSpan InterpreterFinish { get; set; }

        public TimeSpan WeekendsStart { get; set; }

        public TimeSpan WeekendsFinish { get; set; }

        public required string Address { get; set; }

        public required string Phone { get; set; }

        public required string GumLink { get; set; }

        public required string SwimLink { get; set; }

        public required string GroupLink { get; set; }
    }
}
