using SimpleShop.Domain.Entities.Clients;

namespace SimpleShop.Mvc.Areas.Store.ViewModels
{
    public class OrderViewModel
    {
        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public bool IsOnline { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}
