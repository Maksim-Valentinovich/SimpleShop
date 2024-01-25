using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities
{
    public class Order : Entity
    {
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        public bool IsOnline { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}
