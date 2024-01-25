using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShop.Domain.Entities
{
    public class Client : Entity
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Patronymic { get; set; }

        [NotMapped]
        public string FullName => $"{Surname} {Name} {Patronymic}";

        public required string Email { get; set; }

        public bool IsMan { get; set; }

        public byte Age { get; set; }

        public required string Phone { get; set; }

    }
}
