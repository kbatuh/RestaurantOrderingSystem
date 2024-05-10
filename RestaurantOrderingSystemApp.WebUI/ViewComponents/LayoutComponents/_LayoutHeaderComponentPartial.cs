using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderingSystemApp.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
