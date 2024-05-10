using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderingSystemApp.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
