using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrderingSystemApp.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
