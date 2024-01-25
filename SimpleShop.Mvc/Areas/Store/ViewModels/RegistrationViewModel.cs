using System.ComponentModel.DataAnnotations;

namespace SimpleShop.Mvc.Areas.Store.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Не указана дата рождения")]
        public DateTime Birthday { get; set; }

        public bool IsMan { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        public string? Phone { get; set; }
    }
}
