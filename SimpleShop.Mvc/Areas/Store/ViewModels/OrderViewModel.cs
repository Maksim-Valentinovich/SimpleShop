using SimpleShop.Domain.Entities.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Mvc.Areas.Store.ViewModels
{
    public class ShopCardViewModel
    {
        public int ClientId { get; set; }

        public Client? Client { get; set; }

        public bool IsOnline { get; set; }

        //public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}
