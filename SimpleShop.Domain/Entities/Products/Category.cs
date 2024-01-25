namespace SimpleShop.Domain.Entities.Products
{
    public class Category : Entity
    {
        public required string Name { get; set; }

        public required string Info { get; set; }

        public required string PictureLink { get; set; }
    }
}
