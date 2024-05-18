using SimpleShop.Application.Common;

namespace SimpleShop.Application.Orders.Dto
{
    public class OrderDto : EntityDto
    {
        public int ClientId { get; set; }

        public bool IsOnline { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}
