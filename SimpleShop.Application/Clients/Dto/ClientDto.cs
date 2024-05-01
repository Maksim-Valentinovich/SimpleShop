using SimpleShop.Application.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Application.Clients.Dto
{
    public class ClientDto : EntityDto
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Patronymic { get; set; }

        public string FullName => $"{Surname} {Name} {Patronymic}";

        public required string Email { get; set; }

        public bool IsMan { get; set; }

        public DateTime Birhday { get; set; }

        public required string Phone { get; set; }

        public string? Password { get; set; }
    }
}
