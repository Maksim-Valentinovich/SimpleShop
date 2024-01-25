namespace SimpleShop.Domain.Entities.Clubs
{
    public class City : Entity
    {
        public required string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
