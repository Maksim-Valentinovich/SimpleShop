using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public required string Surname { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        public required string Patronymic { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime Birthday { get; set; }

        public bool IsMan { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public required string ConfirmPassword { get; set; }
    }
}
