using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities.Clients
{
    public class Client : Entity
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Patronymic { get; set; }

        [NotMapped]
        public string FullName => $"{Surname} {Name} {Patronymic}"; // Бизнес логики в моделлях для маппинга в бд быть не должно

        public required string Email { get; set; }

        public bool IsMan { get; set; }

        public DateTime Birhday { get; set; }

        public required string Phone { get; set; }

        public string? Password { get; set; }

    }
}
