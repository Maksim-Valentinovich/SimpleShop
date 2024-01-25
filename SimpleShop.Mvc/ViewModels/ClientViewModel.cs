using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Mvc.ViewsModels
{
    public class ClientViewModel
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        public required string Patronymic { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public bool IsMan { get; set; }

        [Required]
        public byte Age { get; set; }

        [Required]
        public required string Phone {  get; set; }
    }
}
