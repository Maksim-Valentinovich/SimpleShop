using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
