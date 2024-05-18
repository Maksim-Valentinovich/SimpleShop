using System.ComponentModel.DataAnnotations.Schema;
using SimpleShop.Domain.Entities.Clients;

namespace SimpleShop.Domain.Entities.Orders
{
    public class Order : Entity
    {
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; }

        public bool IsOnline { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }

    }
}
