using SimpleShop.Application.Common;

namespace SimpleShop.Application.Clients.Dto
{
    public class ClientDto : EntityDto
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Patronymic { get; set; }

        public required string Email { get; set; }

        public bool IsMan { get; set; }

        public DateTime Birhday { get; set; }

        public required string Phone { get; set; }

        public string? Password { get; set; }
    }
}
