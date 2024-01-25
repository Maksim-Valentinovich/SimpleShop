using Microsoft.AspNetCore.Mvc;

namespace SimpleShop.Mvc.Areas.Store.ViewComponents
{
    public class Menu : ViewComponent
    {
        public string Invoke()
        {
            return $"Текущее время: {DateTime.Now.ToString("hh:mm:ss")}";
        }
    }
}
