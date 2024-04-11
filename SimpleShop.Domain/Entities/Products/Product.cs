namespace SimpleShop.Domain.Entities.Products
{
    public class Product : Entity
    {
        public required string Name { get; set; }

        //public int? Count { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public int CountVisit { get; set; }

        public int CountPeople { get; set; }

        public int CountDay { get; set; }

    }
}
