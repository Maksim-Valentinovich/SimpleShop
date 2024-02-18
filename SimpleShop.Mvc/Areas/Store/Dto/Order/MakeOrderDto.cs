namespace SimpleShop.Mvc.Areas.Store.Dto.Order
{
    public class MakeOrderDto
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Patronymic { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsMan { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public bool IsOnline { get; set; }
    }
}
