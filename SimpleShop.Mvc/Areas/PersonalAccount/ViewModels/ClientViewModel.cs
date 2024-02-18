using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Mvc.Areas.PersonalAccount.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Patronymic { get; set; }

        public string? FullName => $"{Surname} {Name} {Patronymic}";

        public  string? Email { get; set; }

        public bool IsMan { get; set; }

        public DateTime Birhday { get; set; }

        public string? Phone { get; set; }

        public  string? Password { get; set; }

    }
}
