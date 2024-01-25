using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        public string? Patronymic { get; set; }

        //[Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime Birthday { get; set; }

        public bool IsMan { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string? ConfirmPassword { get; set; }
    }
}
